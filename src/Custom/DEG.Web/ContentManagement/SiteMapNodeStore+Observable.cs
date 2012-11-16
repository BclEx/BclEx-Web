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
using System;
using System.Linq;
using System.Configuration.Provider;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using DEG.ContentManagement.Nodes;
using Contoso.Primitives.TextPacks;
namespace DEG.ContentManagement
{
    public partial class SiteMapNodeStore<TRouteCreator>
    {
        /// <summary>
        /// Observable
        /// </summary>
        public class Observable : StaticSiteMapProviderEx.ObservableBase
        {
            private ISiteMapNodeStoreRouteCreator _routeCreator;
            private readonly string _connect;
            private readonly int _connectShard;
            private readonly StaticSiteMapProviderEx _provider;
            private SiteMapNode _rootNode;
            private int _sequence;

            #region Class Types

            /// <summary>
            /// RootOrdinal
            /// </summary>
            protected class RootOrdinal
            {
                /// <summary>
                /// 
                /// </summary>
                public int Name, Uri;
                /// <summary>
                /// Initializes a new instance of the <see cref="SiteMapNodeStore&lt;TRouteCreator&gt;.Observable.RootOrdinal"/> class.
                /// </summary>
                /// <param name="r">The r.</param>
                public RootOrdinal(IDataRecord r)
                {
                    Name = r.GetOrdinal("Name");
                    Uri = r.GetOrdinal("Uri");
                }
            }

            /// <summary>
            /// PageOrdinal
            /// </summary>
            protected class PageOrdinal
            {
                /// <summary>
                /// 
                /// </summary>
                public int Key, Uid, DefaultTreeId, TreeId, Type, Id, Name, SectionId, AttribStream, IsHidden, PageDynamism, LastModifyDate, Virtualize;
                /// <summary>
                /// Initializes a new instance of the <see cref="SiteMapNodeStore&lt;TRouteCreator&gt;.Observable.PageOrdinal"/> class.
                /// </summary>
                /// <param name="r">The r.</param>
                public PageOrdinal(IDataRecord r)
                {
                    Key = r.GetOrdinal("Key");
                    Uid = r.GetOrdinal("Uid");
                    DefaultTreeId = r.GetOrdinal("DefaultTreeId");
                    TreeId = r.GetOrdinal("TreeId");
                    Type = r.GetOrdinal("Type");
                    Id = r.GetOrdinal("Id");
                    Name = r.GetOrdinal("Name");
                    SectionId = r.GetOrdinal("SectionId");
                    AttribStream = r.GetOrdinal("AttribStream");
                    IsHidden = r.GetOrdinal("IsHidden");
                    PageDynamism = r.GetOrdinal("PageDynamism");
                    LastModifyDate = r.GetOrdinal("LastModifyDate");
                    Virtualize = r.GetOrdinal("Virtualize");
                }
            }

            /// <summary>
            /// Creates the page ordinal.
            /// </summary>
            /// <param name="r">The r.</param>
            /// <returns></returns>
            protected virtual PageOrdinal CreatePageOrdinal(IDataReader r) { return new PageOrdinal(r); }

            #endregion

            /// <summary>
            /// Initializes a new instance of the <see cref="SiteMapNodeStore&lt;TRouteCreator&gt;.Observable"/> class.
            /// </summary>
            /// <param name="parent">The parent.</param>
            public Observable(SiteMapNodeStore<TRouteCreator> parent)
            {
                _connect = parent._connect;
                _connectShard = parent._connectShard;
                _provider = parent._provider;
            }

            /// <summary>
            /// Gets the root node.
            /// </summary>
            /// <returns></returns>
            public override SiteMapNode GetRootNode()
            {
                return _rootNode;
            }

            /// <summary>
            /// VirtualNode
            /// </summary>
            protected struct VirtualNode
            {
                /// <summary>
                /// Initializes a new instance of the <see cref="SiteMapNodeStore&lt;TRouteCreator&gt;.Observable.VirtualNode"/> struct.
                /// </summary>
                /// <param name="node">The node.</param>
                /// <param name="treeId">The tree id.</param>
                public VirtualNode(SiteMapVirtualNode node, string treeId)
                    : this() { Node = node; TreeId = treeId; }
                /// <summary>
                /// Gets or sets the node.
                /// </summary>
                /// <value>
                /// The node.
                /// </value>
                public SiteMapVirtualNode Node { get; private set; }
                /// <summary>
                /// Gets or sets the tree id.
                /// </summary>
                /// <value>
                /// The tree id.
                /// </value>
                public string TreeId { get; private set; }
            }

