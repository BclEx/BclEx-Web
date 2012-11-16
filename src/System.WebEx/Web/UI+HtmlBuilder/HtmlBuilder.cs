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
using System.IO;
using System.Patterns.UI.Forms;
namespace System.Web.UI
{
    /// <summary>
    /// HtmlBuilder
    /// </summary>
    public partial class HtmlBuilder : IDisposable
    {
        private HtmlTextWriterEx _textWriter;
        private int _writeCount = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlBuilder"/> class.
        /// </summary>
        /// <param name="w">The w.</param>
        public HtmlBuilder(HtmlTextWriter w)
            : this(new HtmlTextWriterEx(w)) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlBuilder"/> class.
        /// </summary>
        /// <param name="w">The w.</param>
        public HtmlBuilder(HtmlTextWriterEx w)
        {
            _textWriter = w;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Close(); _elementStack.Clear();
        }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void Close() { _textWriter.Close(); }

        /// <summary>
        /// Gets the inner writer.
        /// </summary>
        public HtmlTextWriter InnerWriter
        {
            get { _writeCount++; return _textWriter; }
        }

        /// <summary>
        /// Renders the control.
        /// </summary>
        /// <param name="control">The control.</param>
        public void RenderControl(object control)
        {
            if (control == null)
                throw new ArgumentNullException("control");
            _writeCount++;
            ((Control)control).RenderControl(_textWriter);
        }
        /// <summary>
        /// Renders the control.
        /// </summary>
        /// <param name="control">The control.</param>
        public void RenderControl(Control control)
        {
            if (control == null)
                throw new ArgumentNullException("control");
            _writeCount++;
            control.RenderControl(_textWriter);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            _textWriter.Flush();
            _writeCount++;
            var innerStringWriter = (_textWriter.InnerWriter as StringWriter);
            return (innerStringWriter != null ? innerStringWriter.ToString() : null);
        }

        #region Class-Factory

        /// <summary>
        /// Creates the HTML builder div tag.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public virtual HtmlBuilderDivTag CreateHtmlBuilderDivTag(HtmlBuilder b, Nparams args) { return new HtmlBuilderDivTag(b, args); }
        /// <summary>
        /// Creates the HTML builder form tag.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="formContext">The form context.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public virtual HtmlBuilderFormTag CreateHtmlBuilderFormTag(HtmlBuilder b, IFormContext formContext, Nparams args) { return new HtmlBuilderFormTag(b, formContext, args); }
        /// <summary>
        /// Creates the HTML builder table tag.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public virtual HtmlBuilderTableTag CreateHtmlBuilderTableTag(HtmlBuilder b, Nparams args) { return new HtmlBuilderTableTag(b, args.Get<HtmlBuilderTableTag.TableAttrib>()); }

        #endregion
    }
}