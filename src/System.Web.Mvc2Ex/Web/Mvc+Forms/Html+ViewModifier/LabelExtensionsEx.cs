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
using System.Linq.Expressions;
using System.Text;
using System.Collections.Generic;
using System.Web.Routing;
#if !MVC2
using HtmlHelperKludge = System.Web.Mvc.HtmlHelper;
#endif
namespace System.Web.Mvc.Html
{
    /// <summary>
    /// LabelExtensionsEx
    /// </summary>
    public static class LabelExtensionsEx
    {
        // LABELEX
        /// <summary>
        /// Labels the ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static MvcHtmlString LabelEx(this HtmlHelper htmlHelper, string expression) { return LabelEx(htmlHelper, expression, (IDictionary<string, object>)null, null); }
        /// <summary>
        /// Labels the ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString LabelEx(this HtmlHelper htmlHelper, string expression, IDictionary<string, object> htmlAttributes) { return LabelEx(htmlHelper, expression, htmlAttributes, null); }
        /// <summary>
        /// Labels the ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="metadataModifer">The metadata modifer.</param>
        /// <returns></returns>
        public static MvcHtmlString LabelEx(this HtmlHelper htmlHelper, string expression, IDictionary<string, object> htmlAttributes, Action<ModelMetadata> metadataModifer)
        {
            IEnumerable<ILabelViewModifier> modifier;
            var metadata = ModelMetadata.FromStringExpression(expression, htmlHelper.ViewData);
            if (metadata != null && metadata.TryGetExtent<IEnumerable<ILabelViewModifier>>(out modifier))
                modifier.MapLabelToHtmlAttributes(ref expression, ref htmlAttributes);
            if (metadataModifer != null)
                metadataModifer(metadata);
            return LabelHelperEx(htmlHelper, metadata, expression, htmlAttributes);
        }
        /// <summary>
        /// Labels the ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString LabelEx(this HtmlHelper htmlHelper, string expression, object htmlAttributes) { return LabelEx(htmlHelper, expression, (IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes), null); }
        /// <summary>
        /// Labels the ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="metadataModifer">The metadata modifer.</param>
        /// <returns></returns>
        public static MvcHtmlString LabelEx(this HtmlHelper htmlHelper, string expression, object htmlAttributes, Action<ModelMetadata> metadataModifer) { return LabelEx(htmlHelper, expression, (IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes), metadataModifer); }

        // LABELFOREX
        /// <summary>
        /// Labels for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static MvcHtmlString LabelForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression) { return LabelForEx<TModel, TProperty>(htmlHelper, expression, (IDictionary<string, object>)null, null); }
        /// <summary>
        /// Labels for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString LabelForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes) { return LabelForEx<TModel, TProperty>(htmlHelper, expression, htmlAttributes, null); }
        /// <summary>
        /// Labels for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="metadataModifer">The metadata modifer.</param>
        /// <returns></returns>
        public static MvcHtmlString LabelForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes, Action<ModelMetadata> metadataModifer)
        {
            IEnumerable<ILabelViewModifier> modifier;
            var metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            if (metadata != null && metadata.TryGetExtent<IEnumerable<ILabelViewModifier>>(out modifier))
                modifier.MapLabelToHtmlAttributes(ref expression, ref htmlAttributes);
            if (metadataModifer != null)
                metadataModifer(metadata);
            return LabelHelperEx(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), htmlAttributes);
        }
        /// <summary>
        /// Labels for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString LabelForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes) { return LabelForEx<TModel, TProperty>(htmlHelper, expression, (IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes), null); }
        /// <summary>
        /// Labels for ex.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="metadataModifer">The metadata modifer.</param>
        /// <returns></returns>
        public static MvcHtmlString LabelForEx<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, Action<ModelMetadata> metadataModifer) { return LabelForEx<TModel, TProperty>(htmlHelper, expression, (IDictionary<string, object>)HtmlHelperKludge.AnonymousObjectToHtmlAttributes(htmlAttributes), metadataModifer); }

        // LABELFORMODELEX
        /// <summary>
        /// Labels for model ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <returns></returns>
        public static MvcHtmlString LabelForModelEx(this HtmlHelper htmlHelper) { return LabelForModelEx(htmlHelper, null); }
        /// <summary>
        /// Labels for model ex.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="metadataModifer">The metadata modifer.</param>
        /// <returns></returns>
        public static MvcHtmlString LabelForModelEx(this HtmlHelper htmlHelper, Action<ModelMetadata> metadataModifer)
        {
            return LabelHelperEx(htmlHelper, htmlHelper.ViewData.ModelMetadata, string.Empty, null);
        }

        internal static MvcHtmlString LabelHelperEx(HtmlHelper htmlHelper, ModelMetadata metadata, string htmlFieldName, IDictionary<string, object> htmlAttributes)
        {
            var text = (metadata.DisplayName ?? (metadata.PropertyName ?? htmlFieldName.Split(new char[] { '.' }).Last<string>()));
            if (string.IsNullOrEmpty(text))
                return MvcHtmlString.Empty;
            var templateInfo = htmlHelper.ViewContext.ViewData.TemplateInfo;
            var fullFieldName = templateInfo.GetFullHtmlFieldName(htmlFieldName);
            var labelTag = new TagBuilder("label");
            labelTag.MergeAttributes<string, object>(htmlAttributes);
            ModelState state;
            if (!string.IsNullOrEmpty(fullFieldName) && htmlHelper.ViewData.ModelState.TryGetValue(fullFieldName, out state) && state.Errors.Count > 0)
                labelTag.AddCssClass(MvcExtensions.ValidationLabelCssClassName);
            labelTag.Attributes.Add("for", CreateSanitizedID(templateInfo.GetFullHtmlFieldId(htmlFieldName), HtmlHelper.IdAttributeDotReplacement));
            labelTag.SetInnerText(text);
            return labelTag.ToMvcHtmlString(TagRenderMode.Normal);
        }

        #region from tagbuilder

        private static class Html401IdUtil
        {
            private static bool IsAllowableSpecialCharacter(char c)
            {
                var ch = c;
                return !(ch != '-' && ch != ':' && ch != '_');
            }

            private static bool IsDigit(char c)
            {
                return ('0' <= c && c <= '9');
            }

            public static bool IsLetter(char c)
            {
                return (('A' <= c && c <= 'Z') || ('a' <= c && c <= 'z'));
            }

            public static bool IsValidIdCharacter(char c)
            {
                return (!IsLetter(c) && !IsDigit(c) ? IsAllowableSpecialCharacter(c) : true);
            }
        }

        internal static string CreateSanitizedID(string originalId, string dotReplacement)
        {
            if (string.IsNullOrEmpty(originalId))
                return null;
            var c = originalId[0];
            if (!Html401IdUtil.IsLetter(c))
                return null;
            var b = new StringBuilder(originalId.Length);
            b.Append(c);
            for (int i = 1; i < originalId.Length; i++)
            {
                var ch2 = originalId[i];
                if (Html401IdUtil.IsValidIdCharacter(ch2))
                    b.Append(ch2);
                else
                    b.Append(dotReplacement);
            }
            return b.ToString();
        }

        #endregion
    }
}
