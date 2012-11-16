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
using System.Web;
namespace Contoso.Web.Integrate
{
    /// <summary>
    /// GoogleSiteMapHandler
    /// </summary>
    public abstract class GoogleSiteMapHandler : IObservable<GoogleSiteMapNode>, IHttpHandler
    {
        private string _baseUrl;
        private SiteMapNode _rootNode;

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleSiteMapHandler"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        public GoogleSiteMapHandler(string baseUrl)
            : this(baseUrl, SiteMap.RootNode) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleSiteMapHandler"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="rootNode">The root node.</param>
        public GoogleSiteMapHandler(string baseUrl, SiteMapNode rootNode)
        {
            _baseUrl = baseUrl;
            _rootNode = rootNode;
            ContentType = "text/xml";
        }

        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler"/> interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext"/> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
        public void ProcessRequest(HttpContext context)
        {
            var r = context.Response;
            if (!string.IsNullOrEmpty(ContentType))
                r.ContentType = ContentType;
            Subscribe(new GoogleSiteMapObserver(r.Output));
        }

        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>
        /// The type of the content.
        /// </value>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler"/> instance.
        /// </summary>
        /// <returns>true if the <see cref="T:System.Web.IHttpHandler"/> instance is reusable; otherwise, false.
        ///   </returns>
        public bool IsReusable
        {
            get { return true; }
        }

        /// <summary>
        /// Subscribes the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <returns></returns>
        public IDisposable Subscribe(IObserver<GoogleSiteMapNode> observer)
        {
            if (observer == null)
                throw new ArgumentNullException("observer");
            try
            {
                AddSiteMapNode(observer, _baseUrl, _rootNode);
                observer.OnCompleted();
            }
            catch (Exception ex) { observer.OnError(ex); }
            return null;
        }

        /// <summary>
        /// Adds the site map node.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="node">The node.</param>
        protected virtual void AddSiteMapNode(IObserver<GoogleSiteMapNode> observer, string baseUrl, SiteMapNode node)
        {
            observer.OnNext(CreateSiteMapNode(baseUrl, node));
            foreach (SiteMapNode childNode in node.ChildNodes)
                AddSiteMapNode(observer, baseUrl, childNode);
        }

        /// <summary>
        /// Creates the site map node.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        protected abstract GoogleSiteMapNode CreateSiteMapNode(string baseUrl, SiteMapNode node);
    }
}