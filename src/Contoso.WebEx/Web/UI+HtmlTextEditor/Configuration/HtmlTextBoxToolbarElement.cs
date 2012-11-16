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
using System.Web.UI;
using System.Configuration;
namespace Contoso.Web.UI.Configuration
{
    /// <summary>
    /// HtmlTextBoxToolbarElement
    /// </summary>
    public class HtmlTextBoxToolbarElement : ConfigurationElementEx
    {
        /// <summary>
        /// Gets or sets the name of the configuration setting.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [ConfigurationProperty("name", IsRequired = true)]
        public override string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        /// <summary>
        /// Gets or sets the break on.
        /// </summary>
        /// <value>
        /// The break on.
        /// </value>
        [ConfigurationProperty("breakOn")]
        public HtmlTextBoxCommands BreakOn
        {
            get { return (HtmlTextBoxCommands)this["breakOn"]; }
            set { this["breakOn"] = value; }
        }

        /// <summary>
        /// Gets or sets the commands.
        /// </summary>
        /// <value>
        /// The commands.
        /// </value>
        [ConfigurationProperty("commands")]
        public HtmlTextBoxCommands Commands
        {
            get { return (HtmlTextBoxCommands)this["commands"]; }
            set { this["commands"] = value; }
        }
    }
}