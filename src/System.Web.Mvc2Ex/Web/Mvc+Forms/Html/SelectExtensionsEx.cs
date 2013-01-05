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
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Routing;
using System.Text;
using System.Globalization;
using System.Collections;
using System.Web.UI.WebControls;
#if !MVC2
using HtmlHelperKludge = System.Web.Mvc.HtmlHelper;
#endif
namespace System.Web.Mvc.Html
{
    /// <summary>
    /// SelectExtensionsEx
    /// </summary>
    public static partial class SelectExtensionsEx
    {
        /// <summary>
        /// Radioes the button list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonList(this HtmlHelper htmlHelper, string name) { return RadioButtonListHelper(htmlHelper, null, name, null, null, (IDictionary<string, object>)null); }
        /// <summary>
        /// Radioes the button list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList) { return RadioButtonListHelper(htmlHelper, null, name, selectList, null, (IDictionary<string, object>)null); }
        /// <summary>
        /// Radioes the button list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="layout">The layout.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonList(this HtmlHelper htmlHelper, string name, SelectListLayout layout) { return RadioButtonListHelper(htmlHelper, null, name, null, layout, (IDictionary<string, object>)null); }
        /// <summary>
        /// Radioes the button list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes) { return RadioButtonListHelper(htmlHelper, null, name, selectList, null, htmlAttributes); }
        /// <summary>
        /// Radioes the button list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, object htmlAttributes) { return RadioButtonListHelper(htmlHelper, null, name, selectList, null, (IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// Radioes the button list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="layout">The layout.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, SelectListLayout layout) { return RadioButtonListHelper(htmlHelper, null, name, selectList, layout, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// Radioes the button list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="layout">The layout.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, SelectListLayout layout, IDictionary<string, object> htmlAttributes) { return RadioButtonListHelper(htmlHelper, null, name, selectList, layout, htmlAttributes); }
        /// <summary>
        /// Radioes the button list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="layout">The layout.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, SelectListLayout layout, object htmlAttributes) { return RadioButtonListHelper(htmlHelper, null, name, selectList, layout, ((IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes))); }
        /// <summary>
        /// Radioes the button list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList) { return RadioButtonListFor<TModel, TProperty>(htmlHelper, expression, selectList, null, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// Radioes the button list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes) { return RadioButtonListFor<TModel, TProperty>(htmlHelper, expression, selectList, null, htmlAttributes); }
        /// <summary>
        /// Radioes the button list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes) { return RadioButtonListFor<TModel, TProperty>(htmlHelper, expression, selectList, null, ((IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes))); }
        /// <summary>
        /// Radioes the button list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="layout">The layout.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, SelectListLayout layout) { return RadioButtonListFor<TModel, TProperty>(htmlHelper, expression, selectList, layout, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// Radioes the button list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="layout">The layout.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string layout, object htmlAttributes) { return RadioButtonListFor<TModel, TProperty>(htmlHelper, expression, selectList, layout, ((IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes))); }
        /// <summary>
        /// Radioes the button list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="layout">The layout.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, SelectListLayout layout, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData); //:kludge
            return RadioButtonListHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), selectList, layout, htmlAttributes);
        }

        private static MvcHtmlString RadioButtonListHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, IEnumerable<SelectListItem> selectList, SelectListLayout layout, IDictionary<string, object> htmlAttributes)
        {
            return SelectInternal(htmlHelper, metadata, null, name, selectList, (layout ?? new SelectListLayout()), false, htmlAttributes);
        }

        /// <summary>
        /// Checks the box list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string name) { return CheckBoxListHelper(htmlHelper, null, name, null, null, (IDictionary<string, object>)null); }
        /// <summary>
        /// Checks the box list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList) { return CheckBoxListHelper(htmlHelper, null, name, selectList, null, (IDictionary<string, object>)null); }
        /// <summary>
        /// Checks the box list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="layout">The layout.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string name, SelectListLayout layout) { return CheckBoxListHelper(htmlHelper, null, name, null, layout, (IDictionary<string, object>)null); }
        /// <summary>
        /// Checks the box list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes) { return CheckBoxListHelper(htmlHelper, null, name, selectList, null, htmlAttributes); }
        /// <summary>
        /// Checks the box list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, object htmlAttributes) { return CheckBoxListHelper(htmlHelper, null, name, selectList, null, (IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// Checks the box list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="layout">The layout.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, SelectListLayout layout) { return CheckBoxListHelper(htmlHelper, null, name, selectList, layout, (IDictionary<string, object>)null); }
        /// <summary>
        /// Checks the box list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="layout">The layout.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, SelectListLayout layout, IDictionary<string, object> htmlAttributes) { return CheckBoxListHelper(htmlHelper, null, name, selectList, layout, htmlAttributes); }
        /// <summary>
        /// Checks the box list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="layout">The layout.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, SelectListLayout layout, object htmlAttributes) { return CheckBoxListHelper(htmlHelper, null, name, selectList, layout, (IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// Checks the box list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList) { return CheckBoxListFor<TModel, TProperty>(htmlHelper, expression, selectList, null, (IDictionary<string, object>)null); }
        /// <summary>
        /// Checks the box list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes) { return CheckBoxListFor<TModel, TProperty>(htmlHelper, expression, selectList, null, htmlAttributes); }
        /// <summary>
        /// Checks the box list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes) { return CheckBoxListFor<TModel, TProperty>(htmlHelper, expression, selectList, null, (IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// Checks the box list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="layout">The layout.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, SelectListLayout layout) { return CheckBoxListFor<TModel, TProperty>(htmlHelper, expression, selectList, layout, ((IDictionary<string, object>)null)); }
        /// <summary>
        /// Checks the box list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="layout">The layout.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string layout, object htmlAttributes) { return CheckBoxListFor<TModel, TProperty>(htmlHelper, expression, selectList, layout, (IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// Checks the box list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="layout">The layout.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, SelectListLayout layout, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData); //:kludge
            return CheckBoxListHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), selectList, layout, htmlAttributes);
        }

        private static MvcHtmlString CheckBoxListHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, IEnumerable<SelectListItem> selectList, SelectListLayout layout, IDictionary<string, object> htmlAttributes)
        {
            return SelectInternal(htmlHelper, metadata, null, name, selectList, (layout ?? new SelectListLayout()), true, htmlAttributes);
        }

        /// <summary>
        /// Groupeds the drop down list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownList(this HtmlHelper htmlHelper, string name) { return GroupedDropDownListHelper(htmlHelper, null, name, null, null, null); }
        /// <summary>
        /// Groupeds the drop down list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListGroupedItem> selectList) { return GroupedDropDownListHelper(htmlHelper, null, name, selectList, null, null); }
        /// <summary>
        /// Groupeds the drop down list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="optionLabel">The option label.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownList(this HtmlHelper htmlHelper, string name, string optionLabel) { return GroupedDropDownListHelper(htmlHelper, null, name, null, optionLabel, null); }
        /// <summary>
        /// Groupeds the drop down list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListGroupedItem> selectList, IDictionary<string, object> htmlAttributes) { return GroupedDropDownListHelper(htmlHelper, null, name, selectList, null, htmlAttributes); }
        /// <summary>
        /// Groupeds the drop down list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListGroupedItem> selectList, object htmlAttributes) { return GroupedDropDownListHelper(htmlHelper, null, name, selectList, null, HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// Groupeds the drop down list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionLabel">The option label.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListGroupedItem> selectList, string optionLabel) { return GroupedDropDownListHelper(htmlHelper, null, name, selectList, optionLabel, null); }
        /// <summary>
        /// Groupeds the drop down list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionLabel">The option label.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListGroupedItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes) { return GroupedDropDownListHelper(htmlHelper, null, name, selectList, optionLabel, htmlAttributes); }
        /// <summary>
        /// Groupeds the drop down list.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionLabel">The option label.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListGroupedItem> selectList, string optionLabel, object htmlAttributes) { return GroupedDropDownListHelper(htmlHelper, null, name, selectList, optionLabel, HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// Groupeds the drop down list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListGroupedItem> selectList) { return GroupedDropDownListFor(htmlHelper, expression, selectList, null, null); }
        /// <summary>
        /// Groupeds the drop down list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListGroupedItem> selectList, IDictionary<string, object> htmlAttributes) { return GroupedDropDownListFor(htmlHelper, expression, selectList, null, htmlAttributes); }
        /// <summary>
        /// Groupeds the drop down list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListGroupedItem> selectList, object htmlAttributes) { return GroupedDropDownListFor(htmlHelper, expression, selectList, null, HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// Groupeds the drop down list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionLabel">The option label.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListGroupedItem> selectList, string optionLabel) { return GroupedDropDownListFor(htmlHelper, expression, selectList, optionLabel, null); }
        /// <summary>
        /// Groupeds the drop down list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionLabel">The option label.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListGroupedItem> selectList, string optionLabel, object htmlAttributes) { return GroupedDropDownListFor(htmlHelper, expression, selectList, optionLabel, HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// Groupeds the drop down list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="optionLabel">The option label.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListGroupedItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData); //:kludge
            return GroupedDropDownListHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), selectList, optionLabel, htmlAttributes);
        }

        private static MvcHtmlString GroupedDropDownListHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, IEnumerable<SelectListGroupedItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            return SelectInternal(htmlHelper, metadata, optionLabel, name, selectList, false, htmlAttributes);
        }

        /// <summary>
        /// Groupeds the list box.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedListBox(this HtmlHelper htmlHelper, string name) { return GroupedListBoxHelper(htmlHelper, null, name, null, null); }
        /// <summary>
        /// Groupeds the list box.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedListBox(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListGroupedItem> selectList) { return GroupedListBoxHelper(htmlHelper, null, name, selectList, null); }
        /// <summary>
        /// Groupeds the list box.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedListBox(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListGroupedItem> selectList, IDictionary<string, object> htmlAttributes) { return GroupedListBoxHelper(htmlHelper, null, name, selectList, htmlAttributes); }
        /// <summary>
        /// Groupeds the list box.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedListBox(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListGroupedItem> selectList, object htmlAttributes) { return GroupedListBoxHelper(htmlHelper, null, name, selectList, HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }

        /// <summary>
        /// Groupeds the list box for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedListBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListGroupedItem> selectList) { return GroupedListBoxFor(htmlHelper, expression, selectList, null); }
        /// <summary>
        /// Groupeds the list box for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedListBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListGroupedItem> selectList, object htmlAttributes) { return GroupedListBoxFor(htmlHelper, expression, selectList, HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes)); }
        /// <summary>
        /// Groupeds the list box for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="selectList">The select list.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString GroupedListBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListGroupedItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData); //:kludge
            return GroupedListBoxHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), selectList, htmlAttributes);
        }

        private static MvcHtmlString GroupedListBoxHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, IEnumerable<SelectListGroupedItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            return SelectInternal(htmlHelper, metadata, null, name, selectList, true, htmlAttributes);
        }

        #region Select Renderer

        private static IEnumerable<SelectListItem> GetSelectData(this HtmlHelper htmlHelper, string name)
        {
            object selectList = null;
            if (htmlHelper.ViewData != null)
                selectList = htmlHelper.ViewData.Eval(name);
            if (selectList == null)
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentUICulture, "MvcResources.HtmlHelper_MissingSelectData", name, "IEnumerable<SelectListItem>"));
            var enumerable = (selectList as IEnumerable<SelectListItem>);
            if (enumerable == null)
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentUICulture, "MvcResources.HtmlHelper_WrongSelectDataType", name, selectList.GetType().FullName, "IEnumerable<SelectListItem>"));
            return enumerable;
        }

        private static IEnumerable<SelectListGroupedItem> GetSelectGroupedData(this HtmlHelper htmlHelper, string name)
        {
            object selectList = null;
            if (htmlHelper.ViewData != null)
                selectList = htmlHelper.ViewData.Eval(name);
            if (selectList == null)
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentUICulture, "MvcResources.HtmlHelper_MissingSelectData", name, "IEnumerable<SelectListItem>"));
            var enumerable = (selectList as IEnumerable<SelectListGroupedItem>);
            if (enumerable == null)
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentUICulture, "MvcResources.HtmlHelper_WrongSelectDataType", name, selectList.GetType().FullName, "IEnumerable<SelectListItem>"));
            return enumerable;
        }

        private static MvcHtmlString SelectInternal(this HtmlHelper htmlHelper, ModelMetadata metadata, string optionLabel, string name, IEnumerable<SelectListItem> selectList, SelectListLayout layout, bool allowMultiple, IDictionary<string, object> htmlAttributes)
        {
            var fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (string.IsNullOrEmpty(fullHtmlFieldName))
                throw new ArgumentException("MvcResources.Common_NullOrEmpty", "name");
            var usedViewData = false;
            // If we got a null selectList, try to use ViewData to get the list of items.
            if (selectList == null)
            {
                selectList = htmlHelper.GetSelectData(name);
                usedViewData = true;
            }
            var defaultValue = (allowMultiple ? htmlHelper.GetModelStateValue(fullHtmlFieldName, typeof(string[])) : htmlHelper.GetModelStateValue(fullHtmlFieldName, typeof(string)));
            // If we haven't already used ViewData to get the entire list of items then we need to use the ViewData-supplied value before using the parameter-supplied value.
            if (!usedViewData && defaultValue == null && !string.IsNullOrEmpty(name))
                defaultValue = htmlHelper.ViewData.Eval(name);
            if (defaultValue != null)
                selectList = GetSelectListWithDefaultValue(selectList, defaultValue, allowMultiple); //:kludge
            var b = new StringBuilder();
            if (optionLabel != null)
                b.AppendLine(ListItemToOption(new SelectListGroupedItem { Text = optionLabel, Value = String.Empty, Selected = false }));
            foreach (var item in selectList)
                b.AppendLine(ListItemToOption(fullHtmlFieldName, item, layout, allowMultiple));
            var divTag = new TagBuilder("div") { InnerHtml = b.ToString() };
            if (layout.RepeatDirection == RepeatDirection.Horizontal)
                divTag.AddCssStyle("clear", "both");
            divTag.MergeAttributes(htmlAttributes);
            divTag.GenerateId(fullHtmlFieldName);
            ModelState state;
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullHtmlFieldName, out state) && state.Errors.Count > 0)
                divTag.AddCssClass(HtmlHelper.ValidationInputCssClassName);
