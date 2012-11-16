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
using System.Reflection;
namespace System.Web.Mvc.Html
{
    /// <summary>
    /// FormExtensionsEx
    /// </summary>
    public static class FormExtensionsEx
    {
        private static readonly PropertyInfo _formIdGeneratorPropertyInfo = typeof(ViewContext).GetProperty("FormIdGenerator", BindingFlags.NonPublic | BindingFlags.Instance);

        /// <summary>
        /// Begins the form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <returns></returns>
        public static MvcForm BeginFormEx(this HtmlHelper htmlHelper)
        {
            var rawUrl = htmlHelper.ViewContext.HttpContext.Request.RawUrl;
            return FormHelper(htmlHelper, rawUrl, FormMethod.Post, new RouteValueDictionary());
        }

        /// <summary>
        /// Begins the form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcForm BeginFormEx(this HtmlHelper htmlHelper, object routeValues) { return BeginFormEx(htmlHelper, null, null, new RouteValueDictionary(routeValues), FormMethod.Post, new RouteValueDictionary()); }
        /// <summary>
        /// Begins the form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcForm BeginFormEx(this HtmlHelper htmlHelper, RouteValueDictionary routeValues) { return BeginFormEx(htmlHelper, null, null, routeValues, FormMethod.Post, new RouteValueDictionary()); }
        /// <summary>
        /// Begins the form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <returns></returns>
        public static MvcForm BeginFormEx(this HtmlHelper htmlHelper, string actionName, string controllerName) { return BeginFormEx(htmlHelper, actionName, controllerName, new RouteValueDictionary(), FormMethod.Post, new RouteValueDictionary()); }
        /// <summary>
        /// Begins the form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcForm BeginFormEx(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues) { return BeginFormEx(htmlHelper, actionName, controllerName, new RouteValueDictionary(routeValues), FormMethod.Post, new RouteValueDictionary()); }
        /// <summary>
        /// Begins the form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        public static MvcForm BeginFormEx(this HtmlHelper htmlHelper, string actionName, string controllerName, FormMethod method) { return BeginFormEx(htmlHelper, actionName, controllerName, new RouteValueDictionary(), method, new RouteValueDictionary()); }
        /// <summary>
        /// Begins the form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcForm BeginFormEx(this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues) { return BeginFormEx(htmlHelper, actionName, controllerName, routeValues, FormMethod.Post, new RouteValueDictionary()); }
        /// <summary>
        /// Begins the form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        public static MvcForm BeginFormEx(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, FormMethod method) { return BeginFormEx(htmlHelper, actionName, controllerName, new RouteValueDictionary(routeValues), method, new RouteValueDictionary()); }
        /// <summary>
        /// Begins the form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="method">The method.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcForm BeginFormEx(this HtmlHelper htmlHelper, string actionName, string controllerName, FormMethod method, IDictionary<string, object> htmlAttributes) { return BeginFormEx(htmlHelper, actionName, controllerName, new RouteValueDictionary(), method, htmlAttributes); }
        /// <summary>
        /// Begins the form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="method">The method.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcForm BeginFormEx(this HtmlHelper htmlHelper, string actionName, string controllerName, FormMethod method, object htmlAttributes) { return BeginFormEx(htmlHelper, actionName, controllerName, new RouteValueDictionary(), method, new RouteValueDictionary(htmlAttributes)); }
        /// <summary>
        /// Begins the form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        public static MvcForm BeginFormEx(this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, FormMethod method) { return BeginFormEx(htmlHelper, actionName, controllerName, routeValues, method, new RouteValueDictionary()); }
        /// <summary>
        /// Begins the form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="method">The method.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcForm BeginFormEx(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, FormMethod method, object htmlAttributes) { return BeginFormEx(htmlHelper, actionName, controllerName, new RouteValueDictionary(routeValues), method, new RouteValueDictionary(htmlAttributes)); }
        /// <summary>
        /// Begins the form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="method">The method.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcForm BeginFormEx(this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, FormMethod method, IDictionary<string, object> htmlAttributes)
        {
            IDynamicNode node;
            var formAction = UrlHelperEx.GenerateUrl(out node, null, actionName, controllerName, routeValues, htmlHelper.RouteCollection, htmlHelper.ViewContext.RequestContext, true);
            return FormHelper(htmlHelper, formAction, method, htmlAttributes);
        }

