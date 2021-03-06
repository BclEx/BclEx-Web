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
#if xEXPERIMENTAL
using System.Web.UI.Integrate;
using System.Web.UI.WebControls;
using System.Web.UI;
namespace Contoso.Primitives.TextProcesses
{
    public class VideoTag : TextProcessBase
    {
        public override string Process(string[] texts, Nparams attrib3)
        {
            if (texts.Length < 1)
                throw new InvalidOperationException();
            var attrib = Nparams.Parse(texts[0].Split(';'));
            var videoBlock = new VideoBlock() { ID = attrib.Slice("id", "Video" + CoreEx.GetNextID()), };
            if (attrib.Exists("uri"))
                videoBlock.Uri = attrib.Slice<string>("uri");
            if (attrib.Exists("width"))
                videoBlock.Width = new Unit(attrib.Slice<string>("width"));
            if (attrib.Exists("height"))
                videoBlock.Height = new Unit(attrib.Slice<string>("height"));
            string responseText;
            HtmlTextWriterEx.RenderControl(videoBlock, out responseText);
            return responseText;
        }
    }
}
#endif