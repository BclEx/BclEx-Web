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
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Routing;
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

        #region Action Executor

        private static readonly MethodInfo _wrapForServerExecuteMethod = Type.GetType("System.Web.Mvc.HttpHandlerUtil, " + AssemblyRef.SystemWebMvc).GetMethod("WrapForServerExecute");

        internal static void ActionHelper(HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, TextWriter textWriter)
        {
            if (htmlHelper == null)
                throw new ArgumentNullException("htmlHelper");
            if (string.IsNullOrEmpty(actionName))
                throw new ArgumentException("Common_NullOrEmpty", "actionName");
            var dictionary = routeValues;
            routeValues = MergeDictionaries(new[] { routeValues, htmlHelper.ViewContext.RouteData.Values });
            routeValues["action"] = actionName;
            if (!string.IsNullOrEmpty(controllerName))
                routeValues["controller"] = controllerName;
            var flag = false;
            // TODO: return out flag
            var data = htmlHelper.RouteCollection.GetVirtualPathForArea(htmlHelper.ViewContext.RequestContext, null, routeValues); // out flag);
            if (data == null)
                throw new InvalidOperationException("Common_NoRouteMatched");
#if !MVC2
            if (flag)
            {
                routeValues.Remove("area");
                if (dictionary != null)
                    dictionary.Remove("area");
                // TODO: get ChildActionValuesKey from internal
                //if (dictionary != null)
                //    routeValues[ChildActionValueProvider.ChildActionValuesKey] = new DictionaryValueProvider<object>(dictionary, CultureInfo.InvariantCulture);
            }
#else
            if (flag)
                routeValues.Remove("area");
#endif
            var routeData = CreateRouteData(data.Route, routeValues, data.DataTokens, htmlHelper.ViewContext);
            var httpContext = htmlHelper.ViewContext.HttpContext;
            var context = new RequestContext(httpContext, routeData);
            var httpHandler = new ChildActionMvcHandler(context);
            httpContext.Server.Execute((IHttpHandler)_wrapForServerExecuteMethod.Invoke(null, new object[] { httpHandler }), textWriter, true);
        }

        private static RouteData CreateRouteData(RouteBase route, RouteValueDictionary routeValues, RouteValueDictionary dataTokens, ViewContext parentViewContext)
        {
            var data = new RouteData();
            foreach (KeyValuePair<string, object> pair in routeValues)
                data.Values.Add(pair.Key, pair.Value);
            foreach (KeyValuePair<string, object> pair2 in dataTokens)
                data.DataTokens.Add(pair2.Key, pair2.Value);
            data.Route = route;
            data.DataTokens["ParentActionViewContext"] = parentViewContext;
            return data;
        }

        private static RouteValueDictionary MergeDictionaries(params RouteValueDictionary[] dictionaries)
        {
            var dictionary = new RouteValueDictionary();
            foreach (var dictionary2 in dictionaries.Where(d => d != null))
                foreach (var pair in dictionary2)
                    if (!dictionary.ContainsKey(pair.Key))
                        dictionary.Add(pair.Key, pair.Value);
            return dictionary;
        }

        internal class ChildActionMvcHandler : MvcHandler
        {
            public ChildActionMvcHandler(RequestContext context)
                : base(context) { }
            protected override void AddVersionHeader(HttpContextBase httpContext) { }
        }

        #endregion
    }
}
