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
    /// RedirectToRouteResultEx
    /// </summary>
    public class RedirectToRouteResultEx : RedirectToRouteResult
    {
        private RouteCollection _routes;

        /// <summary>
        /// Initializes a new instance of the <see cref="RedirectToRouteResultEx"/> class.
        /// </summary>
        /// <param name="routeValues">The route values.</param>
        public RedirectToRouteResultEx(RouteValueDictionary routeValues)
            : base(null, routeValues) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RedirectToRouteResultEx"/> class.
        /// </summary>
        /// <param name="routeName">The name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        public RedirectToRouteResultEx(string routeName, RouteValueDictionary routeValues)
            : base(routeName, routeValues) { }
#if MVC3
        /// <summary>
        /// Initializes a new instance of the <see cref="RedirectToRouteResultEx"/> class.
        /// </summary>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="permanent">if set to <c>true</c> [permanent].</param>
        public RedirectToRouteResultEx(string routeName, RouteValueDictionary routeValues, bool permanent)
            : base(routeName, routeValues, permanent) { }
#endif

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult"/> class.
        /// </summary>
        /// <param name="context">The context within which the result is executed.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="context"/> parameter is null.</exception>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (context.IsChildAction)
                throw new InvalidOperationException("MvcResources.RedirectAction_CannotRedirectInChildAction");
            IDynamicNode node;
            var value = UrlHelperEx.GenerateUrl(out node, RouteName, null, null, RouteValues, Routes, context.RequestContext, false);
            if (string.IsNullOrEmpty(value))
                throw new InvalidOperationException("MvcResources.Common_NoRouteMatched");
            context.Controller.TempData.Keep();
#if MVC3
            if (Permanent)
                context.HttpContext.Response.RedirectPermanent(value, false);
            else
                context.HttpContext.Response.Redirect(value, false);
#else
            context.HttpContext.Response.Redirect(value, false);
#endif
        }

        internal RouteCollection Routes
        {
            get
            {
                if (_routes == null)
                    _routes = RouteTable.Routes;
                return _routes;
            }
            set { _routes = value; }
        }
    }
}