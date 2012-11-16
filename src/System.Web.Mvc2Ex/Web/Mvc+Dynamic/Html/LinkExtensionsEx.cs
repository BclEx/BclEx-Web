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
namespace System.Web.Mvc.Html
{
    /// <summary>
    /// LinkExtensionsEx
    /// </summary>
    public static class LinkExtensionsEx
    {
        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string actionName) { return ActionLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, actionName, null, new RouteValueDictionary(), new RouteValueDictionary()); }
        //public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string linkText, string actionName) { return ActionLinkEx(htmlHelper, x => linkText, actionName, null, new RouteValueDictionary(), new RouteValueDictionary()); }
        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, string actionName) { return ActionLinkEx(htmlHelper, linkText, actionName, null, new RouteValueDictionary(), new RouteValueDictionary()); }

        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string actionName, object routeValues) { return ActionLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, actionName, null, new RouteValueDictionary(routeValues), new RouteValueDictionary()); }
        //public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues) { return ActionLinkEx(htmlHelper, x => linkText, actionName, null, new RouteValueDictionary(routeValues), new RouteValueDictionary()); }
        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, string actionName, object routeValues) { return ActionLinkEx(htmlHelper, linkText, actionName, null, new RouteValueDictionary(routeValues), new RouteValueDictionary()); }

        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string actionName, string controllerName) { return ActionLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, actionName, controllerName, new RouteValueDictionary(), new RouteValueDictionary()); }
        //public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName) { return ActionLinkEx(htmlHelper, x => linkText, actionName, controllerName, new RouteValueDictionary(), new RouteValueDictionary()); }
        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, string actionName, string controllerName) { return ActionLinkEx(htmlHelper, linkText, actionName, controllerName, new RouteValueDictionary(), new RouteValueDictionary()); }

        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string actionName, RouteValueDictionary routeValues) { return ActionLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, actionName, null, routeValues, new RouteValueDictionary()); }
        //public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues) { return ActionLinkEx(htmlHelper, x => linkText, actionName, null, routeValues, new RouteValueDictionary()); }
        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, string actionName, RouteValueDictionary routeValues) { return ActionLinkEx(htmlHelper, linkText, actionName, null, routeValues, new RouteValueDictionary()); }

        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string actionName, object routeValues, object htmlAttributes) { return ActionLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, actionName, null, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes)); }
        //public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues, object htmlAttributes) { return ActionLinkEx(htmlHelper, x => linkText, actionName, null, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes)); }
        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, string actionName, object routeValues, object htmlAttributes) { return ActionLinkEx(htmlHelper, linkText, actionName, null, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes)); }

        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string actionName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) { return ActionLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, actionName, null, routeValues, htmlAttributes); }
        //public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) { return ActionLinkEx(htmlHelper, x => linkText, actionName, null, routeValues, htmlAttributes); }
        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, string actionName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) { return ActionLinkEx(htmlHelper, linkText, actionName, null, routeValues, htmlAttributes); }

        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, object htmlAttributes) { return ActionLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, actionName, controllerName, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes)); }
        //public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes) { return ActionLinkEx(htmlHelper, x => linkText, actionName, controllerName, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes)); }
        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, string actionName, string controllerName, object routeValues, object htmlAttributes) { return ActionLinkEx(htmlHelper, linkText, actionName, controllerName, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes)); }

        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) { return ActionLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, actionName, controllerName, routeValues, htmlAttributes); }
        //public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) { return ActionLinkEx(htmlHelper, x => linkText, actionName, controllerName, routeValues, htmlAttributes); }
        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return MvcHtmlString.Create(HtmlHelperEx.GenerateLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, linkText, null, actionName, controllerName, routeValues, htmlAttributes));
        }

        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <param name="fragment">The fragment.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes) { return ActionLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, actionName, controllerName, protocol, hostName, fragment, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes)); }
        //public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes) { return ActionLinkEx(htmlHelper, x => linkText, actionName, controllerName, protocol, hostName, fragment, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes)); }
        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <param name="fragment">The fragment.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes) { return ActionLinkEx(htmlHelper, linkText, actionName, controllerName, protocol, hostName, fragment, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes)); }

        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <param name="fragment">The fragment.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) { return ActionLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, actionName, controllerName, protocol, hostName, fragment, routeValues, htmlAttributes); }
        //public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) { return ActionLinkEx(htmlHelper, x => linkText, actionName, controllerName, protocol, hostName, fragment, routeValues, htmlAttributes); }
        /// <summary>
        /// Actions the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <param name="fragment">The fragment.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return MvcHtmlString.Create(HtmlHelperEx.GenerateLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, linkText, null, actionName, controllerName, protocol, hostName, fragment, routeValues, htmlAttributes));
        }

        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, object routeValues) { return RouteLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, new RouteValueDictionary(routeValues)); }
        //public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, string linkText, object routeValues) { return RouteLinkEx(htmlHelper, x => linkText, new RouteValueDictionary(routeValues)); }
        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, object routeValues) { return RouteLinkEx(htmlHelper, linkText, new RouteValueDictionary(routeValues)); }

        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, string routeName) { return RouteLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, routeName, null); }
        //public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, string linkText, string routeName) { return RouteLinkEx(htmlHelper, x => linkText, routeName, null); }
        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, string routeName) { return RouteLinkEx(htmlHelper, linkText, routeName, null); }

        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, RouteValueDictionary routeValues) { return RouteLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, routeValues, new RouteValueDictionary()); }
        //public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, string linkText, RouteValueDictionary routeValues) { return RouteLinkEx(htmlHelper, x => linkText, routeValues, new RouteValueDictionary()); }
        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, RouteValueDictionary routeValues) { return RouteLinkEx(htmlHelper, linkText, routeValues, new RouteValueDictionary()); }

        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, object routeValues, object htmlAttributes) { return RouteLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes)); }
        //public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, string linkText, object routeValues, object htmlAttributes) { return RouteLinkEx(htmlHelper, x => linkText, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes)); }
        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, object routeValues, object htmlAttributes) { return RouteLinkEx(htmlHelper, linkText, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes)); }

        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, string routeName, object routeValues) { return RouteLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, routeName, new RouteValueDictionary(routeValues)); }
        //public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, string linkText, string routeName, object routeValues) { return RouteLinkEx(htmlHelper, x => linkText, routeName, new RouteValueDictionary(routeValues)); }
        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, string routeName, object routeValues) { return RouteLinkEx(htmlHelper, linkText, routeName, new RouteValueDictionary(routeValues)); }

        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, string routeName, RouteValueDictionary routeValues) { return RouteLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, routeName, routeValues, new RouteValueDictionary()); }
        //public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, string linkText, string routeName, RouteValueDictionary routeValues) { return RouteLinkEx(htmlHelper, x => linkText, routeName, routeValues, new RouteValueDictionary()); }
        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, string routeName, RouteValueDictionary routeValues) { return RouteLinkEx(htmlHelper, linkText, routeName, routeValues, new RouteValueDictionary()); }

        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) { return RouteLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, null, routeValues, htmlAttributes); }
        //public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, string linkText, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) { return RouteLinkEx(htmlHelper, x => linkText, null, routeValues, htmlAttributes); }
        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) { return RouteLinkEx(htmlHelper, linkText, null, routeValues, htmlAttributes); }

        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, string routeName, object routeValues, object htmlAttributes) { return RouteLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, routeName, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes)); }
        //public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, string linkText, string routeName, object routeValues, object htmlAttributes) { return RouteLinkEx(htmlHelper, x => linkText, routeName, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes)); }
        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, string routeName, object routeValues, object htmlAttributes) { return RouteLinkEx(htmlHelper, linkText, routeName, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes)); }

        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, string routeName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) { return RouteLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, routeName, routeValues, htmlAttributes); }
        //public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, string linkText, string routeName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) { return RouteLinkEx(htmlHelper, x => linkText, routeName, routeValues, htmlAttributes); }
        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, string routeName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return MvcHtmlString.Create(HtmlHelperEx.GenerateRouteLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, linkText, routeName, routeValues, htmlAttributes));
        }

        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <param name="fragment">The fragment.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, string routeName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes) { return RouteLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, routeName, protocol, hostName, fragment, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes)); }
        //public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, string linkText, string routeName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes) { return RouteLinkEx(htmlHelper, x => linkText, routeName, protocol, hostName, fragment, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes)); }
        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <param name="fragment">The fragment.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, string routeName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes) { return RouteLinkEx(htmlHelper, linkText, routeName, protocol, hostName, fragment, new RouteValueDictionary(routeValues), new RouteValueDictionary(htmlAttributes)); }

        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <param name="fragment">The fragment.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, string routeName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) { return RouteLinkEx(htmlHelper, (Func<IDynamicNode, string>)null, routeName, protocol, hostName, fragment, routeValues, htmlAttributes); }
        //public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, string linkText, string routeName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes) { return RouteLinkEx(htmlHelper, x => linkText, routeName, protocol, hostName, fragment, routeValues, htmlAttributes); }
        /// <summary>
        /// Routes the link ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <param name="fragment">The fragment.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RouteLinkEx(this HtmlHelper htmlHelper, Func<IDynamicNode, string> linkText, string routeName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return MvcHtmlString.Create(HtmlHelperEx.GenerateRouteLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, linkText, routeName, protocol, hostName, fragment, routeValues, htmlAttributes));
        }
    }
}
