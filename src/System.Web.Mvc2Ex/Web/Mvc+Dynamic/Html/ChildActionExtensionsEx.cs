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
using System.IO;
using System.Web.Routing;
using System.Globalization;
namespace System.Web.Mvc.Html
{
    /// <summary>
    /// ChildActionExtensionsEx
    /// </summary>
    public static partial class ChildActionExtensionsEx
    {
        /// <summary>
        /// Actions the ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionEx(this HtmlHelper htmlHelper, string actionName) { return ActionEx(htmlHelper, actionName, null, ((RouteValueDictionary)null)); }
        /// <summary>
        /// Actions the ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
		public static MvcHtmlString ActionEx(this HtmlHelper htmlHelper, string actionName, object routeValues) { return ActionEx(htmlHelper, actionName, null, new RouteValueDictionary(routeValues)); }
        /// <summary>
        /// Actions the ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionEx(this HtmlHelper htmlHelper, string actionName, string controllerName) { return ActionEx(htmlHelper, actionName, controllerName, ((RouteValueDictionary)null)); }
        /// <summary>
        /// Actions the ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
		public static MvcHtmlString ActionEx(this HtmlHelper htmlHelper, string actionName, RouteValueDictionary routeValues) { return ActionEx(htmlHelper, actionName, null, routeValues); }
        /// <summary>
        /// Actions the ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
		public static MvcHtmlString ActionEx(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues) { return ActionEx(htmlHelper, actionName, controllerName, new RouteValueDictionary(routeValues)); }
        /// <summary>
        /// Actions the ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcHtmlString ActionEx(this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            using (var writer = new StringWriter(CultureInfo.CurrentCulture))
            {
                ActionHelper(htmlHelper, actionName, controllerName, routeValues, writer);
                return MvcHtmlString.Create(writer.ToString());
            }
        }

        /// <summary>
        /// Renders the action ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        public static void RenderActionEx(this HtmlHelper htmlHelper, string actionName) { RenderActionEx(htmlHelper, actionName, null, (RouteValueDictionary)null); }
        /// <summary>
        /// Renders the action ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
		public static void RenderActionEx(this HtmlHelper htmlHelper, string actionName, object routeValues) { RenderActionEx(htmlHelper, actionName, null, new RouteValueDictionary(routeValues)); }
        /// <summary>
        /// Renders the action ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        public static void RenderActionEx(this HtmlHelper htmlHelper, string actionName, string controllerName) { RenderActionEx(htmlHelper, actionName, controllerName, (RouteValueDictionary)null); }
        /// <summary>
        /// Renders the action ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        public static void RenderActionEx(this HtmlHelper htmlHelper, string actionName, RouteValueDictionary routeValues) { RenderActionEx(htmlHelper, actionName, null, routeValues); }
        /// <summary>
        /// Renders the action ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
		public static void RenderActionEx(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues) { RenderActionEx(htmlHelper, actionName, controllerName, new RouteValueDictionary(routeValues)); }
        /// <summary>
        /// Renders the action ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        public static void RenderActionEx(this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues)
        {
			ActionHelper(htmlHelper, actionName, controllerName, routeValues, htmlHelper.ViewContext.Writer);
        }
    }
}
