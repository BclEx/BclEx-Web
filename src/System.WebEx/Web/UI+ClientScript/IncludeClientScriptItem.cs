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
namespace System.Web.UI
{
    /// <summary>
    /// IncludeClientScriptItem
    /// </summary>
    public class IncludeClientScriptItem : ClientScriptItemBase
    {
        private string _type;
        private string _uri;

        /// <summary>
        /// Initializes a new instance of the <see cref="IncludeClientScriptItem"/> class.
        /// </summary>
        /// <param name="uri">The URI.</param>
        public IncludeClientScriptItem(string uri)
            : this(uri, "text/javascript") { }
        /// <summary>
        /// Initializes a new instance of the <see cref="IncludeClientScriptItem"/> class.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="type">The type.</param>
        public IncludeClientScriptItem(string uri, string type)
        {
            _type = "text/javascript";
            _uri = uri;
        }

        /// <summary>
        /// Renders the specified b.
        /// </summary>
        /// <param name="b">The b.</param>
        public override void Render(StringBuilder b)
        {
            b.AppendFormat("<script type=\"{0}\" src=\"{1}\"></script>", _type, _uri);
        }
    }
}
