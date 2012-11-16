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
    /// ControllerExtensions
    /// </summary>
    public static class ControllerExtensions
    {
        /// <summary>
        /// Redirects to action ex.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <returns></returns>
        public static RedirectToRouteResult RedirectToActionEx(this Controller controller, string actionName) { return RedirectToActionEx(controller, actionName, (RouteValueDictionary)null); }
        /// <summary>
        /// Redirects to action ex.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static RedirectToRouteResult RedirectToActionEx(this Controller controller, string actionName, object routeValues) { return RedirectToActionEx(controller, actionName, new RouteValueDictionary(routeValues)); }
        /// <summary>
        /// Redirects to action ex.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <returns></returns>
        public static RedirectToRouteResult RedirectToActionEx(this Controller controller, string actionName, string controllerName) { return RedirectToActionEx(controller, actionName, controllerName, (RouteValueDictionary)null); }
        /// <summary>
        /// Redirects to action ex.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static RedirectToRouteResult RedirectToActionEx(this Controller controller, string actionName, RouteValueDictionary routeValues) { return RedirectToActionEx(controller, actionName, null, routeValues); }
        /// <summary>
        /// Redirects to action ex.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static RedirectToRouteResult RedirectToActionEx(this Controller controller, string actionName, string controllerName, object routeValues) { return RedirectToActionEx(controller, actionName, controllerName, new RouteValueDictionary(routeValues)); }
        /// <summary>
        /// Redirects to action ex.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static RedirectToRouteResult RedirectToActionEx(this Controller controller, string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            RouteValueDictionary dictionary;
            if (controller.RouteData == null)
                dictionary = RouteValuesHelpers.MergeRouteValues(actionName, controllerName, null, routeValues, true);
            else
                dictionary = RouteValuesHelpers.MergeRouteValues(actionName, controllerName, controller.RouteData.Values, routeValues, true);
            return new RedirectToRouteResultEx(dictionary);
        }

        /// <summary>
        /// Redirects to route ex.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static RedirectToRouteResult RedirectToRouteEx(this Controller controller, object routeValues) { return RedirectToRouteEx(controller, new RouteValueDictionary(routeValues)); }
        /// <summary>
        /// Redirects to route ex.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <returns></returns>
        public static RedirectToRouteResult RedirectToRouteEx(this Controller controller, string routeName) { return RedirectToRouteEx(controller, routeName, (RouteValueDictionary)null); }
        /// <summary>
        /// Redirects to route ex.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static RedirectToRouteResult RedirectToRouteEx(this Controller controller, RouteValueDictionary routeValues) { return RedirectToRouteEx(controller, null, routeValues); }
        /// <summary>
        /// Redirects to route ex.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static RedirectToRouteResult RedirectToRouteEx(this Controller controller, string routeName, object routeValues) { return RedirectToRouteEx(controller, routeName, new RouteValueDictionary(routeValues)); }
        /// <summary>
        /// Redirects to route ex.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static RedirectToRouteResult RedirectToRouteEx(this Controller controller, string routeName, RouteValueDictionary routeValues)
        {
            return new RedirectToRouteResultEx(routeName, RouteValuesHelpers.GetRouteValues(routeValues));
        }
    }
}