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
using System.Text;
using System.Globalization;
namespace System.Web.UI
{
    /// <summary>
    /// ClientScript
    /// </summary>
    public static class ClientScript
    {
        /// <summary>
        /// EmptyFunction
        /// </summary>
        public static string EmptyFunction = "function(){}";
        /// <summary>
        /// EmptyObject
        /// </summary>
        public static string EmptyObject = "{}";
        /// <summary>
        /// EmptyArray
        /// </summary>
        public static string EmptyArray = "[]";

        #region Encode

        /// <summary>
        /// Encodes the array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        public static string EncodeArray(string[] array)
        {
            return (array != null ? "[" + string.Join(",", array) + "]" : "null");
        }

        /// <summary>
        /// Encodes the bool.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <returns></returns>
        public static string EncodeBool(bool value)
        {
            return (value ? "true" : "false");
        }

        /// <summary>
        /// Encodes the date time.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string EncodeDateTime(DateTime value)
        {
            return value.ToString();
        }

        /// <summary>
        /// Encodes the decimal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string EncodeDecimal(decimal value)
        {
            return value.ToString();
        }

        /// <summary>
        /// Encodes the expression.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string EncodeExpression(string value)
        {
            return value;
        }

        /// <summary>
        /// Encodes the function.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string EncodeFunction(string value)
        {
            return value;
        }

        /// <summary>
        /// Encodes the dictionary.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string EncodeDictionary(IDictionary<string, string> value) { return EncodeDictionary(value, false); }
        /// <summary>
        /// Encodes the dictionary.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="includeNewLine">if set to <c>true</c> [include new line].</param>
        /// <returns></returns>
        public static string EncodeDictionary(IDictionary<string, string> value, bool includeNewLine)
        {
            if (value == null)
                return "null";
            if (value.Count == 0)
                return "{}";
            var b = new StringBuilder("{");
            if (includeNewLine)
            {
                foreach (string key in value.Keys)
                    b.AppendLine(key + ": " + value[key] + ",");
                b.Length -= 3;
            }
            else
            {
                foreach (string key in value.Keys)
                    b.Append(key + ": " + value[key] + ", ");
                b.Length -= 2;
            }
            b.Append("}");
            return b.ToString();
        }
        /// <summary>
        /// Encodes the dictionary.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public static string EncodeDictionary(Nparams args) { return EncodeDictionary(args.ToDictionary(), false); }
        /// <summary>
        /// Encodes the dictionary.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <param name="includeNewLine">if set to <c>true</c> [include new line].</param>
        /// <returns></returns>
        public static string EncodeDictionary(Nparams args, bool includeNewLine) { return EncodeDictionary(args.ToDictionary(), includeNewLine); }
        /// <summary>
        /// Encodes the dictionary.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string EncodeDictionary(IDictionary<string, object> value) { return EncodeDictionary(value, false); }
        /// <summary>
        /// Encodes the dictionary.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="includeNewLine">if set to <c>true</c> [include new line].</param>
        /// <returns></returns>
        public static string EncodeDictionary(IDictionary<string, object> value, bool includeNewLine)
        {
            if (value == null)
                return "null";
            if (value.Count == 0)
                return "{}";
            var b = new StringBuilder("{");
            if (includeNewLine)
            {
                foreach (string key in value.Keys)
                    b.AppendLine(key + ": " + value[key] + ", ");
                b.Length -= 4;
            }
            else
            {
                foreach (string key in value.Keys)
                    b.Append(key + ": " + value[key] + ", ");
                b.Length -= 2;
            }
            b.Append("}");
            return b.ToString();
        }

        /// <summary>
        /// Encodes the int32.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string EncodeInt32(int value)
        {
            return value.ToString();
        }

        /// <summary>
        /// Encodes the reg exp.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string EncodeRegExp(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("value");
            return value;
        }

        /// <summary>
        /// Encodes the text.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string EncodeText(string value)
        {
            if (value == null)
                return "null";
            else if (value.Length == 0)
                return "''";
            else
            {
                var b = new StringBuilder("'", value.Length);
                InternalEscapeText(InternalEscapeTextType.Text, b, value);
                b.Append("'");
                return b.ToString();
            }
        }

        /// <summary>
        /// Encodes the partial text.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string EncodePartialText(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            var b = new StringBuilder(value.Length);
            InternalEscapeText(InternalEscapeTextType.Text, b, value);
            return b.ToString();
        }

        /// <summary>
        /// InternalEscapeTextType
        /// </summary>
        private enum InternalEscapeTextType
        {
            Text,
        }

        private static void InternalEscapeText(InternalEscapeTextType textType, StringBuilder b, string value)
        {
            foreach (char c in value)
            {
                var code = (int)c;
                switch (c)
                {
                    case '\b':
                        b.Append("\\right");
                        break;
                    case '\f':
                        b.Append("\\f");
                        break;
                    case '\n':
                        b.Append("\\n");
                        break;
                    case '\r':
                        b.Append("\\r");
                        break;
                    case '\t':
                        b.Append("\\t");
                        break;
                    case '\\':
                    case '\'':
                        b.Append("\\" + c);
                        break;
                    default:
                        if (code >= 32 && code < 128)
                            b.Append(c);
                        else
                            b.AppendFormat(CultureInfo.InvariantCulture.NumberFormat, "\\u{0:X4}", code);
                        break;
                }
            }
        }

        #endregion
    }
}
