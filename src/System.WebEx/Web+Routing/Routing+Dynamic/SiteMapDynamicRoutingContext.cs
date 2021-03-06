﻿#region License
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
namespace System.Web.Routing
{
    /// <summary>
    /// SiteMapDynamicRoutingContext
    /// </summary>
    public class SiteMapDynamicRoutingContext : IDynamicRoutingContext
    {
        private readonly ISiteMapProvider _siteMapProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteMapDynamicRoutingContext"/> class.
        /// </summary>
        /// <param name="siteMapProvider">The site map provider.</param>
        public SiteMapDynamicRoutingContext(ISiteMapProvider siteMapProvider)
        {
            if (siteMapProvider == null)
                throw new ArgumentNullException("siteMapProvider");
            _siteMapProvider = siteMapProvider;
        }

        /// <summary>
        /// Finds the node.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public IDynamicNode FindNode(string path)
        {
            return (_siteMapProvider.FindSiteMapNode<SiteMapNode>(path) as IDynamicNode);
        }
        /// <summary>
        /// Finds the node by ID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public IDynamicNode FindNodeByID(string id)
        {
            return (_siteMapProvider.FindSiteMapNodeFromKey<SiteMapNode>(id) as IDynamicNode);
        }

        #region UriScheme

        //    public UriSchema UriSchema { get; set; }
        //    private UriContext RequestUriContext { get; set; }

        //    public Uri GetRequestUri(HttpContextBase httpContext)
        //    {
        //        RequestUriContext = UriSchema.ParseUri(httpContext.Request);
        //        return RequestUriContext.Uri;
        //    }

        /// <summary>
        /// Gets the request.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns></returns>
        public Uri GetRequest(HttpContextBase httpContext)
        {
            return httpContext.Request.Url; // httpContext.ParseRequestUri().Uri;
        }

        #endregion
    }
}