            /// <summary>
            /// AddProviderNode
            /// </summary>
            protected struct AddProviderNode
            {
                /// <summary>
                /// Initializes a new instance of the <see cref="SiteMapNodeStore&lt;TRouteCreator&gt;.Observable.AddProviderNode"/> struct.
                /// </summary>
                /// <param name="providerName">Name of the provider.</param>
                /// <param name="parentNode">The parent node.</param>
                /// <param name="rebaseAction">The rebase action.</param>
                public AddProviderNode(string providerName, SiteMapNode parentNode, Action<SiteMapNode> rebaseAction)
                    : this() { ProviderName = providerName; ParentNode = parentNode; RebaseAction = rebaseAction; }
                /// <summary>
                /// Gets or sets the name of the provider.
                /// </summary>
                /// <value>
                /// The name of the provider.
                /// </value>
                public string ProviderName { get; private set; }
                /// <summary>
                /// Gets or sets the parent node.
                /// </summary>
                /// <value>
                /// The parent node.
                /// </value>
                public SiteMapNode ParentNode { get; private set; }
                /// <summary>
                /// Gets or sets the rebase action.
                /// </summary>
                /// <value>
                /// The rebase action.
                /// </value>
                public Action<SiteMapNode> RebaseAction { get; private set; }
            }

            /// <summary>
            /// Subscribes the specified observer.
            /// </summary>
            /// <param name="observer">The observer.</param>
            /// <returns></returns>
            public override IDisposable Subscribe(IObserver<StaticSiteMapProviderEx.NodeToAdd> observer)
            {
                if (observer == null)
                    throw new ArgumentNullException("observer");
                if (string.IsNullOrEmpty(_connect))
                    throw new ProviderException("Empty connection string");
                var nodes = new Dictionary<string, SiteMapNodeEx>(16);
                using (_routeCreator = new TRouteCreator())
                {
                    try
                    {
                        IDbCommand command;
                        List<VirtualNode> virtualNodes;
                        List<AddProviderNode> addProviderNodes;
                        using (var connection = Open(_connect, out command))
                        {
                            connection.Open();
                            _sequence = 0;
                            using (var r = command.ExecuteReader())
                            {
                                var rootOrdinal = new RootOrdinal(r);
                                if (!r.Read())
                                    throw new InvalidOperationException("No Results");
                                // create the root SiteMapNode and add it to the site map
                                var rootName = r.Field<string>(rootOrdinal.Name, "Home");
                                var rootUri = "/" + r.Field<string>(rootOrdinal.Uri, "Index.htm");
                                _rootNode = new SiteMapRootNode(_provider, "#" + _provider.Name, rootUri, rootName);
                                observer.OnNext(new StaticSiteMapProviderEx.NodeToAdd { Node = _rootNode });
                                // build a tree of SiteMapNodes underneath the root node
                                r.NextResult();
                                var pageOrdinal = CreatePageOrdinal(r);
                                string hiddenRootTreeId = null;
                                virtualNodes = new List<VirtualNode>();
                                addProviderNodes = new List<AddProviderNode>();
                                while (r.Read())
                                {
                                    var parentNode = GetParentNodeFromDataReader(nodes, _rootNode, pageOrdinal, r, false);
                                    var node = CreateSiteMapNodeFromDataReader(parentNode, nodes, virtualNodes, addProviderNodes, pageOrdinal, r, ref hiddenRootTreeId);
                                    if (node != null)
                                        observer.OnNext(new StaticSiteMapProviderEx.NodeToAdd { Node = node, ParentNode = parentNode });
                                }
                            }
                        }
                        if (virtualNodes.Count > 0)
                            LinkVirtualNodes(nodes, virtualNodes);
                        if (addProviderNodes.Count > 0)
                            LinkAddProviderNodes(_provider, addProviderNodes);
                        observer.OnCompleted();
                        return null;
                    }
                    catch (Exception ex) { observer.OnError(ex); return null; }
                }
            }

            private static void LinkVirtualNodes(Dictionary<string, SiteMapNodeEx> nodes, IEnumerable<VirtualNode> virtualNodes)
            {
                SiteMapNodeEx node;
                foreach (var virtualNode in virtualNodes.Where(x => x.TreeId != null))
                    if (nodes.TryGetValue(virtualNode.TreeId, out node))
                    {
                        var key = virtualNode.Node;
                        var nodeExtent = node.Get<SiteMapNodePartialProviderExtent>();
                        if (nodeExtent != null)
                            key.Set<SiteMapNodePartialProviderExtent>(nodeExtent);
                        key.Actual = node;
                    }
            }

