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
using System.Collections.Generic;
using System.Reflection;
using System.Web.Handlers;
namespace System.Web.UI
{
    /// <summary>
    /// GetWebResourceUrlDelegate
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="resourceName">Name of the resource.</param>
    /// <param name="htmlEncoded">if set to <c>true</c> [HTML encoded].</param>
    /// <returns></returns>
    internal delegate string GetWebResourceUrlDelegate(Type type, string resourceName, bool htmlEncoded);

    /// <summary>
    /// IClientScriptManager
    /// </summary>
    public interface IClientScriptManager
    {
        /// <summary>
        /// Ensures the item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="item">The item.</param>
        void EnsureItem(string id, Func<ClientScriptItemBase> item);
        /// <summary>
        /// Ensures the item.
        /// </summary>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        /// <param name="id">The id.</param>
        /// <param name="item">The item.</param>
        void EnsureItem<TShard>(string id, Func<ClientScriptItemBase> item);
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="item">The item.</param>
        void AddRange(ClientScriptItemBase item);
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="literal">The literal.</param>
        void AddRange(string literal);
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="items">The items.</param>
        void AddRange(params object[] items);
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        /// <param name="item">The item.</param>
        void AddRange<TShard>(ClientScriptItemBase item);
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        /// <param name="literal">The literal.</param>
        void AddRange<TShard>(string literal);
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        /// <param name="items">The items.</param>
        void AddRange<TShard>(params object[] items);
        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        /// <returns></returns>
        IClientScriptRepository GetRepository<TShard>();
        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <param name="shard">The shard.</param>
        /// <returns></returns>
        IClientScriptRepository GetRepository(Type shard);
        /// <summary>
        /// Sets the repository.
        /// </summary>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        /// <param name="repository">The repository.</param>
        void SetRepository<TShard>(IClientScriptRepository repository);
        /// <summary>
        /// Sets the repository.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="repository">The repository.</param>
        void SetRepository(Type type, IClientScriptRepository repository);
    }

    /// <summary>
    /// ClientScriptManagerEx
    /// </summary>
    public class ClientScriptManagerEx : IClientScriptManager
    {
        private static readonly GetWebResourceUrlDelegate _getWebResourceUrl = (GetWebResourceUrlDelegate)Delegate.CreateDelegate(typeof(GetWebResourceUrlDelegate), typeof(AssemblyResourceLoader).GetMethod("GetWebResourceUrl", BindingFlags.NonPublic | BindingFlags.Static, null, new[] { typeof(Type), typeof(string), typeof(bool) }, null));
        private static readonly Type _type = typeof(IClientScriptManager);
        private static readonly Type _htmlHeadType = typeof(System.Web.UI.HtmlControls.HtmlHead);
        private IClientScriptRepository _defaultRepository = new ClientScriptRepository();
        private IClientScriptRepository _htmlHeadRepository = new ClientScriptRepository();
        private Dictionary<Type, IClientScriptRepository> _repositories;

        /// <summary>
        /// Ensures the item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="item">The item.</param>
        public void EnsureItem(string id, Func<ClientScriptItemBase> item) { _defaultRepository.EnsureItem(id, item); }
        /// <summary>
        /// Ensures the item.
        /// </summary>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        /// <param name="id">The id.</param>
        /// <param name="item">The item.</param>
        public void EnsureItem<TShard>(string id, Func<ClientScriptItemBase> item) { GetRepository(typeof(TShard)).EnsureItem(id, item); }
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddRange(ClientScriptItemBase item) { _defaultRepository.AddRange(item); }
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="literal">The literal.</param>
        public void AddRange(string literal) { _defaultRepository.AddRange(literal); }
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="items">The items.</param>
        public void AddRange(params object[] items) { _defaultRepository.AddRange(items); }
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        /// <param name="item">The item.</param>
        public void AddRange<TShard>(ClientScriptItemBase item) { GetRepository(typeof(TShard)).AddRange(item); }
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        /// <param name="literal">The literal.</param>
        public void AddRange<TShard>(string literal) { GetRepository(typeof(TShard)).AddRange(literal); }
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        /// <param name="items">The items.</param>
        public void AddRange<TShard>(params object[] items) { GetRepository(typeof(TShard)).AddRange(items); }

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        /// <returns></returns>
        public IClientScriptRepository GetRepository<TShard>() { return GetRepository(typeof(TShard)); }
        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <param name="shard">The shard.</param>
        /// <returns></returns>
        public IClientScriptRepository GetRepository(Type shard)
        {
            if (shard == _type)
                return _defaultRepository;
            if (shard == _htmlHeadType)
                return _htmlHeadRepository;
            // repositories
            if (_repositories == null)
                _repositories = new Dictionary<Type, IClientScriptRepository>();
            IClientScriptRepository repository;
            if (!_repositories.TryGetValue(shard, out repository))
                _repositories.Add(shard, (repository = new ClientScriptRepository()));
            return repository;
        }
        /// <summary>
        /// Sets the repository.
        /// </summary>
        /// <typeparam name="TShard">The type of the shard.</typeparam>
        /// <param name="repository">The repository.</param>
        public void SetRepository<TShard>(IClientScriptRepository repository) { SetRepository(typeof(TShard), repository); }
        /// <summary>
        /// Sets the repository.
        /// </summary>
        /// <param name="shard">The shard.</param>
        /// <param name="repository">The repository.</param>
        public void SetRepository(Type shard, IClientScriptRepository repository)
        {
            if (shard == _type)
                _defaultRepository = repository;
            if (shard == _htmlHeadType)
                _htmlHeadRepository = repository;
            // repositories
            if (_repositories == null)
                _repositories = new Dictionary<Type, IClientScriptRepository>();
            _repositories[shard] = repository;
        }

        /// <summary>
        /// Gets the web resource URL.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns></returns>
        public static string GetWebResourceUrl(Type type, string resourceName) { return GetWebResourceUrl(type, resourceName, false); }
        /// <summary>
        /// Gets the web resource URL.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="resourceName">Name of the resource.</param>
        /// <param name="htmlEncoded">if set to <c>true</c> [HTML encoded].</param>
        /// <returns></returns>
        public static string GetWebResourceUrl(Type type, string resourceName, bool htmlEncoded)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            if (string.IsNullOrEmpty(resourceName))
                throw new ArgumentNullException("resourceName");
            return _getWebResourceUrl(type, resourceName, htmlEncoded);
        }
    }
}