#if MVC4
            divTag.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name, metadata));
#elif MVC3
            divTag.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name));
#endif
            return divTag.ToMvcHtmlString(TagRenderMode.Normal);
        }

        private static MvcHtmlString SelectInternal(this HtmlHelper htmlHelper, ModelMetadata metadata, string optionLabel, string name, IEnumerable<SelectListGroupedItem> selectList, bool allowMultiple, IDictionary<string, object> htmlAttributes)
        {
            var fullHtmlFieldName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (string.IsNullOrEmpty(fullHtmlFieldName))
                throw new ArgumentException("MvcResources.Common_NullOrEmpty", "name");
            var usedViewData = false;
            // If we got a null selectList, try to use ViewData to get the list of items.
            if (selectList == null)
            {
                selectList = htmlHelper.GetSelectGroupedData(name); //:kludge
                usedViewData = true;
            }
            var defaultValue = (allowMultiple ? htmlHelper.GetModelStateValue(fullHtmlFieldName, typeof(string[])) : htmlHelper.GetModelStateValue(fullHtmlFieldName, typeof(string)));
            // If we haven't already used ViewData to get the entire list of items then we need to use the ViewData-supplied value before using the parameter-supplied value.
            if (!usedViewData && defaultValue == null && !string.IsNullOrEmpty(name)) //:kludge
                defaultValue = htmlHelper.ViewData.Eval(name);
            if (defaultValue != null)
                selectList = GetSelectListWithDefaultValue(selectList, defaultValue, allowMultiple); //:kludge
            var b = new StringBuilder();
            if (optionLabel != null)
                b.AppendLine(ListItemToOption(new SelectListGroupedItem { Text = optionLabel, Value = String.Empty, Selected = false }));
            foreach (var group in selectList.GroupBy(x => x.GroupValue))
            {
                var groupText = selectList.Where(x => x.GroupValue == group.Key).Select(x => x.GroupText).FirstOrDefault();
                if (!string.IsNullOrEmpty(group.Key) || !string.IsNullOrEmpty(groupText))
                {
                    b.AppendLine(string.Format("<optgroup label=\"{0}\" data-value=\"{1}\">", groupText, group.Key));
                    foreach (var item in group)
                        b.AppendLine(ListItemToOption(item));
                    b.AppendLine("</optgroup>");
                }
                else
                    foreach (var item in group)
                        b.AppendLine(ListItemToOption(item));
            }
            var selectTag = new TagBuilder("select") { InnerHtml = b.ToString() };
            selectTag.MergeAttributes(htmlAttributes);
            selectTag.MergeAttribute("name", fullHtmlFieldName, true);
            selectTag.GenerateId(fullHtmlFieldName);
            if (allowMultiple)
                selectTag.MergeAttribute("multiple", "multiple");
            // If there are any errors for a named field, we add the css attribute.
            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullHtmlFieldName, out modelState) && modelState.Errors.Count > 0)
                selectTag.AddCssClass(HtmlHelper.ValidationInputCssClassName);
