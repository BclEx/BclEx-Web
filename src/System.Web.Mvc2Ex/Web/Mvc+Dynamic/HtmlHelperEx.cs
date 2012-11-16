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
using System.Collections.Generic;
namespace System.Web.Mvc
{
    /// <summary>
    /// HtmlHelperEx
    /// </summary>
    internal class HtmlHelperEx
    {
        /// <summary>
        /// Generates the link.
        /// </summary>
        /// <param name="requestContext">The request context.</param>
        /// <param name="routeCollection">The route collection.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static string GenerateLink(RequestContext requestContext, RouteCollection routeCollection, Func<IDynamicNode, string> linkText, string routeName, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) { return GenerateLink(requestContext, routeCollection, linkText, routeName, actionName, controllerName, null, null, null, routeValues, htmlAttributes); }
        /// <summary>
        /// Generates the link.
        /// </summary>
        /// <param name="requestContext">The request context.</param>
        /// <param name="routeCollection">The route collection.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <param name="fragment">The fragment.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static string GenerateLink(RequestContext requestContext, RouteCollection routeCollection, Func<IDynamicNode, string> linkText, string routeName, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) { return GenerateLinkInternal(requestContext, routeCollection, linkText, routeName, actionName, controllerName, protocol, hostName, fragment, routeValues, htmlAttributes, true); }
        private static string GenerateLinkInternal(RequestContext requestContext, RouteCollection routeCollection, Func<IDynamicNode, string> linkText, string routeName, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes, bool includeImplicitMvcValues)
        {
            IDynamicNode node;
            var text = UrlHelperEx.GenerateUrl(out node, routeName, actionName, controllerName, protocol, hostName, fragment, routeValues, routeCollection, requestContext, includeImplicitMvcValues);
            if (node == null)
                throw new InvalidOperationException("!Node");
            var nodeAsLinkText = (linkText == null ? node.Title : linkText(node));
            var b = new TagBuilder("a");
            b.InnerHtml = (!string.IsNullOrEmpty(nodeAsLinkText) ? HttpUtility.HtmlEncode(nodeAsLinkText) : string.Empty);
            b.MergeAttributes<string, object>(htmlAttributes);
            b.MergeAttribute("href", text);
            return b.ToString(TagRenderMode.Normal);
        }
        /// <summary>
        /// Generates the route link.
        /// </summary>
        /// <param name="requestContext">The request context.</param>
        /// <param name="routeCollection">The route collection.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static string GenerateRouteLink(RequestContext requestContext, RouteCollection routeCollection, Func<IDynamicNode, string> linkText, string routeName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) { return GenerateRouteLink(requestContext, routeCollection, linkText, routeName, null, null, null, routeValues, htmlAttributes); }
        /// <summary>
        /// Generates the route link.
        /// </summary>
        /// <param name="requestContext">The request context.</param>
        /// <param name="routeCollection">The route collection.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <param name="fragment">The fragment.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static string GenerateRouteLink(RequestContext requestContext, RouteCollection routeCollection, Func<IDynamicNode, string> linkText, string routeName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) { return GenerateLinkInternal(requestContext, routeCollection, linkText, routeName, null, null, protocol, hostName, fragment, routeValues, htmlAttributes, false); }
    }
}