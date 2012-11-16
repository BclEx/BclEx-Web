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
using System.Patterns.UI.Forms;
namespace System.Web.UI.WebControls
{
    /// <summary>
    /// RadioButtonEx
    /// </summary>
    public class RadioButtonEx : RadioButton, IFormControl
    {
        /// <summary>
        /// Gets or sets the view mode.
        /// </summary>
        /// <value>
        /// The view mode.
        /// </value>
        public FormFieldViewMode ViewMode { get; set; }

        /// <summary>
        /// Renders the specified w.
        /// </summary>
        /// <param name="w">The w.</param>
        protected override void Render(HtmlTextWriter w)
        {
            switch (ViewMode)
            {
                case FormFieldViewMode.Static:
                    RenderStaticText(w);
                    break;
                case FormFieldViewMode.StaticWithHidden:
                    RenderStaticText(w);
                    RenderHidden(w);
                    break;
                case FormFieldViewMode.Hidden:
                    RenderHidden(w);
                    break;
                default:
                    base.Render(w);
                    break;
            }
        }

        /// <summary>
        /// Renders the hidden.
        /// </summary>
        /// <param name="w">The w.</param>
        protected void RenderHidden(HtmlTextWriter w)
        {
            w.AddAttribute(HtmlTextWriterAttribute.Type, "hidden");
            w.AddAttribute(HtmlTextWriterAttribute.Id, ClientID);
            w.AddAttribute(HtmlTextWriterAttribute.Name, UniqueID);
            w.AddAttribute(HtmlTextWriterAttribute.Value, Text);
            w.RenderBeginTag(HtmlTextWriterTag.Input);
            w.RenderEndTag();
        }

        /// <summary>
        /// Renders the static text.
        /// </summary>
        /// <param name="w">The w.</param>
        protected virtual void RenderStaticText(HtmlTextWriter w)
        {
            string text = Text;
            string formatAB;
            if (TextAlign == TextAlign.Right)
            {
                text = (!string.IsNullOrEmpty(text) ? HttpContextEx.EmptyHtml + Text : string.Empty);
                formatAB = "[{0}]{1}";
            }
            else
            {
                text = (!string.IsNullOrEmpty(text) ? Text + HttpContextEx.EmptyHtml : string.Empty);
                formatAB = "{1}[{0}]";
            }
            w.RenderBeginTag(HtmlTextWriterTag.Span);
            w.WriteEncodedText(string.Format(formatAB, (Checked ? "X" : HttpContextEx.EmptyHtml), text));
            w.RenderEndTag();
        }
    }
}