#if MVC4
            selectTag.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name, metadata));
#elif MVC3
            selectTag.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name));
#endif
            return selectTag.ToMvcHtmlString(TagRenderMode.Normal);
        }

        private static IEnumerable<SelectListItem> GetSelectListWithDefaultValue(IEnumerable<SelectListItem> selectList, object defaultValue, bool allowMultiple)
        {
            IEnumerable source;
            if (allowMultiple)
            {
                source = (defaultValue as IEnumerable);
                if (source == null || source is string)
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "HtmlHelper_SelectExpressionNotEnumerable", "expression"));
            }
            source = new[] { defaultValue };
            var set = new HashSet<string>(source.Cast<object>().Select(value => Convert.ToString(value, CultureInfo.CurrentCulture)), StringComparer.OrdinalIgnoreCase);
            var list = new List<SelectListItem>();
            foreach (var item in selectList)
            {
                item.Selected = (item.Value != null ? set.Contains(item.Value) : set.Contains(item.Text));
                list.Add(item);
            }
            return list;
        }

        private static IEnumerable<SelectListGroupedItem> GetSelectListWithDefaultValue(IEnumerable<SelectListGroupedItem> selectList, object defaultValue, bool allowMultiple)
        {
            IEnumerable source;
            if (allowMultiple)
            {
                source = (defaultValue as IEnumerable);
                if (source == null || source is string)
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "HtmlHelper_SelectExpressionNotEnumerable", "expression"));
            }
            source = new[] { defaultValue };
            var set = new HashSet<string>(source.Cast<object>().Select(value => Convert.ToString(value, CultureInfo.CurrentCulture)), StringComparer.OrdinalIgnoreCase);
            var list = new List<SelectListGroupedItem>();
            foreach (var item in selectList)
            {
                item.Selected = (item.Value != null ? set.Contains(item.Value) : set.Contains(item.Text));
                list.Add(item);
            }
            return list;
        }

        internal static string ListItemToOption(string name, SelectListItem item, SelectListLayout layout, bool allowMultiple)
        {
            var inputTag = new TagBuilder("input");
            inputTag.Attributes.Add("type", (allowMultiple ? "checkbox" : "radio"));
            inputTag.Attributes.Add("name", name);
            if (item.Value != null)
                inputTag.Attributes["value"] = item.Value;
            if (item.Selected)
                inputTag.Attributes["checked"] = "checked";
            //
            var labelTag = new TagBuilder("label");
            labelTag.Attributes.Add("for", name);
            if (item.Text != null)
                labelTag.SetInnerText(item.Text);
            //
            var divTag = new TagBuilder("div");
            if (layout.RepeatDirection == RepeatDirection.Horizontal)
                divTag.AddCssStyle("float", "left");
            divTag.AddCssClass((allowMultiple ? "checkbox" : "radio") + "List");
            divTag.InnerHtml = inputTag.ToString(TagRenderMode.Normal) + labelTag.ToString(TagRenderMode.Normal);
            return divTag.ToString(TagRenderMode.Normal);
        }

        internal static string ListItemToOption(SelectListGroupedItem item)
        {
            var optionTag = new TagBuilder("option") { InnerHtml = HttpUtility.HtmlEncode(item.Text) };
            if (item.HtmlAttributes != null)
                optionTag.MergeAttributes(item.HtmlAttributes);
            if (item.Value != null)
                optionTag.Attributes["value"] = item.Value;
            if (item.Selected)
                optionTag.Attributes["selected"] = "selected";
            return optionTag.ToString(TagRenderMode.Normal);
        }

        #endregion
    }
}
