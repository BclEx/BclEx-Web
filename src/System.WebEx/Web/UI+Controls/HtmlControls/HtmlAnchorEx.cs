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
using System.Web.UI.WebControls;
namespace System.Web.UI.HtmlControls
{
    /// <summary>
    /// HtmlAnchorEx
    /// </summary>
    public class HtmlAnchorEx : HtmlAnchor
    {
        private static readonly object _eventCommandKey = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlAnchorEx"/> class.
        /// </summary>
        public HtmlAnchorEx()
            : base()
        {
            // added to force a raise event when clicked
            ServerClick += new EventHandler(HtmlAnchor_ServerClick);
        }

        /// <summary>
        /// Gets or sets the client confirmation text.
        /// </summary>
        /// <value>
        /// The client confirmation text.
        /// </value>
        public string ClientConfirmationText { get; set; }

        /// <summary>
        /// Gets or sets the command argument.
        /// </summary>
        /// <value>
        /// The command argument.
        /// </value>
        public string CommandArgument { get; set; }

        /// <summary>
        /// Gets or sets the name of the command.
        /// </summary>
        /// <value>
        /// The name of the command.
        /// </value>
        public string CommandName { get; set; }

        /// <summary>
        /// Handles the ServerClick event of the HtmlAnchor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void HtmlAnchor_ServerClick(object sender, EventArgs e) { }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"/> event and registers client script for generating a postback.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnPreRender(EventArgs e)
        {
            if (!string.IsNullOrEmpty(ClientConfirmationText))
                Attributes["onclick"] = "if(!confirm(" + ClientScript.EncodeText(ClientConfirmationText) + "))return(false);";
            base.OnPreRender(e);
        }

        /// <summary>
        /// Raises events for the <see cref="T:System.Web.UI.HtmlControls.HtmlAnchor"/> control when it posts back to the server.
        /// </summary>
        /// <param name="eventArgument">The argument for the event.</param>
        protected override void RaisePostBackEvent(string eventArgument)
        {
            base.RaisePostBackEvent(eventArgument);
            if (!string.IsNullOrEmpty(CommandName))
                OnCommand(new CommandEventArgs(CommandName, CommandArgument));
        }

        /// <summary>
        /// Occurs when [command].
        /// </summary>
        public event EventHandler Command
        {
            add { base.Events.AddHandler(_eventCommandKey, value); }
            remove { base.Events.RemoveHandler(_eventCommandKey, value); }
        }

        /// <summary>
        /// Raises the <see cref="E:Command"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected virtual void OnCommand(EventArgs e)
        {
            var handler = (EventHandler)base.Events[_eventCommandKey];
            if (handler != null)
                handler(this, e);
            base.RaiseBubbleEvent(this, e);
        }
    }
}