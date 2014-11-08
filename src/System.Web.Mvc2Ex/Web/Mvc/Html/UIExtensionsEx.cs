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
using System.Globalization;
using System.IO;
using System.Text;
using System.Web.UI;
namespace System.Web.Mvc.Html
{
    /// <summary>
    /// UIExtensionsEx
    /// </summary>
    public static partial class UIExtensionsEx
    {
        /// <summary>
        /// Clients the script.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <returns></returns>
        public static MvcHtmlString ClientScriptEmitHead(this HtmlHelper htmlHelper) { return ClientScriptEmitHelper(htmlHelper, HttpContext.Current.Get<IClientScriptManager>(), typeof(System.Web.UI.HtmlControls.HtmlHead)); }
        /// <summary>
        /// Clients the script.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="manager">The manager.</param>
        /// <returns></returns>
        public static MvcHtmlString ClientScriptEmitHead(this HtmlHelper htmlHelper, IClientScriptManager manager) { return ClientScriptEmitHelper(htmlHelper, manager, typeof(System.Web.UI.HtmlControls.HtmlHead)); }
        /// <summary>
        /// Clients the script.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <returns></returns>
        public static MvcHtmlString ClientScriptEmit(this HtmlHelper htmlHelper) { return ClientScriptEmitHelper(htmlHelper, HttpContext.Current.Get<IClientScriptManager>(), null); }
        /// <summary>
        /// Clients the script.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="shard">The shard.</param>
        /// <returns></returns>
        public static MvcHtmlString ClientScriptEmit(this HtmlHelper htmlHelper, Type shard) { return ClientScriptEmitHelper(htmlHelper, HttpContext.Current.Get<IClientScriptManager>(), shard); }
        /// <summary>
        /// Clients the script.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="manager">The manager.</param>
        /// <returns></returns>
        public static MvcHtmlString ClientScriptEmit(this HtmlHelper htmlHelper, IClientScriptManager manager) { return ClientScriptEmitHelper(htmlHelper, manager, null); }
        /// <summary>
        /// Clients the script.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="manager">The manager.</param>
        /// <param name="shard">The shard.</param>
        /// <returns></returns>
        public static MvcHtmlString ClientScriptEmit(this HtmlHelper htmlHelper, IClientScriptManager manager, Type shard) { return ClientScriptEmitHelper(htmlHelper, manager, shard); }

        private static MvcHtmlString ClientScriptEmitHelper(HtmlHelper htmlHelper, IClientScriptManager manager, Type shard)
        {
            if (manager == null)
                throw new ArgumentNullException("manager");
            using (var w = new StringWriter(CultureInfo.CurrentCulture))
            {
                var repository = manager.GetRepository(shard ?? typeof(IClientScriptManager));
                ClientScriptRenderItems(w, repository.Includes, false);
                ClientScriptRenderItems(w, repository.Items, true);
                return MvcHtmlString.Create(w.ToString());
            }
        }

        private static void ClientScriptRenderItems(StringWriter w, Dictionary<string, ClientScriptItemBase> items, bool addScriptTags)
        {
            if (items.Count > 0)
            {
                var b = new StringBuilder();
                foreach (var block in items.Values)
                    block.Render(b);
                items.Clear();
                //
                if (addScriptTags)
                {
                    w.WriteLine("<script type=\"text/javascript\">");
                    w.WriteLine("//<![CDATA[");
                    w.Write(b.ToString());
                    w.WriteLine("//]]>");
                    w.WriteLine("</script>");
                }
                else
                    w.Write(b.ToString());
            }
        }

    }
}
