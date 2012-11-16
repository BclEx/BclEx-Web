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
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Web.Routing;
using System.Web.Mvc;
namespace System.Web.Mvc.Html
{
    public static partial class TextAreaExtensionsEx
    {
        /// <summary>
        /// Texts the area for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static MvcHtmlString TextAreaForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression) { return TextAreaForEx<TModel, TProperty>(htmlHelper, expression, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// Texts the area for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString TextAreaForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes) { return TextAreaForEx<TModel, TProperty>(htmlHelper, expression, ((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes))); }
        /// <summary>
        /// Texts the area for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString TextAreaForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            IEnumerable<IInputViewModifier> modifier;
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            if (metadata != null && metadata.TryGetExtent<IEnumerable<IInputViewModifier>>(out modifier))
                modifier.MapInputToHtmlAttributes(ref expression, ref htmlAttributes);
            return htmlHelper.TextAreaFor<TModel, TProperty>(expression, htmlAttributes);
        }

        /// <summary>
        /// Texts the area for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString TextAreaForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, object htmlAttributes) { return TextAreaForEx<TModel, TProperty>(htmlHelper, expression, rows, columns, ((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes))); }
        /// <summary>
        /// Texts the area for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString TextAreaForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows, int columns, IDictionary<string, object> htmlAttributes)
        {
            IEnumerable<IInputViewModifier> modifier;
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            if (metadata != null && metadata.TryGetExtent<IEnumerable<IInputViewModifier>>(out modifier))
                modifier.MapInputToHtmlAttributes(ref expression, ref htmlAttributes);
            return htmlHelper.TextAreaFor<TModel, TProperty>(expression, rows, columns, htmlAttributes);
        }
    }
}
