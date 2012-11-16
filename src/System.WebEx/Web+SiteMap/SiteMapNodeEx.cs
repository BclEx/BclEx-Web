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
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;
using System.Collections.Generic;
using System.Web.Routing;
namespace System.Web
{
    /// <summary>
    /// SiteMapNodeEx
    /// </summary>
    public class SiteMapNodeEx : SiteMapNode, IDynamicNode, IExtentSet
    {
        /// <summary>
        /// Empty
        /// </summary>
        public static readonly SiteMapNodeEx Empty = new SiteMapNodeEx(new EmptySiteMapProvider(), string.Empty);
        private static readonly Type _type = typeof(SiteMapNodeEx);
        private IExtentSet _defaultExtentSet = new ExtentSet();
        private Dictionary<Type, IExtentSet> _extentSets;
        private IHaveVirtualUrlSiteMapNode _haveVirtualUrlSiteMapNode;

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteMapNodeEx"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="key">The key.</param>
        public SiteMapNodeEx(SiteMapProvider provider, string key)
            : base(provider, key) { Visible = true; _haveVirtualUrlSiteMapNode = (this as IHaveVirtualUrlSiteMapNode); }
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteMapNodeEx"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="key">The key.</param>
        /// <param name="url">The URL.</param>
        public SiteMapNodeEx(SiteMapProvider provider, string key, string url)
            : base(provider, key, url) { Visible = true; _haveVirtualUrlSiteMapNode = (this as IHaveVirtualUrlSiteMapNode); }
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteMapNodeEx"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="key">The key.</param>
        /// <param name="url">The URL.</param>
        /// <param name="title">The title.</param>
        public SiteMapNodeEx(SiteMapProvider provider, string key, string url, string title)
            : base(provider, key, url, title) { Visible = true; _haveVirtualUrlSiteMapNode = (this as IHaveVirtualUrlSiteMapNode); }
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteMapNodeEx"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="key">The key.</param>
        /// <param name="url">The URL.</param>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        public SiteMapNodeEx(SiteMapProvider provider, string key, string url, string title, string description)
            : base(provider, key, url, title, description) { Visible = true; _haveVirtualUrlSiteMapNode = (this as IHaveVirtualUrlSiteMapNode); }
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteMapNodeEx"/> class.
        /// </summary>
        /// <param name="provider">The <see cref="T:System.Web.SiteMapProvider"/> with which the node is associated.</param>
        /// <param name="key">A provider-specific lookup key.</param>
        /// <param name="url">The URL of the page that the node represents within the site.</param>
        /// <param name="title">A label for the node, often displayed by navigation controls.</param>
        /// <param name="description">A description of the page that the node represents.</param>
        /// <param name="roles">An <see cref="T:System.Collections.IList"/> of roles that are allowed to view the page represented by the <see cref="T:System.Web.SiteMapNode"/>.</param>
        /// <param name="attributes">A <see cref="T:System.Collections.Specialized.NameValueCollection"/> of additional attributes used to initialize the <see cref="T:System.Web.SiteMapNode"/>.</param>
        /// <param name="explicitResourceKeys">A <see cref="T:System.Collections.Specialized.NameValueCollection"/> of explicit resource keys used for localization.</param>
        /// <param name="implicitResourceKey">An implicit resource key used for localization.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <see cref="T:System.Web.SiteMapProvider"/> is null.
        /// - or -
        ///   <paramref name="key"/> is null.
        ///   </exception>
        public SiteMapNodeEx(SiteMapProvider provider, string key, string url, string title, string description, IList roles, NameValueCollection attributes, NameValueCollection explicitResourceKeys, string implicitResourceKey)
            : base(provider, key, url, title, description, roles, attributes, explicitResourceKeys, implicitResourceKey) { Visible = true; _haveVirtualUrlSiteMapNode = (this as IHaveVirtualUrlSiteMapNode); }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="SiteMapNodeEx"/> is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
        public bool Visible { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance has extents.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has extents; otherwise, <c>false</c>.
        /// </value>
        public bool HasExtents
        {
            get { return _defaultExtentSet.HasExtents; }
        }
        /// <summary>
        /// Determines whether this instance has extent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        ///   <c>true</c> if this instance has extent; otherwise, <c>false</c>.
        /// </returns>
        public bool HasExtent<T>() { return _defaultExtentSet.HasExtent<T>(); }
        /// <summary>
        /// Determines whether this instance has extent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        /// <returns>
        ///   <c>true</c> if this instance has extent; otherwise, <c>false</c>.
        /// </returns>
        public bool HasExtent<T, TShard>() { return GetRepositoryExtents(typeof(TShard)).HasExtent<T>(); }
        /// <summary>
        /// Determines whether the specified type has extent.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if the specified type has extent; otherwise, <c>false</c>.
        /// </returns>
        public bool HasExtent(Type type) { return _defaultExtentSet.HasExtent(type); }
        /// <summary>
        /// Sets the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        public void Set<T>(T value) { _defaultExtentSet.Set<T>(value); }
        /// <summary>
        /// Sets the many.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        public void SetMany<T>(IEnumerable<T> value) { _defaultExtentSet.SetMany<T>(value); }
        /// <summary>
        /// Sets the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        /// <param name="value">The value.</param>
        public void Set<T, TShard>(T value) { GetRepositoryExtents(typeof(TShard)).Set<T>(value); }
        /// <summary>
        /// Sets the many.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        /// <param name="value">The value.</param>
        public void SetMany<T, TShard>(IEnumerable<T> value) { GetRepositoryExtents(typeof(TShard)).SetMany<T>(value); }
        /// <summary>
        /// Sets the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        public void Set(Type type, object value) { _defaultExtentSet.Set(type, value); }
        /// <summary>
        /// Clears this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void Clear<T>() { _defaultExtentSet.Clear<T>(); }
        /// <summary>
        /// Clears this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        public void Clear<T, TShard>() { GetRepositoryExtents(typeof(TShard)).Clear<T>(); }
        /// <summary>
        /// Clears the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        public void Clear(Type type) { _defaultExtentSet.Clear(type); }
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>() { return _defaultExtentSet.Get<T>(); }
        /// <summary>
        /// Gets the many.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetMany<T>() { return _defaultExtentSet.GetMany<T>(); }
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        /// <returns></returns>
        public T Get<T, TShard>() { return GetRepositoryExtents(typeof(TShard)).Get<T>(); }
        /// <summary>
        /// Gets the many.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetMany<T, TShard>() { return GetRepositoryExtents(typeof(TShard)).GetMany<T>(); }
        /// <summary>
        /// Gets the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public object Get(Type type) { return _defaultExtentSet.Get(type); }
        /// <summary>
        /// Tries the get.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="extent">The extent.</param>
        /// <returns></returns>
        public bool TryGet<T>(out T extent) { return _defaultExtentSet.TryGet<T>(out extent); }
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="extents">The extents.</param>
        public void AddRange(IEnumerable<object> extents) { _defaultExtentSet.AddRange(extents); }

        /// <summary>
        /// Gets the repository extents.
        /// </summary>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        /// <returns></returns>
        public IExtentSet GetRepositoryExtents<TShard>() { return GetRepositoryExtents(typeof(TShard)); }
        /// <summary>
        /// Gets the repository extents.
        /// </summary>
        /// <param name="shard">The shard.</param>
        /// <returns></returns>
        public IExtentSet GetRepositoryExtents(Type shard)
        {
            if (shard == null)
                throw new ArgumentNullException("shard");
            if (shard == _type)
                return _defaultExtentSet;
            // repositories
            if (_extentSets == null)
                _extentSets = new Dictionary<Type, IExtentSet>();
            IExtentSet extentSet;
            if (!_extentSets.TryGetValue(shard, out extentSet))
                _extentSets.Add(shard, (extentSet = new ExtentSet()));
            return extentSet;
        }
        /// <summary>
        /// Sets the repository.
        /// </summary>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        /// <param name="repository">The repository.</param>
        public void SetRepository<TShard>(IExtentSet repository) { SetRepository(typeof(TShard), repository); }
        /// <summary>
        /// Sets the repository.
        /// </summary>
        /// <param name="shard">The shard.</param>
        /// <param name="repository">The repository.</param>
        public void SetRepository(Type shard, IExtentSet repository)
        {
            if (shard == null)
                throw new ArgumentException("shard");
            if (repository == null)
                throw new ArgumentException("repository");
            if (shard == _type)
                _defaultExtentSet = repository;
            // repositories
            if (_extentSets == null)
                _extentSets = new Dictionary<Type, IExtentSet>();
            _extentSets[shard] = repository;
        }

        /// <summary>
        /// Gets or sets the interior URL.
        /// </summary>
        /// <value>
        /// The interior URL.
        /// </value>
        public string InteriorUrl
        {
            get { return base.Url; }
            set { base.Url = value; }
        }

        /// <summary>
        /// Gets or sets the URL of the page that the <see cref="T:System.Web.SiteMapNode"/> object represents.
        /// </summary>
        /// <returns>
        /// The URL of the page that the node represents. The default is <see cref="F:System.String.Empty"/>.
        ///   </returns>
        ///   
        /// <exception cref="T:System.InvalidOperationException">
        /// The node is read-only.
        ///   </exception>
        public new string Url
        {
            get { return (_haveVirtualUrlSiteMapNode == null ? base.Url : _haveVirtualUrlSiteMapNode.Url); }
            set
            {
                if (_haveVirtualUrlSiteMapNode == null)
                    base.Url = value;
                else
                    _haveVirtualUrlSiteMapNode.Url = value;
            }
        }

        #region EmptySiteMapProvider

        private class EmptySiteMapProvider : SiteMapProvider
        {
            public override SiteMapNode FindSiteMapNode(string rawUrl) { return null; }
            public override SiteMapNodeCollection GetChildNodes(SiteMapNode node) { return null; }
            public override SiteMapNode GetParentNode(SiteMapNode node) { return null; }
            protected override SiteMapNode GetRootNodeCore() { return null; }
        }

        #endregion
    }
}