            private static void LinkAddProviderNodes(StaticSiteMapProviderEx provider, IEnumerable<AddProviderNode> addProviderNodes)
            {
                foreach (var addProviderNode in addProviderNodes)
                    provider.AddProvider(addProviderNode.ProviderName, addProviderNode.ParentNode, addProviderNode.RebaseAction);
            }

            /// <summary>
            /// Opens the specified connect.
            /// </summary>
            /// <param name="connect">The connect.</param>
            /// <param name="command">The command.</param>
            /// <returns></returns>
            protected virtual IDbConnection Open(string connect, out IDbCommand command)
            {
                var sqlConnection = new SqlConnection(connect);
                var sqlCommand = new SqlCommand("dbo.[cn_Page::SiteMap]", sqlConnection) { CommandType = CommandType.StoredProcedure };
                sqlCommand.Parameters.AddWithValue("cLastModifyBy", "System");
                sqlCommand.Parameters.AddWithValue("nShard", _connectShard);
                sqlCommand.Parameters.AddWithValue("cLocalCultureId", "en-US");
                command = sqlCommand;
                return sqlConnection;
            }

            private static readonly ITextPack _xmlTextPack = new XmlTextPack();
            private static IDictionary<string, string> BuildAttrib(string attribAsText)
            {
                return (string.IsNullOrEmpty(attribAsText) ? null : _xmlTextPack.Decode(attribAsText, null, null));
            }

