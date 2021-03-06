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
using System.Web.Script.Serialization;
using System.Linq.Expressions;
namespace System.Web.Mvc
{
    /// <summary>
    /// MvcExtensions
    /// </summary>
    public static partial class MvcExtensions
    {
        /// <summary>
        /// Parses the validate for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="modelState">State of the model.</param>
        /// <param name="expression">The expression.</param>
        public static void ParseValidateFor<TModel>(this ModelStateDictionary modelState, Expression<Func<TModel, object>> expression) { ParseValidateFor(modelState, ExpressionHelper.GetExpressionText(expression)); }
        /// <summary>
        /// Parses the validate for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="modelState">State of the model.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="modifer">The modifer.</param>
        public static void ParseValidateFor<TModel>(this ModelStateDictionary modelState, Expression<Func<TModel, object>> expression, string modifer) { ParseValidateFor(modelState, ExpressionHelper.GetExpressionText(expression) + modifer); }
        /// <summary>
        /// Parses the validate for.
        /// </summary>
        /// <param name="modelState">State of the model.</param>
        /// <param name="expressionText">The expression text.</param>
        public static void ParseValidateFor(this ModelStateDictionary modelState, string expressionText)
        {
            ModelErrorCollection errors;
            if (modelState.ContainsKey(expressionText) && (errors = modelState[expressionText].Errors) != null && errors.Count > 0)
                foreach (var error in new List<ModelError>(errors))
                {
                    string errorMessage = error.ErrorMessage;
                    if (!errorMessage.StartsWith("JSER:"))
                        continue;
                    errors.Remove(error);
                    var serializer = new JavaScriptSerializer();
                    var data = serializer.DeserializeObject(errorMessage.Substring(5));
                    ApplyValidateValue(modelState, expressionText, data);
                }
        }

        private static void ApplyValidateValue(ModelStateDictionary modelState, string expressionText, object data)
        {
            foreach (var value in ParseJser(data))
            {
                var valueAsDictionary = (value as Dictionary<string, object>);
                if (valueAsDictionary != null)
                    ApplyValidateValue(modelState, expressionText, valueAsDictionary);
            }
        }
        private static void ApplyValidateValue(ModelStateDictionary modelState, string expressionText, Dictionary<string, object> items)
        {
            foreach (var item in items)
            {
                string key = item.Key;
                switch (key[0])
                {
                    case '/': key = key.Substring(1); break;
                    case '.': key = expressionText + key.Substring(1); break;
                    default: key = expressionText + "." + key; break;
                }
                modelState.AddModelError(key, (string)item.Value);
            }
        }

        private static IEnumerable<object> ParseJser(object value)
        {
            var valueAsEnumerable = (value as IEnumerable<object>);
            if (valueAsEnumerable == null)
                yield return value;
            else
                foreach (var value2 in valueAsEnumerable)
                    yield return ParseJser(value2);
        }

        /// <summary>
        /// Generates the jser string.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public static string GenerateJserString(Dictionary<string, object> items)
        {
            var serializer = new JavaScriptSerializer();
            return "JSER:" + serializer.Serialize(items);
        }

        /// <summary>
        /// Adds the model error for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="viewData">The view data.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="exception">The exception.</param>
        public static void AddModelErrorFor<TModel, TProperty>(this ViewDataDictionary viewData, Expression<Func<TModel, TProperty>> expression, Exception exception) { AddModelError(viewData, ExpressionHelper.GetExpressionText(expression), exception); }
        /// <summary>
        /// Adds the model error.
        /// </summary>
        /// <param name="viewData">The view data.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="exception">The exception.</param>
        public static void AddModelError(this ViewDataDictionary viewData, string expression, Exception exception)
        {
            var templateInfo = viewData.TemplateInfo;
            var fullFieldName = templateInfo.GetFullHtmlFieldName(expression);
            viewData.ModelState.AddModelError(fullFieldName, exception);
        }

        /// <summary>
        /// Adds the model error for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="viewData">The view data.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="errorMessage">The error message.</param>
        public static void AddModelErrorFor<TModel, TProperty>(this ViewDataDictionary viewData, Expression<Func<TModel, TProperty>> expression, string errorMessage) { AddModelError(viewData, ExpressionHelper.GetExpressionText(expression), errorMessage); }
        /// <summary>
        /// Adds the model error.
        /// </summary>
        /// <param name="viewData">The view data.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="errorMessage">The error message.</param>
        public static void AddModelError(ViewDataDictionary viewData, string expression, string errorMessage)
        {
            var templateInfo = viewData.TemplateInfo;
            var fullFieldName = templateInfo.GetFullHtmlFieldName(expression);
            viewData.ModelState.AddModelError(fullFieldName, errorMessage);
        }

        /// <summary>
        /// Determines whether the specified dictionary has errors.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <returns>
        ///   <c>true</c> if the specified dictionary has errors; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasErrors(this ModelStateDictionary dictionary)
        {
            return dictionary.Values.Any(x => x.Errors.Count > 0);
        }
    }
}