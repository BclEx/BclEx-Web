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
namespace System.Web.UI
{
    public partial class HtmlBuilder
    {
        /// <summary>
        /// Renders the button.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="commandEvent">The command event.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder RenderButton(string text, string commandEvent, params string[] args) { return RenderButton(text, commandEvent, Nparams.Parse(args)); }
        /// <summary>
        /// Renders the button.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="commandEvent">The command event.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder RenderButton(string text, string commandEvent, Nparams args)
        {
            if (text == null)
                throw new ArgumentNullException("text");
            _writeCount++;
            if (args != null)
                AddAttribute(args, new[] { "onclick" });
            if (!string.IsNullOrEmpty(commandEvent))
                _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Onclick, commandEvent);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Button);
            _textWriter.Write(text);
            _textWriter.RenderEndTag();
            return this;
        }

        /// <summary>
        /// Renders the input button.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="commandEvent">The command event.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder RenderInputButton(string text, string commandEvent, params string[] args) { return RenderInputButton(text, commandEvent, Nparams.Parse(args)); }
        /// <summary>
        /// Renders the input button.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="commandEvent">The command event.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder RenderInputButton(string text, string commandEvent, Nparams args)
        {
            if (text == null)
                throw new ArgumentNullException("text");
            _writeCount++;
            if (args != null)
                AddAttribute(args, new[] { "onclick", "value" });
            if (!string.IsNullOrEmpty(commandEvent))
                _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Onclick, commandEvent);
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Value, text);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Input);
            _textWriter.RenderEndTag();
            return this;
        }

        /// <summary>
        /// Renders the image button.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="alt">The alt.</param>
        /// <param name="commandEvent">The command event.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder RenderImageButton(string url, string alt, string commandEvent, params string[] args) { return RenderImageButton(url, alt, commandEvent, Nparams.Parse(args)); }
        /// <summary>
        /// Renders the image button.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="alt">The alt.</param>
        /// <param name="commandEvent">The command event.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder RenderImageButton(string url, string alt, string commandEvent, Nparams args)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url");
            _writeCount++;
            string onClickEvent = null;
            if (args != null)
            {
                var imageAttrib = args.Slice<Nparams>("image");
                if (args.HasValue())
                {
                    onClickEvent = args.Slice<string>("onclick");
                    if (args.HasValue())
                        AddAttribute(args, null);
                }
                if (imageAttrib != null)
                    AddAttribute(imageAttrib, null);
            }
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Alt, (alt ?? string.Empty));
            if (!string.IsNullOrEmpty(alt))
                _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Title, alt);
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Src, url);
            if (!string.IsNullOrEmpty(commandEvent) || !string.IsNullOrEmpty(onClickEvent))
                _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Onclick, StringEx.Axb(onClickEvent, ";", commandEvent) + ";return(false);");
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Type, "image");
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Input);
            _textWriter.RenderEndTag();
            return this;
        }

        /// <summary>
        /// Renders the image link.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="alt">The alt.</param>
        /// <param name="command">The command.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder RenderImageLink(string url, string alt, string command, params string[] args) { return RenderImageLink(url, alt, command, Nparams.Parse(args)); }
        /// <summary>
        /// Renders the image link.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="alt">The alt.</param>
        /// <param name="command">The command.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder RenderImageLink(string url, string alt, string command, Nparams args)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url");
            _writeCount++;
            Nparams imageAttrib;
            if (args != null)
            {
                imageAttrib = args.Slice<Nparams>("image");
                if (args.HasValue())
                    AddAttribute(args, null);
            }
            else
                imageAttrib = null;
            if (!string.IsNullOrEmpty(command))
                _textWriter.AddAttributeIfUndefined((true ? HtmlTextWriterAttribute.Onclick : HtmlTextWriterAttribute.Href), command);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.A);
            if (imageAttrib != null)
                AddAttribute(imageAttrib, null);
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Src, url);
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Alt, (alt ?? string.Empty));
            if (!string.IsNullOrEmpty(alt))
                _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Title, alt);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Img);
            _textWriter.RenderEndTag();
            _textWriter.RenderEndTag();
            return this;
        }

        /// <summary>
        /// Renders the link.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="command">The command.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder RenderLink(string text, string command, params string[] args) { return RenderLink(text, command, Nparams.Parse(args)); }
        /// <summary>
        /// Renders the link.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="command">The command.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder RenderLink(string text, string command, Nparams args)
        {
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            if (!string.IsNullOrEmpty(command))
                _textWriter.AddAttributeIfUndefined((true ? HtmlTextWriterAttribute.Onclick : HtmlTextWriterAttribute.Href), command);
            if (!string.IsNullOrEmpty(text))
                _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Title, text);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.A);
            _textWriter.Write(text);
            _textWriter.RenderEndTag();
            return this;
        }
    }
}