            /// <summary>
            /// Creates the site map node from data reader.
            /// </summary>
            /// <param name="parentNode">The parent node.</param>
            /// <param name="nodes">The nodes.</param>
            /// <param name="virtualNodes">The virtual nodes.</param>
            /// <param name="addProviderNodes">The add provider nodes.</param>
            /// <param name="ordinal">The ordinal.</param>
            /// <param name="r">The r.</param>
            /// <param name="hiddenRootTreeId">The hidden root tree id.</param>
            /// <returns></returns>
            protected virtual SiteMapNode CreateSiteMapNodeFromDataReader(SiteMapNode parentNode, Dictionary<string, SiteMapNodeEx> nodes, List<VirtualNode> virtualNodes, List<AddProviderNode> addProviderNodes, PageOrdinal ordinal, IDataReader r, ref string hiddenRootTreeId)
            {
                if (r.IsDBNull(ordinal.TreeId))
                    throw new ProviderException("Missing node ID");
                var treeId = r.GetString(ordinal.TreeId);
                if (nodes.ContainsKey(treeId))
                    throw new ProviderException("Duplicate node ID");
                var visible = !r.Field<bool>(ordinal.IsHidden);
                var key = r.Field<int>(ordinal.Key);
                var uid = r.Field<string>(ordinal.Uid);
                var defaultTreeId = r.Field<string>(ordinal.DefaultTreeId);
                var type = r.Field<string>(ordinal.Type);
                var id = r.Field<string>(ordinal.Id);
                var name = r.Field<string>(ordinal.Name);
                var sectionId = r.Field<string>(ordinal.SectionId);
                //var attrib = r.Field<Nattrib>(ordinal.AttribStream);
                var attrib = BuildAttrib(r.Field<string>(ordinal.AttribStream));
                //
                var pageDynamism = r.Field<string>(ordinal.PageDynamism);
                var lastModifyDate = r.Field<DateTime?>(ordinal.LastModifyDate);
                var virtualize = r.Field<string>(ordinal.Virtualize);
                // hidden branches
                if (!visible)
                {
                    if (hiddenRootTreeId == null || !treeId.StartsWith(hiddenRootTreeId))
                        hiddenRootTreeId = treeId;
                }
                else if (hiddenRootTreeId != null)
                {
                    if (treeId.StartsWith(hiddenRootTreeId))
                        visible = false;
                    else
                        hiddenRootTreeId = null;
                }
                // make url
                Action setRoute = null;
                SiteMapNodeEx node;
                switch (type)
                {
                    case "X-AddProvider":
                        addProviderNodes.Add(new AddProviderNode(virtualize, parentNode, x =>
                        {
                            x.Title = name;
                            var externalProvider = (x.Provider as StaticSiteMapProviderEx);
                            if (externalProvider != null)
                                externalProvider.RebaseNodesRecurse(x, "/" + id);
                        }));
                        return null;
                    case "X-Section":
                        SiteMapVirtualNode virtualNode;
                        node = virtualNode = new SiteMapSectionNode(_provider, uid, "/" + id, name);
                        setRoute = () => SetRouteInNode(_routeCreator.CreateRoutes(node, id, virtualize), node);
                        virtualNodes.Add(new VirtualNode(virtualNode, defaultTreeId));
                        break;
                    case "E-Form":
                        node = new SiteMapFormNode(_provider, uid, "/" + id, name);
                        node.Set<SiteMapNodePartialProviderExtent>(new SiteMapNodePartialProviderExtent());
                        setRoute = () => SetRouteInNode(_routeCreator.CreateRoutes(node, id, virtualize), node);
                        break;
                    case "E-ListDetail":
                        node = new SiteMapListDetailNode(_provider, uid, "/" + id, name);
                        node.Set<SiteMapNodePartialProviderExtent>(new SiteMapNodePartialProviderExtent());
                        setRoute = () => SetRouteInNode(_routeCreator.CreateRoutes(node, id, virtualize), node);
                        break;
                    case "X-Link":
                        id = StringEx.Axb(sectionId, "/", id);
                        string linkUri;
                        if (!attrib.TryGetValue("LinkUri", out linkUri))
                            linkUri = "/";
                        node = new SiteMapLinkNode(_provider, uid, "/" + id, name) { LinkUri = linkUri };
                        node.Set<Func<IDynamicNode, RouteData>>(nodeEx =>
                        {
                            var linkNodeEx = (nodeEx as SiteMapLinkNode);
                            if (linkNodeEx != null)
                            {
                                var context = HttpContext.Current;
                                var query = context.Request.Url.Query;
                                context.Response.Redirect(query.Length == 0 ? linkNodeEx.LinkUri : linkNodeEx.LinkUri + query);
                            }
                            return null;
                        });
                        break;
                    case "X-Content":
                        id = StringEx.Axb(sectionId, "/", id);
                        node = new SiteMapPageNode(_provider, uid, "/" + id, name);
                        setRoute = () => SetRouteInNode(_routeCreator.CreateRoutes(node, id, virtualize), node);
                        break;
                    default:
                        throw new InvalidOperationException();
                }
                node.Visible = visible;
                // map attrib
                if (attrib != null)
                    foreach (var attribKey in attrib.Keys)
                        node[attribKey] = attrib[attribKey];
                // content
                var sectionNode = GetParentNodeFromDataReader(nodes, _rootNode, ordinal, r, true);
                node.Set<SiteMapNodeContentExtent>(new SiteMapNodeContentExtent { Shard = _connectShard, Key = key, TreeId = treeId, SectionNode = sectionNode, Sequence = _sequence++ });
                var contentNode = (node as SiteMapPageNode);
                if (contentNode != null)
                {
                    contentNode.LastModifyDate = lastModifyDate;
                    contentNode.PageDynamism = pageDynamism;
                    contentNode.PagePriority = null;
                }
                nodes.Add(treeId, node);
                // set route last so node values are populated before routes are determined.
                if (setRoute != null)
                    setRoute();
                return node;
            }

            private static void SetRouteInNode(IEnumerable<Route> routes, SiteMapNodeEx node)
            {
                DynamicRoute.SetRouteDefaults(routes, node);
                int routes2 = routes.Count();
                if (routes2 == 1)
                    node.Set<Route>(routes.Single());
                else if (routes2 > 0)
                    node.SetMany<Route>(routes);
            }

            private static SiteMapNode GetParentNodeFromDataReader(Dictionary<string, SiteMapNodeEx> nodes, SiteMapNode rootNode, PageOrdinal ordinal, IDataReader r, bool findSection)
            {
                if (r.IsDBNull(ordinal.TreeId))
                    throw new ProviderException("Missing parent ID");
                // Get the parent ID from the DataReader
                var parentTreeId = r.GetString(ordinal.TreeId);
                var nodeLength = (!parentTreeId.StartsWith("/@Draft/") ? 4 : 11);
                if (parentTreeId.Length == nodeLength)
                    return rootNode;
                // Make sure the parent ID is valid
                SiteMapNodeEx value;
                parentTreeId = parentTreeId.Substring(0, (!findSection ? parentTreeId.Length - nodeLength : nodeLength));
                if (!nodes.TryGetValue(parentTreeId, out value)) { }
                //throw new ProviderException("Invalid parent ID");
                return (!findSection ? value : value as SiteMapSectionNode);
            }
        }
    }
}
