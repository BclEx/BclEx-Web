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
namespace System.Web.UI
{
    /// <summary>
    /// IHtmlTextBoxContext
    /// </summary>
    public interface IHtmlTextBoxContext
    {
        /// <summary>
        /// Gets the anchor CSS styles.
        /// </summary>
        Dictionary<string, string> AnchorCssStyles { get; }
        /// <summary>
        /// Gets the body CSS styles.
        /// </summary>
        Dictionary<string, string> BodyCssStyles { get; }
        /// <summary>
        /// Gets or sets a value indicating whether [in debug mode].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [in debug mode]; otherwise, <c>false</c>.
        /// </value>
        bool InDebugMode { get; set; }
        /// <summary>
        /// Gets or sets the design mode body tag CSS class.
        /// </summary>
        /// <value>
        /// The design mode body tag CSS class.
        /// </value>
        string DesignModeBodyTagCssClass { get; set; }
        /// <summary>
        /// Gets or sets the design mode CSS URI.
        /// </summary>
        /// <value>
        /// The design mode CSS URI.
        /// </value>
        string DesignModeCssUri { get; set; }
        /// <summary>
        /// Gets the element styles.
        /// </summary>
        Dictionary<string, string> ElementStyles { get; }
        /// <summary>
        /// Gets or sets the element CSS URI.
        /// </summary>
        /// <value>
        /// The element CSS URI.
        /// </value>
        string ElementCssUri { get; set; }
        /// <summary>
        /// Gets the fonts.
        /// </summary>
        Dictionary<string, string> Fonts { get; }
        /// <summary>
        /// Gets the image CSS styles.
        /// </summary>
        Dictionary<string, string> ImageCssStyles { get; }
        /// <summary>
        /// Gets or sets the resource folder.
        /// </summary>
        /// <value>
        /// The resource folder.
        /// </value>
        string ResourceFolder { get; set; }
        /// <summary>
        /// Gets the plugins.
        /// </summary>
        Dictionary<string, string> Plugins { get; }
        /// <summary>
        /// Gets the table CSS styles.
        /// </summary>
        Dictionary<string, string> TableCssStyles { get; }
        /// <summary>
        /// Gets or sets the toolbar break on.
        /// </summary>
        /// <value>
        /// The toolbar break on.
        /// </value>
        HtmlTextBoxCommands ToolbarBreakOn { get; set; }
        /// <summary>
        /// Gets or sets the toolbar commands.
        /// </summary>
        /// <value>
        /// The toolbar commands.
        /// </value>
        HtmlTextBoxCommands ToolbarCommands { get; set; }
    }
}
