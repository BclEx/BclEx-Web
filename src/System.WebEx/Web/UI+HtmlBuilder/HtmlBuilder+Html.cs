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
namespace System.Web.UI
{
    public partial class HtmlBuilder
    {
        /// <summary>
        /// Adds the attribute.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <param name="value">The value.</param>
        public void AddAttribute(string attribute, string value)
        {
            if (string.IsNullOrEmpty(attribute))
                throw new ArgumentNullException("attribute");
            _writeCount++;
            if (!attribute.StartsWith("style", StringComparison.OrdinalIgnoreCase))
                _textWriter.AddAttribute(attribute, value);
            else
                _textWriter.AddStyleAttribute(attribute.Substring(5), value);
        }
        /// <summary>
        /// Adds the attribute.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <param name="value">The value.</param>
        public void AddAttribute(HtmlAttribute attribute, string value)
        {
            _writeCount++;
            var attribute2 = (int)attribute;
            if (attribute2 < HtmlTextWriterEx.HtmlAttributeSplit)
                _textWriter.AddAttribute((HtmlTextWriterAttribute)attribute2, value);
            else if (attribute2 > HtmlTextWriterEx.HtmlAttributeSplit)
                _textWriter.AddStyleAttribute((HtmlTextWriterStyle)attribute2 - HtmlTextWriterEx.HtmlAttributeSplit - 1, value);
            else
                throw new ArgumentException(string.Format("Local.InvalidHtmlAttribA", attribute.ToString()), "attribute");
        }

        //public void AddAttribute(params string[] args) { AddAttribute(Nparams.Parse(args), null); }
        /// <summary>
        /// Adds the attribute.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <param name="throwOnAttributes">The throw on attributes.</param>
        public void AddAttribute(Nparams args, string[] throwOnAttributes)
        {
            if (args == null)
                throw new ArgumentNullException("args");
            //foreach (string key in attrib.KeyEnum)
            //{
            //    var value = attrib[key];
            //    int htmlAttrib;
            //    if (s_htmlAttribEnumInt32Parser.TryGetValue(key, out htmlAttrib) == true)
            //    {
            //        AddAttribute((HtmlAttrib)htmlAttrib, value);
            //        continue;
            //    }
            //    else if (key.Length > 0)
            //    {
            //        _writeCount++;
            //        if (key.StartsWith("style", System.StringComparison.InvariantCultureIgnoreCase) == false)
            //        {
            //            _textWriter.AddAttribute(key, value);
            //            continue;
            //        }
            //        _textWriter.AddStyleAttribute(key.Substring(5), value);
            //        continue;
            //    }
            //    throw new ArgumentException(string.Format(Local.InvalidHtmlAttribA, key), "attrib");
            //}
        }

        /// <summary>
        /// Adds the text writer attribute.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public void AddTextWriterAttribute(string name, string value) { _writeCount++; _textWriter.AddAttribute(name, value); }
        /// <summary>
        /// Adds the text writer attribute.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <param name="value">The value.</param>
        public void AddTextWriterAttribute(HtmlTextWriterAttribute attribute, string value) { _writeCount++; _textWriter.AddAttribute(attribute, value); }

        /// <summary>
        /// Adds the text writer style attribute.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public void AddTextWriterStyleAttribute(string name, string value) { _writeCount++; _textWriter.AddStyleAttribute(name, value); }
        /// <summary>
        /// Adds the text writer style attribute.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <param name="value">The value.</param>
        public void AddTextWriterStyleAttribute(HtmlTextWriterStyle attribute, string value) { _writeCount++; _textWriter.AddStyleAttribute(attribute, value); }

        /// <summary>
        /// Begins the HTML tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder BeginHtmlTag(HtmlTag tag, params string[] args) { return BeginHtmlTag(tag, Nparams.Parse(args)); }
        /// <summary>
        /// Begins the HTML tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder BeginHtmlTag(HtmlTag tag, Nparams args)
        {
            if (tag == HtmlTag.Unknown || tag >= HtmlTag._FormReference)
                throw new ArgumentException(string.Format("Local.InvalidHtmlTagA", tag.ToString()), "tag");
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.RenderBeginTag((HtmlTextWriterTag)tag);
            return this;
        }
        /// <summary>
        /// Begins the HTML tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder BeginHtmlTag(string tag, params string[] args) { return BeginHtmlTag(tag, Nparams.Parse(args)); }
        /// <summary>
        /// Begins the HTML tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder BeginHtmlTag(string tag, Nparams args)
        {
            if (string.IsNullOrEmpty(tag))
                throw new ArgumentNullException("tag");
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.RenderBeginTag(tag);
            return this;
        }

        /// <summary>
        /// Empties the HTML tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder EmptyHtmlTag(HtmlTag tag, params string[] args) { return EmptyHtmlTag(tag, Nparams.Parse(args)); }
        /// <summary>
        /// Empties the HTML tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder EmptyHtmlTag(HtmlTag tag, Nparams args)
        {
            if (tag == HtmlTag.Unknown || tag >= HtmlTag._FormReference)
                throw new ArgumentException(string.Format("Local.InvalidHtmlTagA", tag.ToString()), "tag");
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.RenderBeginTag((HtmlTextWriterTag)tag);
            _textWriter.RenderEndTag();
            return this;
        }

        /// <summary>
        /// Empties the HTML tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder EmptyHtmlTag(string tag, params string[] args) { return EmptyHtmlTag(tag, Nparams.Parse(args)); }
        /// <summary>
        /// Empties the HTML tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder EmptyHtmlTag(string tag, Nparams args)
        {
            if (string.IsNullOrEmpty(tag))
                throw new ArgumentNullException("tag");
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.RenderBeginTag(tag);
            _textWriter.RenderEndTag();
            return this;
        }

        /// <summary>
        /// Ends the HTML tag.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder EndHtmlTag()
        {
            _writeCount++;
            _textWriter.RenderEndTag();
            return this;
        }
    }
}