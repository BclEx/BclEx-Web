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
namespace System.Web.Mvc.Html
{
    /// <summary>
    /// InputExtensionsEx
    /// </summary>
    public static class InputExtensionsEx
    {
        /// <summary>
        /// Checks the box for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxForEx<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression) { return CheckBoxForEx<TModel>(htmlHelper, expression, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// Checks the box for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxForEx<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, object htmlAttributes) { return CheckBoxForEx<TModel>(htmlHelper, expression, ((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes))); }
        /// <summary>
        /// Checks the box for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxForEx<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, IDictionary<string, object> htmlAttributes)
        {
            IEnumerable<IInputViewModifier> modifier;
            var metadata = ModelMetadata.FromLambdaExpression<TModel, bool>(expression, htmlHelper.ViewData);
            if (metadata != null && metadata.TryGetExtent<IEnumerable<IInputViewModifier>>(out modifier))
                modifier.MapInputToHtmlAttributes(ref expression, ref htmlAttributes);
            return htmlHelper.CheckBoxFor<TModel>(expression, htmlAttributes);
        }

        /// <summary>
        /// Hiddens for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static MvcHtmlString HiddenForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression) { return HiddenForEx<TModel, TProperty>(htmlHelper, expression, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// Hiddens for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString HiddenForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes) { return HiddenForEx<TModel, TProperty>(htmlHelper, expression, ((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes))); }
        /// <summary>
        /// Hiddens for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString HiddenForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            IEnumerable<IInputViewModifier> modifier;
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            if (metadata != null && metadata.TryGetExtent<IEnumerable<IInputViewModifier>>(out modifier))
                modifier.MapInputToHtmlAttributes(ref expression, ref htmlAttributes);
            return htmlHelper.HiddenFor<TModel, TProperty>(expression, htmlAttributes);
        }

        /// <summary>
        /// Passwords for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static MvcHtmlString PasswordForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression) { return PasswordForEx<TModel, TProperty>(htmlHelper, expression, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// Passwords for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString PasswordForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes) { return PasswordForEx<TModel, TProperty>(htmlHelper, expression, ((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes))); }
        /// <summary>
        /// Passwords for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString PasswordForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            IEnumerable<IInputViewModifier> modifier;
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            if (metadata != null && metadata.TryGetExtent<IEnumerable<IInputViewModifier>>(out modifier))
                modifier.MapInputToHtmlAttributes(ref expression, ref htmlAttributes);
            return htmlHelper.PasswordFor<TModel, TProperty>(expression, htmlAttributes);
        }

        /// <summary>
        /// Radioes the button for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value) { return RadioButtonForEx<TModel, TProperty>(htmlHelper, expression, value, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// Radioes the button for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="value">The value.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value, object htmlAttributes) { return RadioButtonForEx<TModel, TProperty>(htmlHelper, expression, value, ((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes))); }
        /// <summary>
        /// Radioes the button for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="value">The value.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value, IDictionary<string, object> htmlAttributes)
        {
            IEnumerable<IInputViewModifier> modifier;
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            if (metadata != null && metadata.TryGetExtent<IEnumerable<IInputViewModifier>>(out modifier))
                modifier.MapInputToHtmlAttributes(ref expression, ref htmlAttributes);
            return htmlHelper.RadioButtonFor<TModel, TProperty>(expression, value, htmlAttributes);
        }

        /// <summary>
        /// Texts the box for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static MvcHtmlString TextBoxForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression) { return TextBoxForEx<TModel, TProperty>(htmlHelper, expression, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// Texts the box for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString TextBoxForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes) { return TextBoxForEx<TModel, TProperty>(htmlHelper, expression, ((IDictionary<string, object>)new RouteValueDictionary(htmlAttributes))); }
        /// <summary>
        /// Texts the box for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString TextBoxForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            IEnumerable<IInputViewModifier> modifier;
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            if (metadata != null && metadata.TryGetExtent<IEnumerable<IInputViewModifier>>(out modifier))
                modifier.MapInputToHtmlAttributes(ref expression, ref htmlAttributes);
            return htmlHelper.TextBoxFor<TModel, TProperty>(expression, htmlAttributes);
        }
    }
}
