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
using System.Linq;
using System.Collections.Generic;
namespace System.Web.Routing
{
    /// <summary>
    /// DynamicRoute
    /// </summary>
    public class DynamicRoute : Route
    {
        private readonly IDynamicRoutingContext _routingContextAsFixed;
        private Func<DynamicRoute, IDynamicRoutingContext> _routingContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicRoute"/> class.
        /// </summary>
        public DynamicRoute()
            : this(new SiteMapDynamicRoutingContext((ISiteMapProvider)SiteMap.Provider)) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicRoute"/> class.
        /// </summary>
        /// <param name="siteMapProvider">The site map provider.</param>
        public DynamicRoute(ISiteMapProvider siteMapProvider)
            : this(new SiteMapDynamicRoutingContext(siteMapProvider)) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicRoute"/> class.
        /// </summary>
        /// <param name="siteMapProvider">The site map provider.</param>
        public DynamicRoute(SiteMapProvider siteMapProvider)
            : this((ISiteMapProvider)siteMapProvider) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicRoute"/> class.
        /// </summary>
        /// <param name="routingContext">The routing context.</param>
        public DynamicRoute(IDynamicRoutingContext routingContext)
            : base(null, null)
        {
            _routingContextAsFixed = routingContext;
            RoutingContext = (r => _routingContextAsFixed);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicRoute"/> class.
        /// </summary>
        /// <param name="routingContext">The routing context.</param>
        public DynamicRoute(Func<DynamicRoute, IDynamicRoutingContext> routingContext)
            : base(null, null)
        {
            RoutingContext = routingContext;
        }

        /// <summary>
        /// Sets the route defaults.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="node">The node.</param>
        public static void SetRouteDefaults(IEnumerable<Route> routes, IDynamicNode node)
        {
            var id = node.Key;
            foreach (var route in routes)
            {
                route.DataTokens["dynamicID"] = id;
                route.DataTokens["dynamicNode"] = node;
                route.Defaults["dynamicID"] = id;
            }
        }

        /// <summary>
        /// Returns information about the requested route.
        /// </summary>
        /// <param name="httpContext">An object that encapsulates information about the HTTP request.</param>
        /// <returns>
        /// An object that contains the values from the route definition.
        /// </returns>
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            var httpRequest = httpContext.Request;
            // virtualPath modeled from Route::GetRouteData
            var virtualPath = httpRequest.AppRelativeCurrentExecutionFilePath.Substring(1) + httpRequest.PathInfo;
            //var requestUri = _siteMapExRouteContext.GetRequestUri(httpContext);
            var node = GetNode(_routingContext(this), virtualPath);
            if (node != null)
            {
                // func
                var func = node.Get<Func<IDynamicNode, RouteData>>();
                if (func != null)
                    return func(node);
                // single
                var route = node.Get<Route>();
                if (route != null)
                    return route.GetRouteData(httpContext);
                // many
                var multiRoutes = node.GetMany<Route>();
                if (multiRoutes != null)
                    foreach (var multiRoute in multiRoutes)
                    {
                        var data = multiRoute.GetRouteData(httpContext);
                        if (data != null)
                            return data;
                    }
            }
            return null;
        }

        /// <summary>
        /// Returns information about the URL that is associated with the route.
        /// </summary>
        /// <param name="requestContext">An object that encapsulates information about the requested route.</param>
        /// <param name="values">An object that contains the parameters for a route.</param>
        /// <returns>
        /// An object that contains information about the URL that is associated with the route.
        /// </returns>
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            if (requestContext == null)
                throw new ArgumentNullException("requestContext");
            var node = GetNode(_routingContext(this), values, true);
            if (node != null)
            {
                // func
                var func = node.Get<Func<IDynamicNode, VirtualPathData>>();
                if (func != null)
                    return func(node);
                // single
                var route = node.Get<Route>();
                if (route != null)
                    return route.GetVirtualPath(requestContext, values);
                // many
                var multiRoutes = node.GetMany<Route>();
                if (multiRoutes != null)
                    foreach (var multiRoute in multiRoutes)
                    {
                        var path = multiRoute.GetVirtualPath(requestContext, values);
                        if (path != null)
                            return path;
                    }
            }
            return null;
        }

        /// <summary>
        /// Gets or sets the routing context.
        /// </summary>
        /// <value>
        /// The routing context.
        /// </value>
        public Func<DynamicRoute, IDynamicRoutingContext> RoutingContext
        {
            get { return _routingContext; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _routingContext = value;
            }
        }

        private static IDynamicNode GetNode(IDynamicRoutingContext routingContext, string path) { return routingContext.FindNode(path); }
        private static IDynamicNode GetNode(IDynamicRoutingContext routingContext, RouteValueDictionary values, bool removeDynamicID)
        {
            object value;
            string valueAsString;
            if (values.TryGetValue("controller", out value) && (valueAsString = (value as string)) != null && valueAsString.StartsWith("#"))
            {
                var node = routingContext.FindNodeByID(valueAsString.Substring(1));
                if (node != null)
                {
                    values["controller"] = GetControllerNameFromNode(node);
                    if (removeDynamicID)
                        values.Remove("dynamicID");
                }
                return node;
            }
            if (values.TryGetValue("dynamicID", out value) && (valueAsString = (value as string)) != null)
            {
                var node = routingContext.FindNodeByID(valueAsString);
                if (node != null)
                {
                    values["controller"] = GetControllerNameFromNode(node);
                    if (removeDynamicID)
                        values.Remove("dynamicID");
                }
                return node;
            }
            return null;
        }

        private static string GetControllerNameFromNode(IDynamicNode node)
        {
            // func
            var func = node.Get<Func<IDynamicNode, RouteData>>();
            if (func != null)
                throw new InvalidOperationException("Controller name: Func not allowed");
            // single | many
            var route = node.Get<Route>();
            if (route == null)
            {
                var multiRoutes = node.GetMany<Route>();
                if (multiRoutes != null)
                    route = multiRoutes.FirstOrDefault();
            }
            if (route != null)
                return (string)route.Defaults["controller"];
            throw new InvalidOperationException("No controller set for node");
        }
    }
}
