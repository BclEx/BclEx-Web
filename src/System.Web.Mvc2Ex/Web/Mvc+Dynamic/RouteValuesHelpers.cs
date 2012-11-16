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
    /// RouteValuesHelpers
    /// </summary>
    internal static class RouteValuesHelpers
    {
        /// <summary>
        /// Gets the route values.
        /// </summary>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static RouteValueDictionary GetRouteValues(RouteValueDictionary routeValues)
        {
            if (routeValues == null)
                return new RouteValueDictionary();
            return new RouteValueDictionary(routeValues);
        }

        /// <summary>
        /// Merges the route values.
        /// </summary>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="implicitRouteValues">The implicit route values.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="includeImplicitMvcValues">if set to <c>true</c> [include implicit MVC values].</param>
        /// <returns></returns>
        public static RouteValueDictionary MergeRouteValues(string actionName, string controllerName, RouteValueDictionary implicitRouteValues, RouteValueDictionary routeValues, bool includeImplicitMvcValues)
        {
            var dictionary = new RouteValueDictionary();
            if (includeImplicitMvcValues)
            {
                object value;
                if (implicitRouteValues != null && implicitRouteValues.TryGetValue("action", out value))
                    dictionary["action"] = value;
                if (implicitRouteValues != null && implicitRouteValues.TryGetValue("controller", out value))
                    dictionary["controller"] = value;
                if (implicitRouteValues != null && implicitRouteValues.TryGetValue("dynamicID", out value))
                    dictionary["dynamicID"] = value;
            }
            if (routeValues != null)
                foreach (var pair in GetRouteValues(routeValues))
                    dictionary[pair.Key] = pair.Value;
            if (actionName != null)
                dictionary["action"] = actionName;
            if (controllerName != null)
                dictionary["controller"] = controllerName;
            return dictionary;
        }
    }
}