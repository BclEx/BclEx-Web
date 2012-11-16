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
using System.Text;
using System.Collections.Generic;
using System.Abstract;
namespace System.Web.UI.WebControls
{
    /// <summary>
    /// ClientScriptEmitter
    /// </summary>
    public class ClientScriptEmitter : Control
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientScriptEmitter"/> class.
        /// </summary>
        public ClientScriptEmitter()
        {
            Inject = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ClientScriptEmitter"/> is inject.
        /// </summary>
        /// <value>
        ///   <c>true</c> if inject; otherwise, <c>false</c>.
        /// </value>
        public bool Inject { get; set; }

        /// <summary>
        /// Gets or sets the client script manager.
        /// </summary>
        /// <value>
        /// The client script manager.
        /// </value>
        [ServiceDependency]
        public IClientScriptManager ClientScriptManager { get; set; }

        /// <summary>
        /// Gets or sets the shard.
        /// </summary>
        /// <value>
        /// The shard.
        /// </value>
        public Type Shard { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [in HTML head].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [in HTML head]; otherwise, <c>false</c>.
        /// </value>
        public bool InHtmlHead { get; set; }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
        protected override void OnPreRender(EventArgs e)
        {
            if (InHtmlHead)
                if (Shard == null)
                    Shard = typeof(System.Web.UI.HtmlControls.HtmlHead);
                else
                    throw new InvalidOperationException("Cant set shard and InHtmlHead");
            if (Inject)
            {
                ServiceLocatorManager.Current.Inject(this);
                if (ClientScriptManager == null)
                    throw new InvalidOperationException("ClientScriptManager required");
            }
        }

        /// <summary>
        /// Renders the specified w.
        /// </summary>
        /// <param name="w">The w.</param>
        protected override void Render(HtmlTextWriter w)
        {
            if (ClientScriptManager == null)
                throw new InvalidOperationException("ClientScriptManager required");
            var repository = ClientScriptManager.GetRepository(Shard ?? typeof(IClientScriptManager));
            RenderItems(w, repository.Includes, false);
            RenderItems(w, repository.Items, true);
        }

        private static void RenderItems(HtmlTextWriter w, Dictionary<string, ClientScriptItemBase> items, bool addScriptTags)
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
                    w.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
                    w.RenderBeginTag(HtmlTextWriterTag.Script);
                    w.WriteLine("//<![CDATA[");
                    w.Write(b.ToString());
                    w.WriteLine("//]]>");
                    w.RenderEndTag();
                }
                else
                    w.Write(b.ToString());
            }
        }
    }
}
