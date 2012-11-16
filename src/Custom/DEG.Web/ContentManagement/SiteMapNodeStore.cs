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
using System.Collections.Specialized;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Threading;
using System.Web;
namespace DEG.ContentManagement
{
    /// <summary>
    /// SiteMapNodeStore
    /// </summary>
    /// <typeparam name="TRouteCreator">The type of the route creator.</typeparam>
    public partial class SiteMapNodeStore<TRouteCreator> : IStaticSiteMapProviderExNodeStore
        where TRouteCreator : ISiteMapNodeStoreRouteCreator, new()
    {
        private string _connect;
        private int _connectShard;
        private StaticSiteMapProviderEx _provider;

        /// <summary>
        /// Initializes the specified provider.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="rwLock">The rw lock.</param>
        /// <param name="config">The config.</param>
        public virtual void Initialize(StaticSiteMapProviderEx provider, ReaderWriterLockSlim rwLock, NameValueCollection config)
        {
            _provider = provider;
            // connectionStringName
            var connect = config["connectionStringName"];
            if (string.IsNullOrEmpty(connect))
                throw new ProviderException("Empty or missing connectionStringName");
            config.Remove("connectionStringName");
            if (WebConfigurationManager.ConnectionStrings[connect] == null)
                throw new ProviderException("Missing connection string");
            _connect = WebConfigurationManager.ConnectionStrings[connect].ConnectionString;
            if (string.IsNullOrEmpty(_connect))
                throw new ProviderException("Empty connection string");
            //
            var connectShard = config["contentShard"];
            config.Remove("contentShard");
            _connectShard = (string.IsNullOrEmpty(connectShard) ? 1 : int.Parse(connectShard));
            //
            //if (config.Count > 0)
            //{
            //    var attr = config.GetKey(0);
            //    if (!string.IsNullOrEmpty(attr))
            //        throw new ProviderException("Unrecognized attribute: " + attr);
            //}
        }

        /// <summary>
        /// Creates the observable.
        /// </summary>
        /// <returns></returns>
        public virtual StaticSiteMapProviderEx.ObservableBase CreateObservable() { return new Observable(this); }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear() { }
    }
}
