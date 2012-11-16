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
namespace System.Web.Routing
{
    /// <summary>
    /// RouteEx
    /// </summary>
    public class RouteEx : Route
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteEx"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="routeHandler">The route handler.</param>
        public RouteEx(string url, IRouteHandler routeHandler)
            : base(url, routeHandler) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteEx"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="defaults">The defaults.</param>
        /// <param name="routeHandler">The route handler.</param>
        public RouteEx(string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
            : base(url, defaults, routeHandler) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteEx"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="defaults">The defaults.</param>
        /// <param name="constraints">The constraints.</param>
        /// <param name="routeHandler">The route handler.</param>
        public RouteEx(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler)
            : base(url, defaults, constraints, routeHandler) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteEx"/> class.
        /// </summary>
        /// <param name="url">The URL pattern for the route.</param>
        /// <param name="defaults">The values to use if the URL does not contain all the parameters.</param>
        /// <param name="constraints">A regular expression that specifies valid values for a URL parameter.</param>
        /// <param name="dataTokens">Custom values that are passed to the route handler, but which are not used to determine whether the route matches a specific URL pattern. These values are passed to the route handler, where they can be used for processing the request.</param>
        /// <param name="routeHandler">The object that processes requests for the route.</param>
        public RouteEx(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler)
            : base(url, defaults, constraints, dataTokens, routeHandler) { }

        //public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        //{
        //    UriContextBase uriContext;
        //    var data = base.GetVirtualPath(requestContext, values);
        //    if (data == null || (uriContext = requestContext.HttpContext.Get<UriContextBase>()) == null)
        //        return data;
        //    var param = (data.DataTokens["VirtualPathAttrib"] as Nparam);
        //    data.VirtualPath = uriContext.CreateVirtualPath(data.VirtualPath, param);
        //    return data;
        //}
    }
}