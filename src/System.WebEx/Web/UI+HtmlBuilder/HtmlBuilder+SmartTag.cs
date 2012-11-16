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
        /// Begins the smart tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder BeginSmartTag(HtmlTag tag, params string[] args) { return BeginSmartTag(tag, Nparams.Parse(args)); }
        /// <summary>
        /// Begins the smart tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder BeginSmartTag(HtmlTag tag, Nparams args)
        {
            string c;
            switch (tag)
            {
                case HtmlTag._CommandTarget:
                    throw new NotSupportedException();
                case HtmlTag.Script:
                    o_Script(args);
                    return this;

                // Container
                case HtmlTag.Div:
                    o_Div(args);
                    return this;

                // Content
                case HtmlTag.A:
                    if (args == null || string.IsNullOrEmpty(c = args.Slice<string>("url")))
                        throw new ArgumentException("Local.UndefinedAttribUrl", "attrib");
                    o_A(c, args);
                    return this;
                case HtmlTag.H1:
                    o_H1(args);
                    return this;
                case HtmlTag.H2:
                    o_H2(args);
                    return this;
                case HtmlTag.H3:
                    o_H3(args);
                    return this;
                case HtmlTag.P:
                    o_P(args);
                    return this;
                case HtmlTag.Span:
                    o_Span(args);
                    return this;

                // List
                case HtmlTag.Li:
                    o_Li(args);
                    return this;
                case HtmlTag.Ol:
                    o_Ol(args);
                    return this;
                case HtmlTag.Ul:
                    o_Ul(args);
                    return this;

                // Table
                case HtmlTag.Colgroup:
                    o_Colgroup(args);
                    return this;
                case HtmlTag.Table:
                    o_Table(args);
                    return this;
                case HtmlTag.Tbody:
                    o_Tbody(args);
                    return this;
                case HtmlTag.Td:
                    o_Td(args);
                    return this;
                case HtmlTag.Tfoot:
                    o_Tfoot(args);
                    return this;
                case HtmlTag.Th:
                    o_Th(args);
                    return this;
                case HtmlTag.Thead:
                    o_Thead(args);
                    return this;
                case HtmlTag.Tr:
                    o_Tr(args);
                    return this;

                // Form
                case HtmlTag.Button:
                    o_Button(args);
                    return this;
                case HtmlTag.Fieldset:
                    o_Fieldset(args);
                    return this;
                case HtmlTag.Form:
                    throw new NotSupportedException();
                case HtmlTag._FormReference:
                    throw new NotSupportedException();
                case HtmlTag.Label:
                    if (args == null || string.IsNullOrEmpty(c = args.Slice<string>("forName")))
                        throw new ArgumentException("Local.UndefinedAttribForName", "attrib");
                    o_Label(c, args);
                    return this;
                // o_optgroup - no match
                case HtmlTag.Option:
                    if (args == null || string.IsNullOrEmpty(c = args.Slice<string>("value")))
                        throw new ArgumentException("Local.UndefinedAttribValue", "attrib");
                    o_Option(c, args);
                    return this;
                case HtmlTag.Select:
                    if (args == null || string.IsNullOrEmpty(c = args.Slice<string>("name")))
                        throw new ArgumentException("Local.UndefinedAttribName", "attrib");
                    o_Select(c, args);
                    return this;
                case HtmlTag.Textarea:
                    if (args == null || string.IsNullOrEmpty(c = args.Slice<string>("name")))
                        throw new ArgumentException("Local.UndefinedAttribName", "attrib");
                    o_Textarea(c, args);
                    return this;
            }
            BeginHtmlTag(tag);
            return this;
        }

        /// <summary>
        /// Ends the smart tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder EndSmartTag(HtmlTag tag, params string[] args) { return EndSmartTag(tag, Nparams.Parse(args)); }
        /// <summary>
        /// Ends the smart tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder EndSmartTag(HtmlTag tag, Nparams args)
        {
            string c;
            string c2;
            switch (tag)
            {
                case HtmlTag._CommandTarget:
                    x_CommandTarget();
                    return this;
                case HtmlTag.Script:
                    x_Script();
                    return this;

                // Container
                case HtmlTag.Div:
                    x_Div();
                    return this;
                case HtmlTag.Iframe:
                    if (args == null || string.IsNullOrEmpty(c = args.Slice<string>("url")))
                        throw new ArgumentException("Local.UndefinedAttribUrl", "attrib");
                    x_Iframe(c, args);
                    return this;

                // Content
                case HtmlTag.A:
                    x_A();
                    return this;
                case HtmlTag.Br:
                    x_Br();
                    return this;
                case HtmlTag.H1:
                    x_H1();
                    return this;
                case HtmlTag.H2:
                    x_H2();
                    return this;
                case HtmlTag.H3:
                    x_H3();
                    return this;
                case HtmlTag.Hr:
                    x_Hr(args);
                    return this;
                case HtmlTag.Img:
                    if (args == null || string.IsNullOrEmpty(c = args.Slice<string>("url")))
                        throw new ArgumentException("Local.UndefinedAttribUrl", "attrib");
                    if (string.IsNullOrEmpty(c2 = args.Slice<string>("value")))
                        throw new ArgumentException("Local.UndefinedAttribValue", "attrib");
                    x_Img(c, c2, args);
                    return this;
                case HtmlTag.P:
                    x_P();
                    return this;
                case HtmlTag.Span:
                    x_Span();
                    return this;
                //- x_tofu - no match

                // List
                case HtmlTag.Li:
                    x_Li();
                    return this;
                case HtmlTag.Ol:
                    x_Ol();
                    return this;
                case HtmlTag.Ul:
                    x_Ul();
                    return this;

                // Table
                case HtmlTag.Col:
                    x_Col(args);
                    return this;
                case HtmlTag.Colgroup:
                    x_Colgroup();
                    return this;
                case HtmlTag.Table:
                    x_Table();
                    return this;
                case HtmlTag.Tbody:
                    x_Tbody();
                    return this;
                case HtmlTag.Td:
                    x_Td();
                    return this;
                case HtmlTag.Tfoot:
                    x_Tfoot();
                    return this;
                case HtmlTag.Th:
                    x_Th();
                    return this;
                case HtmlTag.Thead:
                    x_Thead();
                    return this;
                case HtmlTag.Tr:
                    x_Tr();
                    return this;

                // Form
                case HtmlTag.Button:
                    x_Button();
                    return this;
                case HtmlTag.Fieldset:
                    x_Fieldset();
                    return this;
                case HtmlTag.Form:
                    x_Form();
                    return this;
                case HtmlTag._FormReference:
                    x_FormReference();
                    return this;
                case HtmlTag.Input:
                    if (args == null || string.IsNullOrEmpty(c = args.Slice<string>("name")))
                        throw new ArgumentException("Local.UndefinedAttribName", "attrib");
                    if (string.IsNullOrEmpty(c2 = args.Slice<string>("value")))
                        throw new ArgumentException("Local.UndefinedAttribValue", "attrib");
                    x_Input(c, c2, args);
                    return this;
                case HtmlTag.Label:
                    x_Label();
                    return this;
                // x_optgroup - no match
                case HtmlTag.Option:
                    x_Option();
                    return this;
                case HtmlTag.Select:
                    x_Select();
                    return this;
                case HtmlTag.Textarea:
                    x_Textarea();
                    return this;
            }
            EndHtmlTag();
            return this;
        }
    }
}