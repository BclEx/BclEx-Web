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
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Contoso.Web.UI.Integrate
{
    /// <summary>
    /// VideoBlock
    /// </summary>
    public class VideoBlock : WebControl
    {
        private static Type _type = typeof(VideoBlock);
        private StringBuilder _textBuilder = new StringBuilder();
        private ClientScriptManager _scriptManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoBlock"/> class.
        /// </summary>
        public VideoBlock()
            : base()
        {
            Width = new Unit(300);
            Height = new Unit(300);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (EnsureScriptManager() && !_scriptManager.IsClientScriptIncludeRegistered(_type, "flowplayer"))
                _scriptManager.RegisterClientScriptInclude(_type, "flowplayer", _scriptManager.GetWebResourceUrl(_type, "Instinct.Resource_.FlowPlayer.flowplayer-3.1.4.min.js"));
        }

        /// <summary>
        /// Ensures the script manager.
        /// </summary>
        /// <returns></returns>
        public bool EnsureScriptManager()
        {
            if (_scriptManager == null)
            {
                var page = (HttpContext.Current.Handler as Page);
                if (page != null)
                    _scriptManager = page.ClientScript;
            }
            return (_scriptManager != null);
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            _textBuilder.Length = 0;
        }

        // [Controlbar] http://flowplayer.org/plugins/flash/controlbar.html
        /// <summary>
        /// Renders the specified w.
        /// </summary>
        /// <param name="w">The w.</param>
        protected override void Render(HtmlTextWriter w)
        {
            if (!EnsureParameters(w))
                return;
            var uri = Uri;
            var width = Width.ToString();
            var height = Height.ToString();
            switch (Path.GetExtension(uri).ToLowerInvariant())
            {
                case ".wmv":
                    w.Write(string.Format(@"
<object id=""{0}"" classid=""clsid:6bf52a52-394a-11d3-b153-00c04f79faa6"" width=""{2}"" height=""{3}"" codebase=""http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701""> 
    <param name=""autostart"" value=""false"" /> 
    <param name=""url"" value=""{1}"" /> 
    <param name=""src"" value=""{1}"" />
    <embed type=""application/x-mplayer2"" width=""{2}"" height=""{3}"" src=""{1}"" url=""{1}"" autostart=""false""></embed> 
</object>", HttpUtility.HtmlAttributeEncode(ID), HttpUtility.HtmlAttributeEncode(uri), width, height));
                    break;
                case ".flv":
                    if (EnsureScriptManager())
                    {
                        if (!_scriptManager.IsClientScriptIncludeRegistered(_type, "flowplayer"))
                        {
                            var flowplayerjsUri = _scriptManager.GetWebResourceUrl(_type, "Instinct.Resource_.FlowPlayer.flowplayer-3.1.4.min.js");
                            _scriptManager.RegisterClientScriptInclude(_type, "flowplayer", flowplayerjsUri);
                            w.Write("<script src=\"" + flowplayerjsUri + "\" type=\"text/javascript\"></script>");
                        }
                        w.Write(string.Format(@"
<a id=""{0}"" href=""{1}"" style=""display: block; width: {2}; height: {3};""></a>
<script type=""text/javascript"">
//<![CDATA[
flowplayer(""{0}"", ""{4}"", {{ plugins: {{ controls: {{ url: '/App_/Resource_/flowplayer.controls-3.1.5.swf' }} }} }});
//]]>
</script>", HttpUtility.HtmlAttributeEncode(ID), HttpUtility.HtmlAttributeEncode(uri), width, height
    , _scriptManager.GetWebResourceUrl(_type, "Instinct.Resource_.FlowPlayer.flowplayer-3.1.5.swf")
    , _scriptManager.GetWebResourceUrl(_type, "Instinct.Resource_.FlowPlayer.flowplayer.controls-3.1.5.swf")
));
                    }
                    break;
                case ".mov":
                    w.Write(string.Format(@"
<object id=""{0}"" classid=""clsid:02bf25d5-8c17-4b23-bc80-d3488abddc6b"" width=""{2}"" height=""{3}"" codebase=""http://www.apple.com/qtactivex/qtplugin.cab"">
    <param name=""src"" value=""{1}"" />
    <embed type=""video/quicktime"" width=""{2}"" height=""{3}"" src=""{1}"" pluginspage=""http://www.apple.com/quicktime/download/""></embed>
</object>", HttpUtility.HtmlAttributeEncode(ID), HttpUtility.HtmlAttributeEncode(uri), width, height));
                    break;
                case ".m4a":
                case ".m4p":
                case ".mp4":
                    w.Write(string.Format(@"
<object id=""{0}"" type=""video/mp4"" classid=""clsid:02bf25d5-8c17-4b23-bc80-d3488abddc6b"" width=""{2}"" height=""{3}"" codebase=""http://www.apple.com/qtactivex/qtplugin.cab"">
    <param name=""src"" value=""{1}"" />
    <embed type=""video/mp4"" width=""{2}"" height=""{3}"" src=""{1}"" pluginspage=""http://www.apple.com/quicktime/download/""></embed>
</object>", HttpUtility.HtmlAttributeEncode(ID), HttpUtility.HtmlAttributeEncode(uri), width, height));
                    break;
                case ".avi":
                    w.Write(string.Format(@"
<object id=""{0}"" type=""video/avi"" width=""{2}"" height=""{3}"">
    <param name=""src"" value=""{1}"" />
    <embed type=""video/avi"" width=""{2}"" height=""{3}"" src=""{1}""></embed>
</object>", HttpUtility.HtmlAttributeEncode(ID), HttpUtility.HtmlAttributeEncode(uri), width, height));
                    break;
            }
        }

        /// <summary>
        /// Ensures the parameters.
        /// </summary>
        /// <param name="w">The w.</param>
        /// <returns></returns>
        private bool EnsureParameters(HtmlTextWriter w)
        {
            var uri = Uri;
            if (string.IsNullOrEmpty(uri) || uri.Length < 5)
            {
                w.Write("invalid uri provided.");
                return false;
            }
            var extension = Path.GetExtension(uri).ToLowerInvariant();
            switch (extension)
            {
                case ".avi":
                case ".flv":
                case ".m4a":
                case ".mov":
                case ".mp4":
                case ".wmv":
                    break;
                default:
                    w.Write(string.Format("unsupported uri extention of '{0}'.", extension));
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Writes the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        public void Write(string text)
        {
            if (!string.IsNullOrEmpty(text))
                _textBuilder.Append(text);
        }
        /// <summary>
        /// Writes the specified control.
        /// </summary>
        /// <param name="control">The control.</param>
        public void Write(Control control)
        {
            if (control != null)
                using (var w = new StringWriter())
                {
                    using (var w2 = new HtmlTextWriter(w))
                        control.RenderControl(w2);
                    _textBuilder.Append(w.ToString());
                }
        }

        /// <summary>
        /// Gets or sets the URI.
        /// </summary>
        /// <value>
        /// The URI.
        /// </value>
        public string Uri { get; set; }
    }
}