        /// <summary>
        /// Begins the route form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcForm BeginRouteFormEx(this HtmlHelper htmlHelper, object routeValues) { return BeginRouteFormEx(htmlHelper, null, new RouteValueDictionary(routeValues), FormMethod.Post, new RouteValueDictionary()); }
        /// <summary>
        /// Begins the route form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <returns></returns>
        public static MvcForm BeginRouteFormEx(this HtmlHelper htmlHelper, string routeName) { return BeginRouteFormEx(htmlHelper, routeName, new RouteValueDictionary(), FormMethod.Post, new RouteValueDictionary()); }
        /// <summary>
        /// Begins the route form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcForm BeginRouteFormEx(this HtmlHelper htmlHelper, RouteValueDictionary routeValues) { return BeginRouteFormEx(htmlHelper, null, routeValues, FormMethod.Post, new RouteValueDictionary()); }
        /// <summary>
        /// Begins the route form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcForm BeginRouteFormEx(this HtmlHelper htmlHelper, string routeName, object routeValues) { return BeginRouteFormEx(htmlHelper, routeName, new RouteValueDictionary(routeValues), FormMethod.Post, new RouteValueDictionary()); }
        /// <summary>
        /// Begins the route form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        public static MvcForm BeginRouteFormEx(this HtmlHelper htmlHelper, string routeName, FormMethod method) { return BeginRouteFormEx(htmlHelper, routeName, new RouteValueDictionary(), method, new RouteValueDictionary()); }
        /// <summary>
        /// Begins the route form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static MvcForm BeginRouteFormEx(this HtmlHelper htmlHelper, string routeName, RouteValueDictionary routeValues) { return BeginRouteFormEx(htmlHelper, routeName, routeValues, FormMethod.Post, new RouteValueDictionary()); }
        /// <summary>
        /// Begins the route form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        public static MvcForm BeginRouteFormEx(this HtmlHelper htmlHelper, string routeName, object routeValues, FormMethod method) { return BeginRouteFormEx(htmlHelper, routeName, new RouteValueDictionary(routeValues), method, new RouteValueDictionary()); }
        /// <summary>
        /// Begins the route form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="method">The method.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcForm BeginRouteFormEx(this HtmlHelper htmlHelper, string routeName, FormMethod method, IDictionary<string, object> htmlAttributes) { return BeginRouteFormEx(htmlHelper, routeName, new RouteValueDictionary(), method, htmlAttributes); }
        /// <summary>
        /// Begins the route form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="method">The method.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcForm BeginRouteFormEx(this HtmlHelper htmlHelper, string routeName, FormMethod method, object htmlAttributes) { return BeginRouteFormEx(htmlHelper, routeName, new RouteValueDictionary(), method, new RouteValueDictionary(htmlAttributes)); }
        /// <summary>
        /// Begins the route form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        public static MvcForm BeginRouteFormEx(this HtmlHelper htmlHelper, string routeName, RouteValueDictionary routeValues, FormMethod method) { return BeginRouteFormEx(htmlHelper, routeName, routeValues, method, new RouteValueDictionary()); }
        /// <summary>
        /// Begins the route form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="method">The method.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcForm BeginRouteFormEx(this HtmlHelper htmlHelper, string routeName, object routeValues, FormMethod method, object htmlAttributes) { return BeginRouteFormEx(htmlHelper, routeName, new RouteValueDictionary(routeValues), method, new RouteValueDictionary(htmlAttributes)); }
        /// <summary>
        /// Begins the route form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="method">The method.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcForm BeginRouteFormEx(this HtmlHelper htmlHelper, string routeName, RouteValueDictionary routeValues, FormMethod method, IDictionary<string, object> htmlAttributes)
        {
            IDynamicNode node;
            var formAction = UrlHelperEx.GenerateUrl(out node, routeName, null, null, routeValues, htmlHelper.RouteCollection, htmlHelper.ViewContext.RequestContext, false);
            return FormHelper(htmlHelper, formAction, method, htmlAttributes);
        }

        /// <summary>
        /// Ends the form ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        public static void EndFormEx(this HtmlHelper htmlHelper)
        {
            htmlHelper.ViewContext.Writer.Write("</form>");
            htmlHelper.ViewContext.OutputClientValidation();
        }

        private static MvcForm FormHelper(HtmlHelper htmlHelper, string formAction, FormMethod method, IDictionary<string, object> htmlAttributes)
        {
            var builder = new TagBuilder("form");
            builder.MergeAttributes<string, object>(htmlAttributes);
            builder.MergeAttribute("action", formAction);
            builder.MergeAttribute("method", HtmlHelper.GetFormMethodString(method), true);
            if (htmlHelper.ViewContext.ClientValidationEnabled)
                builder.GenerateId(((Func<string>)_formIdGeneratorPropertyInfo.GetValue(htmlHelper.ViewContext, null))());
            htmlHelper.ViewContext.Writer.Write(builder.ToString(TagRenderMode.StartTag));
            var form = new MvcForm(htmlHelper.ViewContext);
            if (htmlHelper.ViewContext.ClientValidationEnabled)
                htmlHelper.ViewContext.FormContext.FormId = builder.Attributes["id"];
            return form;
        }
    }
}
