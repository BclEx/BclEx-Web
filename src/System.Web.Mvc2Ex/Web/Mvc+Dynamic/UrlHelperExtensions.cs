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
namespace System.Web.Mvc
{
    /// <summary>
    /// UrlHelperExtensions
    /// </summary>
    public static partial class UrlHelperExtensions
    {
        /// <summary>
        /// Actions the ex.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <returns></returns>
        public static string ActionEx(this UrlHelper urlHelper, string actionName) { return GenerateUrlEx(urlHelper, null, actionName, null, null); }
        /// <summary>
        /// Actions the ex.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static string ActionEx(this UrlHelper urlHelper, string actionName, object routeValues) { return GenerateUrlEx(urlHelper, null, actionName, null, new RouteValueDictionary(routeValues)); }
        /// <summary>
        /// Actions the ex.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <returns></returns>
        public static string ActionEx(this UrlHelper urlHelper, string actionName, string controllerName) { return GenerateUrlEx(urlHelper, null, actionName, controllerName, null); }
        /// <summary>
        /// Actions the ex.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static string ActionEx(this UrlHelper urlHelper, string actionName, RouteValueDictionary routeValues) { return GenerateUrlEx(urlHelper, null, actionName, null, routeValues); }
        /// <summary>
        /// Actions the ex.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static string ActionEx(this UrlHelper urlHelper, string actionName, string controllerName, object routeValues) { return GenerateUrlEx(urlHelper, null, actionName, controllerName, new RouteValueDictionary(routeValues)); }
        /// <summary>
        /// Actions the ex.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static string ActionEx(this UrlHelper urlHelper, string actionName, string controllerName, RouteValueDictionary routeValues) { return GenerateUrlEx(urlHelper, null, actionName, controllerName, routeValues); }
        /// <summary>
        /// Actions the ex.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="protocol">The protocol.</param>
        /// <returns></returns>
        public static string ActionEx(this UrlHelper urlHelper, string actionName, string controllerName, object routeValues, string protocol) { IDynamicNode node; return UrlHelperEx.GenerateUrl(out node, null, actionName, controllerName, protocol, null, null, new RouteValueDictionary(routeValues), urlHelper.RouteCollection, urlHelper.RequestContext, true); }
        /// <summary>
        /// Actions the ex.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <returns></returns>
        public static string ActionEx(this UrlHelper urlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, string protocol, string hostName) { IDynamicNode node; return UrlHelperEx.GenerateUrl(out node, null, actionName, controllerName, protocol, hostName, null, routeValues, urlHelper.RouteCollection, urlHelper.RequestContext, true); }

        private static string GenerateUrlEx(UrlHelper urlHelper, string routeName, string actionName, string controllerName, RouteValueDictionary routeValues) { IDynamicNode node; return UrlHelperEx.GenerateUrl(out node, routeName, actionName, controllerName, routeValues, urlHelper.RouteCollection, urlHelper.RequestContext, true); }

        /// <summary>
        /// Routes the URL ex.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static string RouteUrlEx(this UrlHelper urlHelper, object routeValues) { return RouteUrlEx(urlHelper, null, routeValues); }
        /// <summary>
        /// Routes the URL ex.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <returns></returns>
        public static string RouteUrlEx(this UrlHelper urlHelper, string routeName) { return RouteUrlEx(urlHelper, routeName, null); }
        /// <summary>
        /// Routes the URL ex.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static string RouteUrlEx(this UrlHelper urlHelper, RouteValueDictionary routeValues) { return RouteUrlEx(urlHelper, null, routeValues); }
        /// <summary>
        /// Routes the URL ex.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static string RouteUrlEx(this UrlHelper urlHelper, string routeName, object routeValues) { return RouteUrlEx(urlHelper, routeName, routeValues, null); }
        /// <summary>
        /// Routes the URL ex.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static string RouteUrlEx(this UrlHelper urlHelper, string routeName, RouteValueDictionary routeValues) { return RouteUrlEx(urlHelper, routeName, routeValues, null, null); }
        /// <summary>
        /// Routes the URL ex.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="protocol">The protocol.</param>
        /// <returns></returns>
        public static string RouteUrlEx(this UrlHelper urlHelper, string routeName, object routeValues, string protocol) { IDynamicNode node; return UrlHelperEx.GenerateUrl(out node, routeName, null, null, protocol, null, null, new RouteValueDictionary(routeValues), urlHelper.RouteCollection, urlHelper.RequestContext, false); }
        /// <summary>
        /// Routes the URL ex.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <returns></returns>
        public static string RouteUrlEx(this UrlHelper urlHelper, string routeName, RouteValueDictionary routeValues, string protocol, string hostName) { IDynamicNode node; return UrlHelperEx.GenerateUrl(out node, routeName, null, null, protocol, hostName, null, routeValues, urlHelper.RouteCollection, urlHelper.RequestContext, false); }

#if MVC4
        /// <summary>
        /// HTTPs the route URL ex.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static string HttpRouteUrlEx(this UrlHelper urlHelper, string routeName, object routeValues) { return HttpRouteUrlEx(urlHelper, routeName, new RouteValueDictionary(routeValues)); }
        /// <summary>
        /// HTTPs the route URL ex.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static string HttpRouteUrlEx(this UrlHelper urlHelper, string routeName, RouteValueDictionary routeValues)
        {
            if (routeValues == null)
            {
                routeValues = new RouteValueDictionary();
                routeValues.Add("httproute", true);
            }
            else
            {
                routeValues = new RouteValueDictionary(routeValues);
                if (!routeValues.ContainsKey("httproute"))
                    routeValues.Add("httproute", true);
            }
            IDynamicNode node; return UrlHelperEx.GenerateUrl(out node, routeName, null, null, null, null, null, routeValues, urlHelper.RouteCollection, urlHelper.RequestContext, false);
        }
#endif
    }
}
