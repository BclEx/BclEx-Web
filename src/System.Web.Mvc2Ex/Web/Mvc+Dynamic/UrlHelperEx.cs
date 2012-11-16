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
using System.Web.Routing;
using System.Globalization;
namespace System.Web.Mvc
{
    /// <summary>
    /// UrlHelperEx
    /// </summary>
    internal static class UrlHelperEx
    {
        /// <summary>
        /// Generates the URL.
        /// </summary>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="routeCollection">The route collection.</param>
        /// <param name="requestContext">The request context.</param>
        /// <param name="includeImplicitMvcValues">if set to <c>true</c> [include implicit MVC values].</param>
        /// <returns></returns>
        public static string GenerateUrl(string routeName, string actionName, string controllerName, RouteValueDictionary routeValues, RouteCollection routeCollection, RequestContext requestContext, bool includeImplicitMvcValues) { IDynamicNode node; return GenerateUrl(out node, routeName, actionName, controllerName, routeValues, routeCollection, requestContext, includeImplicitMvcValues); }
        /// <summary>
        /// Generates the URL.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="routeCollection">The route collection.</param>
        /// <param name="requestContext">The request context.</param>
        /// <param name="includeImplicitMvcValues">if set to <c>true</c> [include implicit MVC values].</param>
        /// <returns></returns>
        public static string GenerateUrl(out IDynamicNode node, string routeName, string actionName, string controllerName, RouteValueDictionary routeValues, RouteCollection routeCollection, RequestContext requestContext, bool includeImplicitMvcValues)
        {
            if (routeCollection == null)
                throw new ArgumentNullException("routeCollection");
            if (requestContext == null)
                throw new ArgumentNullException("requestContext");
            var values = RouteValuesHelpers.MergeRouteValues(actionName, controllerName, requestContext.RouteData.Values, routeValues, includeImplicitMvcValues);
            var data = routeCollection.GetVirtualPathForArea(requestContext, routeName, values);
            if (data == null)
            {
                node = null;
                return null;
            }
            node = (IDynamicNode)data.DataTokens["dynamicNode"];
            return PathHelpers.GenerateClientUrl(requestContext.HttpContext, data.VirtualPath);
        }

        /// <summary>
        /// Generates the URL.
        /// </summary>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <param name="fragment">The fragment.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="routeCollection">The route collection.</param>
        /// <param name="requestContext">The request context.</param>
        /// <param name="includeImplicitMvcValues">if set to <c>true</c> [include implicit MVC values].</param>
        /// <returns></returns>
        public static string GenerateUrl(string routeName, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, RouteCollection routeCollection, RequestContext requestContext, bool includeImplicitMvcValues) { IDynamicNode node; return GenerateUrl(out node, routeName, actionName, controllerName, protocol, hostName, fragment, routeValues, routeCollection, requestContext, includeImplicitMvcValues); }
        /// <summary>
        /// Generates the URL.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <param name="fragment">The fragment.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="routeCollection">The route collection.</param>
        /// <param name="requestContext">The request context.</param>
        /// <param name="includeImplicitMvcValues">if set to <c>true</c> [include implicit MVC values].</param>
        /// <returns></returns>
        public static string GenerateUrl(out IDynamicNode node, string routeName, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, RouteCollection routeCollection, RequestContext requestContext, bool includeImplicitMvcValues)
        {
            var dynamicUrl = GenerateUrl(out node, routeName, actionName, controllerName, routeValues, routeCollection, requestContext, includeImplicitMvcValues);
            if (dynamicUrl == null)
                return dynamicUrl;
            if (!string.IsNullOrEmpty(fragment))
                dynamicUrl = dynamicUrl + "#" + fragment;
            if (string.IsNullOrEmpty(protocol) && string.IsNullOrEmpty(hostName))
                return dynamicUrl;
            var url = requestContext.HttpContext.Request.Url;
            protocol = (!string.IsNullOrEmpty(protocol) ? protocol : Uri.UriSchemeHttp);
            hostName = (!string.IsNullOrEmpty(hostName) ? hostName : url.Host);
            var port = string.Empty;
            var scheme = url.Scheme;
            if (string.Equals(protocol, scheme, StringComparison.OrdinalIgnoreCase))
                port = (url.IsDefaultPort ? string.Empty : (":" + Convert.ToString(url.Port, CultureInfo.InvariantCulture)));
            return (protocol + Uri.SchemeDelimiter + hostName + port + dynamicUrl);
        }
    }
}
