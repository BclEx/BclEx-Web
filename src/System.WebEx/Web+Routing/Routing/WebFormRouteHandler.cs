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
using System.Web.Compilation;
namespace System.Web.Routing
{
    /// <summary>
    /// WebFormRouteHandler
    /// </summary>
    public class WebFormRouteHandler : IRouteHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebFormRouteHandler"/> class.
        /// </summary>
        /// <param name="virtualPath">The virtual path.</param>
        public WebFormRouteHandler(string virtualPath)
        {
            VirtualPath = virtualPath;
            RequiredBaseType = typeof(IHttpHandler);
        }

        /// <summary>
        /// Gets or sets the virtual path.
        /// </summary>
        /// <value>
        /// The virtual path.
        /// </value>
        public string VirtualPath { get; set; }

        /// <summary>
        /// Gets or sets the type of the required base.
        /// </summary>
        /// <value>
        /// The type of the required base.
        /// </value>
        public Type RequiredBaseType { get; set; }

        /// <summary>
        /// Provides the object that processes the request.
        /// </summary>
        /// <param name="requestContext">An object that encapsulates information about the request.</param>
        /// <returns>
        /// An object that processes the request.
        /// </returns>
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var httpHandler = (VirtualPath != null ? (IHttpHandler)BuildManager.CreateInstanceFromVirtualPath(VirtualPath, RequiredBaseType) : null);
            if (httpHandler != null)
            {
                var routablePage = (httpHandler as IRoutablePage);
                if (routablePage != null)
                    routablePage.RequestContext = requestContext;
            }
            return httpHandler;
        }
    }
}