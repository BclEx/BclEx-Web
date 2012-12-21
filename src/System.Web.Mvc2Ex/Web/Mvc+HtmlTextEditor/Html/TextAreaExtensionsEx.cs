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
using System;
using System.Collections.Generic;
using System.Web.Routing;
using System.Globalization;
using System.Linq.Expressions;
using System.Web.UI;
#if !MVC2
using HtmlHelperKludge = System.Web.Mvc.HtmlHelper;
#endif
namespace System.Web.Mvc.Html
{
    /// <summary>
    /// TextAreaExtensionsEx
    /// </summary>
    public static partial class TextAreaExtensionsEx
    {
        /// <summary>
        /// HTMLs the text editor.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static MvcHtmlString HtmlTextEditor(this HtmlHelper htmlHelper, string name) { return htmlHelper.HtmlTextEditor(name, null, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// HTMLs the text editor.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString HtmlTextEditor(this HtmlHelper htmlHelper, string name, IDictionary<string, object> htmlAttributes) { return htmlHelper.HtmlTextEditor(name, null, htmlAttributes); }
        /// <summary>
        /// HTMLs the text editor.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString HtmlTextEditor(this HtmlHelper htmlHelper, string name, object htmlAttributes) { return htmlHelper.HtmlTextEditor(name, null, (IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// HTMLs the text editor.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static MvcHtmlString HtmlTextEditor(this HtmlHelper htmlHelper, string name, string value) { return htmlHelper.HtmlTextEditor(name, value, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// HTMLs the text editor.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString HtmlTextEditor(this HtmlHelper htmlHelper, string name, string value, IDictionary<string, object> htmlAttributes)
        {
            var modelMetadata = ModelMetadata.FromStringExpression(name, htmlHelper.ViewContext.ViewData);
            if (value != null)
                modelMetadata.Model = value;
            var editor = GetEditor(htmlAttributes);
            return editor.HtmlTextAreaHelper(htmlHelper, modelMetadata, name, _implicitRowsAndColumns, htmlAttributes);
        }

        /// <summary>
        /// HTMLs the text editor.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString HtmlTextEditor(this HtmlHelper htmlHelper, string name, string value, object htmlAttributes) { return htmlHelper.HtmlTextEditor(name, value, (IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// HTMLs the text editor.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString HtmlTextEditor(this HtmlHelper htmlHelper, string name, string value, int rows, int columns, IDictionary<string, object> htmlAttributes)
        {
            var modelMetadata = ModelMetadata.FromStringExpression(name, htmlHelper.ViewContext.ViewData);
            if (value != null)
                modelMetadata.Model = value;
            var editor = GetEditor(htmlAttributes);
            return editor.HtmlTextAreaHelper(htmlHelper, modelMetadata, name, GetRowsAndColumnsDictionary(rows, columns), htmlAttributes);
        }
        /// <summary>
        /// HTMLs the text editor.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString HtmlTextEditor(this HtmlHelper htmlHelper, string name, string value, int rows, int columns, object htmlAttributes) { return htmlHelper.HtmlTextEditor(name, value, rows, columns, (IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }

        /// <summary>
        /// HTMLs the text editor for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static MvcHtmlString HtmlTextEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression) { return htmlHelper.HtmlTextEditorFor<TModel, TProperty>(expression, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// HTMLs the text editor for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString HtmlTextEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");
            var editor = GetEditor(htmlAttributes);
            return editor.HtmlTextAreaHelper(htmlHelper, ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData), ExpressionHelper.GetExpressionText(expression), _implicitRowsAndColumns, htmlAttributes);
        }
        /// <summary>
        /// HTMLs the text editor for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString HtmlTextEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes) { return htmlHelper.HtmlTextEditorFor<TModel, TProperty>(expression, (IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// HTMLs the text editor for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString HtmlTextEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");
            var editor = GetEditor(htmlAttributes);
            return editor.HtmlTextAreaHelper(htmlHelper, ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData), ExpressionHelper.GetExpressionText(expression), GetRowsAndColumnsDictionary(rows, columns), htmlAttributes);
        }
        /// <summary>
        /// HTMLs the text editor for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString HtmlTextEditorFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, object htmlAttributes) { return htmlHelper.HtmlTextEditorFor<TModel, TProperty>(expression, rows, columns, (IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }

        #region Render Editor

        internal static Dictionary<string, object> _implicitRowsAndColumns;
        private const int TextAreaColumns = 20;
        private const int TextAreaRows = 2;

        static TextAreaExtensionsEx()
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("rows", 2.ToString(CultureInfo.InvariantCulture));
            dictionary.Add("cols", 20.ToString(CultureInfo.InvariantCulture));
            _implicitRowsAndColumns = dictionary;
        }

        private static Dictionary<string, object> GetRowsAndColumnsDictionary(int rows, int columns)
        {
            if (rows < 0)
                throw new ArgumentOutOfRangeException("rows");
            if (columns < 0)
                throw new ArgumentOutOfRangeException("columns");
            var dictionary = new Dictionary<string, object>();
            if (rows > 0)
                dictionary.Add("rows", rows.ToString(CultureInfo.InvariantCulture));
            if (columns > 0)
                dictionary.Add("cols", columns.ToString(CultureInfo.InvariantCulture));
            return dictionary;
        }

        private static IHtmlTextEditor GetEditor(IDictionary<string, object> htmlAttributes)
        {
            throw new NotSupportedException();

            //    object value;
            //    bool inDebugMode = (!htmlAttributes.TryGetValue("resourceFolder", out value) ? (bool)value : false);
            //    string htmlTextEditorID = (!htmlAttributes.TryGetValue("htmlTextEditorID", out value) ? (string)value : string.Empty);
            //    string toolbarID = (!htmlAttributes.TryGetValue("toolbarID", out value) ? (string)value : string.Empty);
            //    string resourceFolder = (!htmlAttributes.TryGetValue("resourceFolder", out value) ? (string)value : string.Empty);
            //    //
            //    var htmlTextBoxContext = ServiceLocator.Resolve<IHtmlTextBoxContext>(htmlTextEditorID, toolbarID, resourceFolder);
            //    if (inDebugMode)
            //        htmlTextBoxContext.InDebugMode = true;
            //    return ServiceLocator.Resolve<IHtmlTextEditor>(null, htmlTextBoxContext);
        }

        #endregion
    }
}
