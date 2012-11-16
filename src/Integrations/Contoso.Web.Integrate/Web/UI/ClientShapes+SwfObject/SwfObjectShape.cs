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
// http://code.google.com/p/swfupload/
using System;
using System.Text;
using System.Collections;
using System.Web.UI;
using System.Linq;
namespace Contoso.Web.UI.ClientShapes
{
    /// <summary>
    /// SwfObjectShape
    /// </summary>
    public class SwfObjectShape : ClientScriptItemBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwfObjectShape"/> class.
        /// </summary>
        public SwfObjectShape()
        {
            var registrar = ClientScriptRegistrarSwfObjectShape.AssertRegistered();
            FlashVersionID = "7.0.0";
            ExpressInstallSwfUrl = registrar.SwfObjectExpressInstallFlashUrl;
        }

        /// <summary>
        /// Renders the specified b.
        /// </summary>
        /// <param name="b">The b.</param>
        public override void Render(StringBuilder b)
        {
            if (string.IsNullOrEmpty(Url))
                throw new ArgumentNullException("Url");
            if (string.IsNullOrEmpty(ElementID))
                throw new ArgumentNullException("ElementID");
            if (string.IsNullOrEmpty(Width))
                throw new ArgumentNullException("Width");
            if (string.IsNullOrEmpty(Height))
                throw new ArgumentNullException("Height");
            if (string.IsNullOrEmpty(FlashVersionID))
                throw new ArgumentNullException("FlashVersionID");
            if (EnumerableEx.IsNullOrEmpty(Variables) && EnumerableEx.IsNullOrEmpty(Parameters) && EnumerableEx.IsNullOrEmpty(Attributes))
                b.AppendLine(string.Format("swfobject.embedSWF({0},{1},{2},{3},{4});",
                    ClientScript.EncodeText(Url), ClientScript.EncodeText(ElementID), ClientScript.EncodeText(Width), ClientScript.EncodeText(Height), ClientScript.EncodeText(FlashVersionID)));
            else
            {
                var variables = ClientScript.EncodeDictionary(Variables);
                var parameters = ClientScript.EncodeDictionary(Parameters);
                var attributes = ClientScript.EncodeDictionary(Attributes);
                b.AppendLine(string.Format("swfobject.embedSWF({0},{1},{2},{3},{4},{5},{6},{7},{8});",
                    ClientScript.EncodeText(Url), ClientScript.EncodeText(ElementID), ClientScript.EncodeText(Width), ClientScript.EncodeText(Height), ClientScript.EncodeText(FlashVersionID),
                    (!UseExpressInstall || (string.IsNullOrEmpty(ExpressInstallSwfUrl)) ? "false" : ClientScript.EncodeText(ExpressInstallSwfUrl)),
                    (!EnumerableEx.IsNullOrEmpty(Variables) ? variables : ClientScript.EmptyObject),
                    (!EnumerableEx.IsNullOrEmpty(Parameters) ? parameters : ClientScript.EmptyObject),
                    (!EnumerableEx.IsNullOrEmpty(Attributes) ? attributes : ClientScript.EmptyObject)));
            }
        }

        #region Options

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the element ID.
        /// </summary>
        /// <value>
        /// The element ID.
        /// </value>
        public string ElementID { get; set; }
        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public string Width { get; set; }
        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public string Height { get; set; }
        /// <summary>
        /// Gets or sets the flash version ID.
        /// </summary>
        /// <value>
        /// The flash version ID.
        /// </value>
        public string FlashVersionID { get; set; }
        /// <summary>
        /// Gets or sets the express install SWF URL.
        /// </summary>
        /// <value>
        /// The express install SWF URL.
        /// </value>
        public string ExpressInstallSwfUrl { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [use express install].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use express install]; otherwise, <c>false</c>.
        /// </value>
        public bool UseExpressInstall { get; set; }
        /// <summary>
        /// Gets or sets the variables.
        /// </summary>
        /// <value>
        /// The variables.
        /// </value>
        public Nparams Variables { get; set; }
        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        public Nparams Parameters { get; set; }
        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        public Nparams Attributes { get; set; }

        #endregion
    }
}