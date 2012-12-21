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
#if !MVC2
using HtmlHelperKludge = System.Web.Mvc.HtmlHelper;
#endif
namespace System.Web.Mvc.Html
{
    public static partial class SelectExtensionsEx
    {
        /// <summary>
        /// Drops down list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <returns></returns>
        public static MvcHtmlString DropDownListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList) { return DropDownListForEx<TModel, TProperty>(htmlHelper, expression, selectList, null, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// Drops down list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString DropDownListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes) { return DropDownListForEx<TModel, TProperty>(htmlHelper, expression, selectList, null, htmlAttributes); }
        /// <summary>
        /// Drops down list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString DropDownListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes) { return DropDownListForEx<TModel, TProperty>(htmlHelper, expression, selectList, null, (IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// Drops down list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionLabel">The option label.</param>
        /// <returns></returns>
        public static MvcHtmlString DropDownListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel) { return DropDownListForEx<TModel, TProperty>(htmlHelper, expression, selectList, optionLabel, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// Drops down list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionLabel">The option label.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString DropDownListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes) { return DropDownListForEx<TModel, TProperty>(htmlHelper, expression, selectList, optionLabel, (IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// Drops down list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionLabel">The option label.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString DropDownListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            IEnumerable<IInputViewModifier> modifier;
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            if (metadata != null && metadata.TryGetExtent<IEnumerable<IInputViewModifier>>(out modifier))
                modifier.MapInputToHtmlAttributes(ref expression, ref htmlAttributes);
            return htmlHelper.DropDownListFor<TModel, TProperty>(expression, selectList, optionLabel, htmlAttributes);
        }

        /// <summary>
        /// Lists the box for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <returns></returns>
        public static MvcHtmlString ListBoxForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList) { return ListBoxForEx<TModel, TProperty>(htmlHelper, expression, selectList, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// Lists the box for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString ListBoxForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes) { return ListBoxForEx<TModel, TProperty>(htmlHelper, expression, selectList, (IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// Lists the box for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString ListBoxForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            IEnumerable<IInputViewModifier> modifier;
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            if (metadata != null && metadata.TryGetExtent<IEnumerable<IInputViewModifier>>(out modifier))
                modifier.MapInputToHtmlAttributes(ref expression, ref htmlAttributes);
            return htmlHelper.ListBoxFor<TModel, TProperty>(expression, selectList, htmlAttributes);
        }

        /// <summary>
        /// Radioes the button list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList) { return RadioButtonListForEx<TModel, TProperty>(htmlHelper, expression, selectList, null, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// Radioes the button list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes) { return RadioButtonListForEx<TModel, TProperty>(htmlHelper, expression, selectList, null, htmlAttributes); }
        /// <summary>
        /// Radioes the button list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes) { return RadioButtonListForEx<TModel, TProperty>(htmlHelper, expression, selectList, null, (IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// Radioes the button list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="layout">The layout.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, SelectListLayout layout) { return RadioButtonListForEx<TModel, TProperty>(htmlHelper, expression, selectList, layout, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// Radioes the button list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="layout">The layout.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, SelectListLayout layout, IDictionary<string, object> htmlAttributes)
        {
            IEnumerable<IInputViewModifier> modifier;
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            if (metadata != null && metadata.TryGetExtent<IEnumerable<IInputViewModifier>>(out modifier))
                modifier.MapInputToHtmlAttributes(ref expression, ref htmlAttributes);
            return htmlHelper.RadioButtonListFor<TModel, TProperty>(expression, selectList, layout, htmlAttributes);
        }

        /// <summary>
        /// Checks the box list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList) { return CheckBoxListForEx<TModel, TProperty>(htmlHelper, expression, selectList, null, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// Checks the box list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes) { return CheckBoxListForEx<TModel, TProperty>(htmlHelper, expression, selectList, null, htmlAttributes); }
        /// <summary>
        /// Checks the box list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes) { return CheckBoxListForEx<TModel, TProperty>(htmlHelper, expression, selectList, null, (IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// Checks the box list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="layout">The layout.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, SelectListLayout layout) { return CheckBoxListForEx<TModel, TProperty>(htmlHelper, expression, selectList, layout, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// Checks the box list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="layout">The layout.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, SelectListLayout layout, IDictionary<string, object> htmlAttributes)
        {
            IEnumerable<IInputViewModifier> modifier;
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            if (metadata != null && metadata.TryGetExtent<IEnumerable<IInputViewModifier>>(out modifier))
                modifier.MapInputToHtmlAttributes(ref expression, ref htmlAttributes);
            return htmlHelper.CheckBoxListFor<TModel, TProperty>(expression, selectList, layout, htmlAttributes);
        }

        /// <summary>
        /// Groupeds the drop down list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListGroupedItem> selectList) { return GroupedDropDownListForEx(htmlHelper, expression, selectList, null, null); }
        /// <summary>
        /// Groupeds the drop down list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListGroupedItem> selectList, IDictionary<string, object> htmlAttributes) { return GroupedDropDownListForEx(htmlHelper, expression, selectList, null, htmlAttributes); }
        /// <summary>
        /// Groupeds the drop down list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListGroupedItem> selectList, object htmlAttributes) { return GroupedDropDownListForEx(htmlHelper, expression, selectList, null, HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// Groupeds the drop down list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionLabel">The option label.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListGroupedItem> selectList, string optionLabel) { return GroupedDropDownListForEx(htmlHelper, expression, selectList, optionLabel, null); }
        /// <summary>
        /// Groupeds the drop down list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionLabel">The option label.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListGroupedItem> selectList, string optionLabel, object htmlAttributes) { return GroupedDropDownListForEx(htmlHelper, expression, selectList, optionLabel, HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// Groupeds the drop down list for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionLabel">The option label.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownListForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListGroupedItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            IEnumerable<IInputViewModifier> modifier;
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            if (metadata != null && metadata.TryGetExtent<IEnumerable<IInputViewModifier>>(out modifier))
                modifier.MapInputToHtmlAttributes(ref expression, ref htmlAttributes);
            return htmlHelper.GroupedDropDownListFor<TModel, TProperty>(expression, selectList, optionLabel, htmlAttributes);
        }

        /// <summary>
        /// Groupeds the list box for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedListBoxForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListGroupedItem> selectList) { return GroupedListBoxForEx(htmlHelper, expression, selectList, null); }
        /// <summary>
        /// Groupeds the list box for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedListBoxForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListGroupedItem> selectList, object htmlAttributes) { return GroupedListBoxForEx(htmlHelper, expression, selectList, HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// Groupeds the list box for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedListBoxForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListGroupedItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            IEnumerable<IInputViewModifier> modifier;
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            if (metadata != null && metadata.TryGetExtent<IEnumerable<IInputViewModifier>>(out modifier))
                modifier.MapInputToHtmlAttributes(ref expression, ref htmlAttributes);
            return htmlHelper.GroupedListBoxFor<TModel, TProperty>(expression, selectList, htmlAttributes);
        }
    }
}
