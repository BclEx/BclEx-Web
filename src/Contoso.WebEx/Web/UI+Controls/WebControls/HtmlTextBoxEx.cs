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
using System;
using System.Abstract;
using System.Patterns.UI.Forms;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Contoso.Web.UI.WebControls
{
    /// <summary>
    /// IHtmlTextBox
    /// </summary>
    public interface IHtmlTextBox { }

    /// <summary>
    /// HtmlTextBoxEx
    /// </summary>
    public class HtmlTextBoxEx : TextBoxEx
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlTextBoxEx"/> class.
        /// </summary>
        public HtmlTextBoxEx() { TextMode = TextBoxMode.MultiLine; }

        /// <summary>
        /// Gets or sets the HTML text editor id.
        /// </summary>
        /// <value>
        /// The HTML text editor id.
        /// </value>
        public string HtmlTextEditorId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [in debug mode].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [in debug mode]; otherwise, <c>false</c>.
        /// </value>
        public bool InDebugMode { get; set; }

        /// <summary>
        /// Gets or sets the toolbar id.
        /// </summary>
        /// <value>
        /// The toolbar id.
        /// </value>
        public string ToolbarId { get; set; }

        /// <summary>
        /// Gets or sets the resource folder.
        /// </summary>
        /// <value>
        /// The resource folder.
        /// </value>
        public string ResourceFolder { get; set; }

        /// <summary>
        /// Gets or sets the internal editor.
        /// </summary>
        /// <value>
        /// The internal editor.
        /// </value>
        public WebControl InternalEditor { get; set; }

        /// <summary>
        /// Raises the <see cref="E:Load"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //if (ViewMode == FormFieldViewMode.Static)
            //    Text = Page.Request.Form[ClientID];
        }

        /// <summary>
        /// Raises the <see cref="E:Init"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //var htmlTextBoxContext = ServiceLocator.Resolve<IHtmlTextBoxContext>(HtmlTextEditorId, ToolbarId, ResourceFolder);
            //if (InDebugMode)
            //    htmlTextBoxContext.InDebugMode = true;
            //InternalEditor = (WebControl)ServiceLocator.Resolve<IHtmlTextBox>(null, htmlTextBoxContext);
            //InternalEditor.ID = ID;
            //ID += "_Pane";
            //InternalEditor.Width = Width;
            //InternalEditor.Height = Height;
            //Controls.Add(InternalEditor);
        }

        /// <summary>
        /// Renders the specified w.
        /// </summary>
        /// <param name="w">The w.</param>
        protected override void Render(HtmlTextWriter w)
        {
            switch (ViewMode)
            {
                case FormFieldViewMode.Static:
                case FormFieldViewMode.StaticWithHidden:
                case FormFieldViewMode.Hidden:
                    base.Render(w);
                    break;
                default:
                    InternalEditor.RenderControl(w);
                    break;
            }
        }
    }
}
