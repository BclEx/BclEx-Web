#region License
/*
The MIT License

Copyright (c) 2008 Sky Morey

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
#endregion
using System.Threading;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System.Reflection;
using System.Collections;
namespace System.Web
{
    /// <summary>
    /// StaticSiteMapProviderEx
    /// </summary>
    public partial class StaticSiteMapProviderEx : StaticSiteMapProvider, ISiteMapProvider, IDynamicRoutingContext
    {
        private IStaticSiteMapProviderExNodeStore _nodeStore;
        private ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        private SiteMapNode _rootNode;
        private object _providerLock;
        private MethodInfo _providerRemoveNode = typeof(SiteMapProvider).GetMethod("RemoveNode", BindingFlags.NonPublic | BindingFlags.Instance);
        private IDictionary _providerKeyTable;
        private IDictionary _providerUrlTable;

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticSiteMapProviderEx"/> class.
        /// </summary>
        public StaticSiteMapProviderEx()
        {
            _providerLock = typeof(SiteMapProvider).GetField("_lock", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);
            var baseType = typeof(StaticSiteMapProvider);
            _providerKeyTable = (IDictionary)baseType.GetProperty("KeyTable", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this, null);
            _providerUrlTable = (IDictionary)baseType.GetProperty("UrlTable", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this, null);
        }

        /// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// The name of the provider is null.
        ///   </exception>
        ///   
        /// <exception cref="T:System.ArgumentException">
        /// The name of the provider has a length of zero.
        ///   </exception>
        ///   
        /// <exception cref="T:System.InvalidOperationException">
        /// An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"/> on a provider after the provider has already been initialized.
        ///   </exception>
        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
                throw new ArgumentNullException("config");
            if (string.IsNullOrEmpty(name))
                name = "StaticSiteMapProviderEx";
            var nodeStoreType = config["nodeStoreType"];
            if (string.IsNullOrEmpty(nodeStoreType))
                throw new ProviderException("config:nodeStoreType");
            // Add a default "description" attribute to config if the attribute doesn’t exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "static site map provider");
            }
            base.Initialize(name, config);
            _nodeStore = (IStaticSiteMapProviderExNodeStore)Activator.CreateInstance(Type.GetType(nodeStoreType));
            //if (_nodeStore == null)
            //    throw new ProviderException("Invalid Node Store");
            _nodeStore.Initialize(this, _rwLock, config);
            // SiteMapProvider processes the securityTrimmingEnabled attribute but fails to remove it. Remove it now so we can check for unrecognized configuration attributes.
            if (config["securityTrimmingEnabled"] != null)
                config.Remove("securityTrimmingEnabled");
        }

        private static SiteMapProvider GetProviderFromName(string providerName)
        {
            if (providerName == null)
                // StubSiteMapProvider
                return null;
            var provider = SiteMap.Providers[providerName];
            if (provider == null)
                throw new ProviderException(string.Format("Provider_Not_Found", providerName));
            return provider;
        }

        /// <summary>
        /// Finds the site map node.
        /// </summary>
        /// <typeparam name="TNode">The type of the node.</typeparam>
        /// <param name="rawUrl">The raw URL.</param>
        /// <returns></returns>
        public TNode FindSiteMapNode<TNode>(string rawUrl)
            where TNode : SiteMapNode { return (TNode)FindSiteMapNode(rawUrl); }
        /// <summary>
        /// Retrieves a <see cref="T:System.Web.SiteMapNode"/> object that represents the page at the specified URL.
        /// </summary>
        /// <param name="rawUrl">A URL that identifies the page for which to retrieve a <see cref="T:System.Web.SiteMapNode"/>.</param>
        /// <returns>
        /// A <see cref="T:System.Web.SiteMapNode"/> that represents the page identified by <paramref name="rawUrl"/>; otherwise, null, if no corresponding site map node is found.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="rawUrl"/> is null.
        ///   </exception>
        public override SiteMapNode FindSiteMapNode(string rawUrl)
        {
            if (rawUrl == null)
                throw new ArgumentNullException("rawUrl");
            // check end of url
            var rawUrlLength = rawUrl.Length;
            if (rawUrlLength > 1 && rawUrl.EndsWithSlim("/"))
                rawUrl = rawUrl.Substring(0, rawUrlLength - 1);
            // locks handled by BuildSiteMap
            var node = base.FindSiteMapNode(rawUrl);
            if (node != null)
                return node;
            // child providers
            if (HasChildProviders)
            {
                node = FindSiteMapNodeFromChildProvider(rawUrl);
                if (node != null)
                    return node;
            }
            // get url segments
            rawUrl = rawUrl.Trim();
            string queryPart;
            var segments = GetUrlSegments(rawUrl, out queryPart);
            // tightest for partialproviders
            if (HasPartialProviders)
            {
                node = FindSiteMapNodeFromPartialProvider(segments);
                if (node != null)
                    return node;
            }
            // scan for node			
            node = FindSiteMapNodeFromScan(segments);
            SiteMapNodeEx nodeEx;
            return (node == null || (nodeEx = (node as SiteMapNodeEx)) == null || !nodeEx.HasExtents ? null : ExNodeFoundFromScan(nodeEx, segments));
        }

        private static string[] GetUrlSegments(string rawUrl, out string queryPart)
        {
            if (string.IsNullOrEmpty(rawUrl))
                throw new ArgumentNullException("rawUrl");
            rawUrl = rawUrl.Substring(1);
            var index = rawUrl.IndexOf("?", StringComparison.Ordinal);
            if (index == -1)
            {
                queryPart = null;
                return rawUrl.Split('/');
            }
            queryPart = rawUrl.Substring(index);
            return rawUrl.Substring(0, index).Split('/');
        }

        /// <summary>
        /// Finds the site map node.
        /// </summary>
        /// <typeparam name="TNode">The type of the node.</typeparam>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public TNode FindSiteMapNode<TNode>(HttpContext context)
            where TNode : SiteMapNode { return (TNode)FindSiteMapNode(context); }
        //public override SiteMapNode FindSiteMapNode(HttpContext context)
        //{
        //    return base.FindSiteMapNode(context);
        //}

        /// <summary>
        /// Finds the site map node from key.
        /// </summary>
        /// <typeparam name="TNode">The type of the node.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public TNode FindSiteMapNodeFromKey<TNode>(string key)
            where TNode : SiteMapNode { return (TNode)FindSiteMapNodeFromKey(key); }
        /// <summary>
        /// Retrieves a <see cref="T:System.Web.SiteMapNode"/> object based on a specified key.
        /// </summary>
        /// <param name="key">A lookup key with which a <see cref="T:System.Web.SiteMapNode"/> is created.</param>
        /// <returns>
        /// A <see cref="T:System.Web.SiteMapNode"/> that represents the page identified by <paramref name="key"/>; otherwise, null, if security trimming is enabled and the site map node cannot be shown to the current user or the site map node is not found in the site map node collection by <paramref name="key"/>.
        /// </returns>
        public override SiteMapNode FindSiteMapNodeFromKey(string key)
        {
            // locks handled by BuildSiteMap
            var node = FindSiteMapNodeFromKeyEx(key, false);
            if (node != null)
                return node;
            return FindSiteMapNodeFromChildProviderKey(key);
        }

        /// <summary>
        /// Exes the node found from scan.
        /// </summary>
        /// <param name="nodeEx">The node ex.</param>
        /// <param name="segments">The segments.</param>
        /// <returns></returns>
        protected virtual SiteMapNode ExNodeFoundFromScan(SiteMapNodeEx nodeEx, string[] segments)
        {
            // locks handled by FindSiteMapNode
            return CheckExNodeFromScanAsPartialProvider(nodeEx, segments);
        }

        /// <summary>
        /// When overridden in a derived class, loads the site map information from persistent storage and builds it in memory.
        /// </summary>
        /// <returns>
        /// The root <see cref="T:System.Web.SiteMapNode"/> of the site map navigation structure.
        /// </returns>
        public override SiteMapNode BuildSiteMap()
        {
            _rwLock.EnterUpgradeableReadLock();
            // return immediately if this method has been called before
            if (_rootNode != null)
            {
                _rwLock.ExitUpgradeableReadLock();
                return _rootNode;
            }
            _rwLock.EnterWriteLock();
            //
            try
            {
                // clear - if Subscribe throws it will rebuild next request, make fresh.
                base.Clear();
                _nodeStore.Clear();
                _rootNode = null;
                // build
                var observable = _nodeStore.CreateObservable();
                observable.Subscribe(new Observer(this));
                _rootNode = observable.GetRootNode();
                // still in lock
                // if site map build fails then set to try next request
                try { OnSiteMapBuilt(); }
                catch { _rootNode = null; }
            }
            finally
            {
                _rwLock.ExitWriteLock();
                _rwLock.ExitUpgradeableReadLock();
            }
            return _rootNode;
        }

        /// <summary>
        /// When overridden in a derived class, retrieves the root node of all the nodes that are currently managed by the current provider.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Web.SiteMapNode"/> that represents the root node of the set of nodes that the current provider manages.
        /// </returns>
        protected override SiteMapNode GetRootNodeCore()
        {
            // locks handled by BuildSiteMap
            return BuildSiteMap();
        }

        /// <summary>
        /// Adds a <see cref="T:System.Web.SiteMapNode"/> to the collections that are maintained by the site map provider and establishes a parent/child relationship between the <see cref="T:System.Web.SiteMapNode"/> objects.
        /// </summary>
        /// <param name="node">The <see cref="T:System.Web.SiteMapNode"/> to add to the site map provider.</param>
        /// <param name="parentNode">The <see cref="T:System.Web.SiteMapNode"/> under which to add <paramref name="node"/>.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <paramref name="node"/> is null.
        ///   </exception>
        ///   
        /// <exception cref="T:System.InvalidOperationException">
        /// The <see cref="P:System.Web.SiteMapNode.Url"/> or <see cref="P:System.Web.SiteMapNode.Key"/> is already registered with the <see cref="T:System.Web.StaticSiteMapProvider"/>. A site map node must be made up of pages with unique URLs or keys.
        ///   </exception>
        protected override void AddNode(SiteMapNode node, SiteMapNode parentNode)
        {
            // assume in locked region
            if (!(node is IWantUnconstrainedSiteMapNode))
            {
                base.AddNode(node, parentNode);
                return;
            }
            var lastUrl = node.Url;
            node.Url = string.Empty;
            base.AddNode(node, parentNode);
            node.Url = lastUrl;
        }

        /// <summary>
        /// Removes all elements in the collections of child and parent site map nodes that the <see cref="T:System.Web.StaticSiteMapProvider"/> tracks as part of its state.
        /// </summary>
        protected override void Clear()
        {
            _rwLock.EnterWriteLock();
            try
            {
                base.Clear();
                _nodeStore.Clear();
                _rootNode = null;
            }
            finally { _rwLock.ExitWriteLock(); }
        }

        void ISiteMapProvider.Clear()
        {
            Clear();
        }

        /// <summary>
        /// Called when [site map built].
        /// </summary>
        protected virtual void OnSiteMapBuilt()
        {
            var siteMapBuild = SiteMapBuilt;
            if (siteMapBuild != null)
                siteMapBuild(this, EventArgs.Empty);
        }

        /// <summary>
        /// Occurs when [site map built].
        /// </summary>
        public event EventHandler<EventArgs> SiteMapBuilt;

        /// <summary>
        /// Gets the parent node.
        /// </summary>
        /// <typeparam name="TNode">The type of the node.</typeparam>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        public TNode GetParentNode<TNode>(SiteMapNode node)
            where TNode : SiteMapNode { return (TNode)GetParentNode(node); }

        #region DynamicRoutingContext

        IDynamicNode IDynamicRoutingContext.FindNode(string path)
        {
            return (FindSiteMapNode(path) as IDynamicNode);
        }

        IDynamicNode IDynamicRoutingContext.FindNodeByID(string id)
        {
            return (FindSiteMapNodeFromKey(id) as IDynamicNode);
        }

        #endregion
    }
}