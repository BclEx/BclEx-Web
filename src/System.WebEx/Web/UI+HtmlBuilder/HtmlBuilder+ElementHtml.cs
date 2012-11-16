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
using System.Patterns.UI.Forms;
namespace System.Web.UI
{
    public partial class HtmlBuilder
    {
        #region Html-Other

        /// <summary>
        /// O_s the command target.
        /// </summary>
        /// <param name="commandTargetControl">The command target control.</param>
        /// <returns></returns>
        public HtmlBuilder o_CommandTarget(Control commandTargetControl)
        {
            var lastCommandTargetControl = _commandTargetControl;
            _commandTargetControl = commandTargetControl;
            ElementPush(HtmlTag._CommandTarget, lastCommandTargetControl);
            return this;
        }

        /// <summary>
        /// O_s the script.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Script(params string[] args) { return o_Script(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the script.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Script(Nparams args)
        {
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Type, "text/javascript");
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Script);
            _textWriter.Write("//<!CDATA[[ <!--\n");
            ElementPush(HtmlTag.Script, null);
            return this;
        }

        /// <summary>
        /// X_s the command target.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_CommandTarget()
        {
            ElementPop(HtmlTag._CommandTarget, null, HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the script.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Script()
        {
            ElementPop(HtmlTag.Script, null, HtmlTag.__Undefined, null);
            return this;
        }

        #endregion

        #region Html-Container

        /// <summary>
        /// O_s the div.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Div(params string[] args) { return o_Div(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the div.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Div(Nparams args)
        {
            _writeCount++;
            bool isState;
            HtmlBuilderDivTag lastDivState;
            if (args != null)
            {
                isState = args.Slice<bool>("state");
                if (isState)
                {
                    lastDivState = _divTag;
                    _divTag = CreateHtmlBuilderDivTag(this, args);
                }
                else
                    lastDivState = null;
                if (args.HasValue())
                    AddAttribute(args, null);
            }
            else
            {
                isState = false;
                lastDivState = null;
            }
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Div);
            ElementPush(HtmlTag.Div, new DivElementState(isState, lastDivState));
            return this;
        }

        /// <summary>
        /// X_s the div.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Div()
        {
            ElementPop(HtmlTag.Div, null, HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the iframe.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder x_Iframe(string url, params string[] args) { return x_Iframe(url, Nparams.Parse(args)); }
        /// <summary>
        /// X_s the iframe.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder x_Iframe(string url, Nparams args)
        {
            if (url == null)
                throw new ArgumentNullException("url");
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Src, url);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Iframe);
            _textWriter.RenderEndTag();
            return this;
        }

        #endregion

        #region Html-Content

        /// <summary>
        /// O_s the A.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_A(string url, params string[] args) { return o_A(url, (Nparams.Parse(args))); }
        /// <summary>
        /// O_s the A.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_A(string url, Nparams args)
        {
            if (url == null)
                throw new ArgumentNullException("url");
            if (_isInAnchor)
                throw new InvalidOperationException("Local.RedefineHtmlAnchor");
            _isInAnchor = true;
            _writeCount++;
            // todo: add
            //if (attrib.IsExist("alt") == false) {
            //   attrib["alt"] = attrib["title"];
            //}
            string textProcess;
            if (args != null)
            {
                textProcess = args.Slice<string>("textProcess");
                if (args.HasValue())
                    AddAttribute(args, null);
            }
            else
                textProcess = string.Empty;
            //if (textProcess.Length > 0)
            //    url = KernelFactory.TextProcess[textProcess].Process(url, null);
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Href, url);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.A);
            ElementPush(HtmlTag.A, null);
            return this;
        }

        /// <summary>
        /// O_s the h1.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_H1(params string[] args) { return o_H1(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the h1.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_H1(Nparams args)
        {
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.H1);
            ElementPush(HtmlTag.H1, null);
            return this;
        }

        /// <summary>
        /// O_s the h2.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_H2(params string[] args) { return o_H2(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the h2.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_H2(Nparams args)
        {
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.H2);
            ElementPush(HtmlTag.H2, null);
            return this;
        }

        /// <summary>
        /// O_s the h3.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_H3(params string[] args) { return o_H3(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the h3.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_H3(Nparams args)
        {
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.H3);
            ElementPush(HtmlTag.H3, null);
            return this;
        }

        /// <summary>
        /// O_s the P.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_P(params string[] args) { return o_P(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the P.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_P(Nparams args)
        {
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.P);
            ElementPush(HtmlTag.P, null);
            return this;
        }

        /// <summary>
        /// O_s the span.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Span(params string[] args) { return o_Span(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the span.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Span(Nparams args)
        {
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Span);
            ElementPush(HtmlTag.Span, null);
            return this;
        }

        /// <summary>
        /// X_s the A.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_A()
        {
            if (!_isInAnchor)
                return this;
            ElementPop(HtmlTag.A, null, HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the br.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Br()
        {
            _writeCount++;
            // note: default registration in htmltextwriter is incorrect, correction applied in static constructor.
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Br);
            _textWriter.RenderEndTag();
            return this;
        }

        /// <summary>
        /// X_s the h1.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_H1()
        {
            ElementPop(HtmlTag.H1, null, HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the h2.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_H2()
        {
            ElementPop(HtmlTag.H2, null, HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the h3.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_H3()
        {
            ElementPop(HtmlTag.H3, null, HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the hr.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder x_Hr(params string[] args) { return x_Hr(Nparams.Parse(args)); }
        /// <summary>
        /// X_s the hr.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder x_Hr(Nparams args)
        {
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Hr);
            _textWriter.RenderEndTag();
            return this;
        }

        /// <summary>
        /// X_s the img.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="alt">The alt.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder x_Img(string url, string alt, params string[] args) { return x_Img(url, alt, (Nparams.Parse(args))); }
        /// <summary>
        /// X_s the img.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="alt">The alt.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder x_Img(string url, string alt, Nparams args)
        {
            if (url == null)
                throw new ArgumentNullException("url");
            if (alt == null)
                throw new ArgumentNullException("alt");
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.AddAttributeIfUndefined(System.Web.UI.HtmlTextWriterAttribute.Src, url);
            _textWriter.AddAttributeIfUndefined(System.Web.UI.HtmlTextWriterAttribute.Alt, alt);
            _textWriter.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Img);
            _textWriter.RenderEndTag();
            return this;
        }

        /// <summary>
        /// X_s the P.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_P()
        {
            ElementPop(HtmlTag.P, null, HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the span.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Span()
        {
            ElementPop(HtmlTag.Span, null, HtmlTag.__Undefined, null);
            return this;
        }

        //public HtmlBuilder x_Tofu(params string[] args) { return x_Tofu(Nparams.Parse(args)); }
        //public HtmlBuilder x_Tofu(Nparams args)
        //{
        //    _writeCount++;
        //    if (args != null)
        //        AddAttribute(args, null);
        //    _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Src, HtmlTextWriterEx.TofuUri);
        //    _textWriter.RenderBeginTag(HtmlTextWriterTag.Img);
        //    _textWriter.RenderEndTag();
        //    return this;
        //}

        #endregion

        #region Html-Option

        /// <summary>
        /// Adds the option.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public HtmlBuilder AddOption(string key) { return AddOption(key, key); }
        /// <summary>
        /// Adds the option.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public HtmlBuilder AddOption(string key, string value)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            if (value == null)
                throw new ArgumentNullException("value");
            value = value.Truncate(_option.Size, CoreExtensions.TextTruncateType.Normal);
            switch (_option.Type)
            {
                case HtmlBuilderOptionType.Select:
                    _writeCount++;
                    if (key == _option.Value)
                        _textWriter.AddAttribute(HtmlTextWriterAttribute.Selected, "selected");
                    o_Option(key);
                    _textWriter.WriteEncodedText(value);
                    x_Option();
                    break;
                case HtmlBuilderOptionType.Radio:
                    _writeCount++;
                    o_Tr();
                    _textWriter.AddStyleAttribute(HtmlTextWriterStyle.Width, "25px");
                    o_Td();
                    if (key == _option.Value)
                        _textWriter.AddAttribute(HtmlTextWriterAttribute.Checked, "checked");
                    x_Input(_option.Key, key, "type=radio");
                    o_Td();
                    _textWriter.WriteEncodedText(value);
                    break;
                case HtmlBuilderOptionType.Static:
                    if (key == _option.Value)
                    {
                        _writeCount++;
                        _textWriter.AddAttribute(HtmlTextWriterAttribute.Class, "iStatic");
                        _textWriter.RenderBeginTag(HtmlTextWriterTag.Span);
                        _textWriter.WriteEncodedText(value);
                        _textWriter.RenderEndTag();
                    }
                    break;
            }
            return this;
        }

        /// <summary>
        /// Begins the option.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public HtmlBuilder BeginOption(HtmlBuilderOptionType type, string key, string value, int size)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            if (value == null)
                throw new ArgumentNullException("value");
            _option = new HtmlOption { Type = type, Key = key, Value = value, Size = size };
            return this;
        }

        /// <summary>
        /// Begins the option group.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder BeginOptionGroup(string name, params string[] args)
        {
            if (_option == null)
                throw new ArgumentNullException("_option");
            switch (_option.Type)
            {
                case HtmlBuilderOptionType.Select:
                    o_Optgroup(name, args);
                    break;
            }
            return this;
        }

        /// <summary>
        /// Ends the option.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder EndOption()
        {
            if (_option == null)
                throw new ArgumentNullException("_option");
            switch (_option.Type)
            {
                case HtmlBuilderOptionType.Select:
                    x_Select();
                    break;
                case HtmlBuilderOptionType.Radio:
                    x_Table();
                    break;
            }
            return this;
        }

        /// <summary>
        /// Ends the option group.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder EndOptionGroup()
        {
            if (_option == null)
                throw new ArgumentNullException("_option");
            switch (_option.Type)
            {
                case HtmlBuilderOptionType.Select:
                    x_Optgroup();
                    break;
            }
            return this;
        }

        #endregion

        #region Html-List

        /// <summary>
        /// O_s the li.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Li(params string[] args) { return o_Li(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the li.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Li(Nparams args)
        {
            ElementPop(HtmlTag.Li, null, HtmlTag.__OlUl, null);
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Li);
            ElementPush(HtmlTag.Li, null);
            return this;
        }

        /// <summary>
        /// O_s the ol.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Ol(params string[] args) { return o_Ol(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the ol.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Ol(Nparams args)
        {
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Ol);
            ElementPush(HtmlTag.Ol, null);
            return this;
        }

        /// <summary>
        /// O_s the ul.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Ul(params string[] args) { return o_Ul(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the ul.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Ul(Nparams args)
        {
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Ul);
            ElementPush(HtmlTag.Ul, null);
            return this;
        }

        /// <summary>
        /// X_s the li.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Li()
        {
            ElementPop(HtmlTag.Li, null, HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the ol.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Ol()
        {
            ElementPop(HtmlTag.Ol, null, HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the ul.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Ul()
        {
            ElementPop(HtmlTag.Ul, null, HtmlTag.__Undefined, null);
            return this;
        }

        #endregion

        #region Html-Table

        /// <summary>
        /// O_s the colgroup.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Colgroup(params string[] args) { return o_Colgroup(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the colgroup.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Colgroup(Nparams args)
        {
            if (_tableTag == null)
                throw new InvalidOperationException("Local.UndefinedHtmlTable");
            if (_tableTag.Stage > HtmlBuilderTableTag.TableStage.Colgroup)
                throw new InvalidOperationException(string.Format("Local.InvalidTableStageAB", _tableTag.Stage.ToString(), HtmlBuilderTableTag.TableStage.Colgroup.ToString()));
            ElementPop(HtmlTag.Colgroup, null, HtmlTag.Table, null);
            _writeCount++;
            _tableTag.Stage = HtmlBuilderTableTag.TableStage.Colgroup;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Colgroup);
            ElementPush(HtmlTag.Colgroup, null);
            return this;
        }

        /// <summary>
        /// O_s the table.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Table(params string[] args) { return o_Table(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the table.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Table(Nparams args)
        {
            _writeCount++;
            var lastTableState = _tableTag;
            _tableTag = CreateHtmlBuilderTableTag(this, args);
            string caption;
            if (args != null)
            {
                caption = args.Slice<string>("caption");
                if (args.HasValue())
                    AddAttribute(args, null);
            }
            else
                caption = string.Empty;
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Cellpadding, "0");
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Cellspacing, "0");
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Table);
            if (caption.Length > 0)
            {
                _textWriter.RenderBeginTag(HtmlTextWriterTag.Caption);
                _textWriter.WriteEncodedText(caption);
                _textWriter.RenderEndTag();
            }
            ElementPush(HtmlTag.Table, lastTableState);
            return this;
        }

        /// <summary>
        /// O_s the tbody.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Tbody(params string[] args) { return o_Tbody(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the tbody.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Tbody(Nparams args)
        {
            if (_tableTag == null)
                throw new InvalidOperationException("Local.UndefinedHtmlTable");
            if (_tableTag.Stage > HtmlBuilderTableTag.TableStage.Tbody)
                throw new InvalidOperationException(string.Format("Local.InvalidTableStageAB", _tableTag.Stage.ToString(), HtmlBuilderTableTag.TableStage.Tbody.ToString()));
            ElementPop(HtmlTag.Tbody, null, HtmlTag.Table, null);
            _writeCount++;
            _tableTag.Stage = HtmlBuilderTableTag.TableStage.Tbody;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Tbody);
            ElementPush(HtmlTag.Tbody, null);
            return this;
        }

        /// <summary>
        /// O_s the td.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Td(params string[] args) { return o_Td(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the td.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Td(Nparams args)
        {
            if (_tableTag == null)
                throw new InvalidOperationException("Local.UndefinedHtmlTable");
            _tableTag.ColumnIndex++;
            ElementPop(HtmlTag.Td, null, HtmlTag.Tr, null);
            _writeCount++;
            _tableTag.AddAttribute(this, _textWriter, HtmlTag.Td, args);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Td);
            ElementPush(HtmlTag.Td, _writeCount);
            return this;
        }

        /// <summary>
        /// O_s the tfoot.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Tfoot(params string[] args) { return o_Tfoot(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the tfoot.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Tfoot(Nparams args)
        {
            if (_tableTag == null)
                throw new InvalidOperationException("Local.UndefinedHtmlTable");
            if (_tableTag.Stage > HtmlBuilderTableTag.TableStage.TheadTfoot)
                throw new InvalidOperationException(string.Format("Local.InvalidTableStageAB", _tableTag.Stage.ToString(), HtmlBuilderTableTag.TableStage.TheadTfoot.ToString()));
            ElementPop(HtmlTag.Tfoot, null, HtmlTag.Table, null);
            _writeCount++;
            _tableTag.Stage = HtmlBuilderTableTag.TableStage.TheadTfoot;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Tfoot);
            ElementPush(HtmlTag.Tfoot, null);
            return this;
        }

        /// <summary>
        /// O_s the th.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Th(params string[] args) { return o_Th(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the th.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Th(Nparams args)
        {
            if (_tableTag == null)
                throw new InvalidOperationException("Local.UndefinedHtmlTable");
            _tableTag.ColumnIndex++;
            ElementPop(HtmlTag.Th, null, HtmlTag.Tr, null);
            _writeCount++;
            _tableTag.AddAttribute(this, _textWriter, HtmlTag.Th, args);
            _textWriter.RenderBeginTag(System.Web.UI.HtmlTextWriterTag.Th);
            ElementPush(HtmlTag.Th, _writeCount);
            return this;
        }

        /// <summary>
        /// O_s the thead.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Thead(params string[] args) { return o_Thead(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the thead.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Thead(Nparams args)
        {
            if (_tableTag == null)
                throw new InvalidOperationException("Local.UndefinedHtmlTable");
            if (_tableTag.Stage > HtmlBuilderTableTag.TableStage.TheadTfoot)
                throw new InvalidOperationException(string.Format("Local.InvalidTableStageAB", _tableTag.Stage.ToString(), HtmlBuilderTableTag.TableStage.TheadTfoot.ToString()));
            ElementPop(HtmlTag.Thead, null, HtmlTag.Table, null);
            _writeCount++;
            _tableTag.Stage = HtmlBuilderTableTag.TableStage.TheadTfoot;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Thead);
            ElementPush(HtmlTag.Thead, null);
            return this;
        }

        /// <summary>
        /// O_s the tr.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Tr(params string[] args) { return o_Tr(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the tr.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Tr(Nparams args)
        {
            if (_tableTag == null)
                throw new InvalidOperationException("Local.UndefinedHtmlTable");
            _tableTag.RowIndex++;
            _tableTag.ColumnIndex = 0;
            ElementPop(HtmlTag.Tr, null, HtmlTag.Table, null);
            _writeCount++;
            _tableTag.AddAttribute(this, _textWriter, HtmlTag.Tr, args);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Tr);
            ElementPush(HtmlTag.Tr, null);
            return this;
        }

        /// <summary>
        /// X_s the col.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder x_Col(params string[] args) { return x_Col(Nparams.Parse(args)); }
        /// <summary>
        /// X_s the col.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder x_Col(Nparams args)
        {
            if (_tableTag == null)
                throw new InvalidOperationException("Local.UndefinedHtmlTable");
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Col);
            _textWriter.RenderEndTag();
            return this;
        }

        /// <summary>
        /// X_s the colgroup.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Colgroup()
        {
            if (_tableTag == null)
                return this;
            ElementPop(HtmlTag.Colgroup, null, HtmlTag.Table, null);
            return this;
        }

        /// <summary>
        /// X_s the table.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Table()
        {
            if (_tableTag == null)
                return this;
            ElementPop(HtmlTag.Table, null, HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the tbody.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Tbody()
        {
            if (_tableTag == null)
                return this;
            ElementPop(HtmlTag.Tbody, null, HtmlTag.Table, null);
            return this;
        }

        /// <summary>
        /// X_s the td.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Td()
        {
            if (_tableTag == null)
                return this;
            ElementPop(HtmlTag.Td, null, HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the tfoot.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Tfoot()
        {
            if (_tableTag == null)
                return this;
            ElementPop(HtmlTag.Tfoot, null, HtmlTag.Table, null);
            return this;
        }

        /// <summary>
        /// X_s the th.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Th()
        {
            if (_tableTag == null)
                return this;
            ElementPop(HtmlTag.Th, null, HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the thead.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Thead()
        {
            if (_tableTag == null)
                return this;
            ElementPop(HtmlTag.Thead, null, HtmlTag.Table, null);
            return this;
        }

        /// <summary>
        /// X_s the tr.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Tr()
        {
            if (_tableTag == null)
                return this;
            ElementPop(HtmlTag.Tr, null, HtmlTag.__Undefined, null);
            return this;
        }

        #endregion

        #region Html-Form

        /// <summary>
        /// O_s the button.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Button(params string[] args) { return o_Button(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the button.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Button(Nparams args)
        {
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Button);
            ElementPush(HtmlTag.Button, null);
            return this;
        }

        /// <summary>
        /// O_s the fieldset.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Fieldset(params string[] args) { return o_Fieldset(Nparams.Parse(args)); }
        /// <summary>
        /// O_s the fieldset.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Fieldset(Nparams args)
        {
            if (_formTag == null)
                throw new InvalidOperationException("Local.UndefinedHtmlForm");
            _writeCount++;
            string legend;
            string legendAccessKey;
            if (args != null)
            {
                legend = args.Slice<string>("legend");
                legendAccessKey = args.Slice<string>("legendaccesskey");
                if (args.HasValue())
                    AddAttribute(args, null);
            }
            else
            {
                legend = string.Empty;
                legendAccessKey = string.Empty;
            }
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Fieldset);
            if (legend.Length > 0 || legendAccessKey.Length > 0)
            {
                if (legendAccessKey.Length > 0)
                    _textWriter.AddAttribute(HtmlTextWriterAttribute.Accesskey, legendAccessKey);
                _textWriter.RenderBeginTag(HtmlTextWriterTag.Legend);
                if (legend.Length > 0)
                    _textWriter.Write(legend);
                _textWriter.RenderEndTag();
            }
            ElementPush(HtmlTag.Fieldset, null);
            return this;
        }

        /// <summary>
        /// O_s the form.
        /// </summary>
        /// <param name="commandTargetControl">The command target control.</param>
        /// <param name="formContext">The form context.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Form(Control commandTargetControl, IFormContext formContext, params string[] args) { return o_Form(commandTargetControl, formContext, Nparams.Parse(args)); }
        /// <summary>
        /// O_s the form.
        /// </summary>
        /// <param name="commandTargetControl">The command target control.</param>
        /// <param name="formContext">The form context.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Form(Control commandTargetControl, IFormContext formContext, Nparams args)
        {
            if (_formTag != null)
                throw new InvalidOperationException("Local.RedefineHtmlForm");
            _writeCount++;
            _formTag = CreateHtmlBuilderFormTag(this, formContext, args);
            //Http.Instance.EnterForm(this, attrib);
            string method;
            if (args != null)
            {
                _formName = args.Slice("name", "Form");
                method = args.Slice("method", "POST");
                if (args.HasValue())
                    AddAttribute(args, null);
            }
            else
            {
                _formName = "Form";
                method = "POST";
            }
            if (_formName.Length > 0)
                _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Name, _formName);
            if (method.Length > 0)
                _textWriter.AddAttribute("method", method.ToUpperInvariant());
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Form);
            ElementPush(HtmlTag.Form, null);
            if (commandTargetControl != null)
                o_CommandTarget(commandTargetControl);
            return this;
        }

        /// <summary>
        /// O_s the form reference.
        /// </summary>
        /// <param name="commandTargetControl">The command target control.</param>
        /// <param name="formContext">The form context.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_FormReference(Control commandTargetControl, IFormContext formContext, params string[] args) { return o_FormReference(commandTargetControl, formContext, Nparams.Parse(args)); }
        /// <summary>
        /// O_s the form reference.
        /// </summary>
        /// <param name="commandTargetControl">The command target control.</param>
        /// <param name="formContext">The form context.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_FormReference(Control commandTargetControl, IFormContext formContext, Nparams args)
        {
            if (_formTag != null)
                throw new InvalidOperationException("Local.RedefineHtmlForm");
            _formTag = CreateHtmlBuilderFormTag(this, formContext, args);
            ElementPush(HtmlTag._FormReference, null);
            if (commandTargetControl != null)
                o_CommandTarget(commandTargetControl);
            return this;
        }

        /// <summary>
        /// O_s the label.
        /// </summary>
        /// <param name="forName">For name.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Label(string forName, params string[] args) { return o_Label(forName, Nparams.Parse(args)); }
        /// <summary>
        /// O_s the label.
        /// </summary>
        /// <param name="forName">For name.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Label(string forName, Nparams args)
        {
            if (forName == null)
                throw new ArgumentNullException("forName");
            if (_formTag == null)
                throw new InvalidOperationException("Local.UndefinedHtmlForm");
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.For, forName);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Label);
            ElementPush(HtmlTag.Label, null);
            return this;
        }

        /// <summary>
        /// O_s the optgroup.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Optgroup(string name, params string[] args) { return o_Optgroup(name, Nparams.Parse(args)); }
        /// <summary>
        /// O_s the optgroup.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Optgroup(string name, Nparams args)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (_formTag == null)
                throw new InvalidOperationException("Local.UndefinedHtmlForm");
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.AddAttribute("Label", name);
            _textWriter.RenderBeginTag("Optgroup");
            ElementPush("Optgroup", null);
            return this;
        }

        /// <summary>
        /// O_s the option.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Option(string value, params string[] args) { return o_Option(value, Nparams.Parse(args)); }
        /// <summary>
        /// O_s the option.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Option(string value, Nparams args)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            if (_formTag == null)
                throw new InvalidOperationException("Local.UndefinedHtmlForm");
            _writeCount++;
            if (args != null)
                AddAttribute(args, null);
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Value, value);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Option);
            ElementPush(HtmlTag.Option, null);
            return this;
        }

        /// <summary>
        /// O_s the select.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Select(string name, params string[] args) { return o_Select(name, Nparams.Parse(args)); }
        /// <summary>
        /// O_s the select.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Select(string name, Nparams args)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (_formTag == null)
                throw new InvalidOperationException("Local.UndefinedHtmlForm");
            _writeCount++;
            if (args != null)
            {
                // scale
                if (args.ContainsKey("size"))
                {
                    var size = args.Slice<string>("size");
                    if (size.EndsWith("px", StringComparison.OrdinalIgnoreCase))
                        _textWriter.AddStyleAttributeIfUndefined(HtmlTextWriterStyle.Height, size);
                    else if (!size.EndsWith("u", StringComparison.OrdinalIgnoreCase))
                        
                        _textWriter.AddStyleAttributeIfUndefined(HtmlTextWriterStyle.Height, (int.Parse(size) * 7).ToString() + "px");
                    else
                        _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Size, size.Substring(0, size.Length - 1));
                }
                if (args.HasValue())
                    AddAttribute(args, null);
            }
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Id, name);
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Name, name);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Select);
            ElementPush(HtmlTag.Select, null);
            return this;
        }

        /// <summary>
        /// O_s the textarea.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Textarea(string name, params string[] args) { return o_Textarea(name, Nparams.Parse(args)); }
        /// <summary>
        /// O_s the textarea.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder o_Textarea(string name, Nparams args)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (_formTag == null)
                throw new InvalidOperationException("Local.UndefinedHtmlForm");
            _writeCount++;
            if (args != null)
            {
                // scale
                if (args.ContainsKey("cols"))
                {
                    var cols = args.Slice<string>("cols");
                    if (cols.EndsWith("px", StringComparison.OrdinalIgnoreCase))
                        _textWriter.AddStyleAttributeIfUndefined(HtmlTextWriterStyle.Width, cols);
                    else if (!cols.EndsWith("u", StringComparison.OrdinalIgnoreCase))
                        _textWriter.AddStyleAttributeIfUndefined(HtmlTextWriterStyle.Width, (int.Parse(cols) * 7).ToString() + "px");
                    else
                        _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Cols, cols.Substring(0, cols.Length - 1));
                }
                if (args.ContainsKey("rows"))
                {
                    var rows = args.Slice<string>("rows");
                    if (rows.EndsWith("px", StringComparison.OrdinalIgnoreCase))
                        _textWriter.AddStyleAttributeIfUndefined(HtmlTextWriterStyle.Height, rows);
                    else if (!rows.EndsWith("u", StringComparison.OrdinalIgnoreCase))
                        _textWriter.AddStyleAttributeIfUndefined(HtmlTextWriterStyle.Height, (int.Parse(rows) * 7).ToString() + "px");
                    else
                        _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Rows, rows.Substring(0, rows.Length - 1));
                }
                if (args.HasValue())
                    AddAttribute(args, null);
            }
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Id, name);
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Name, name);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Textarea);
            ElementPush(HtmlTag.Textarea, null);
            return this;
        }

        /// <summary>
        /// X_s the button.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Button()
        {
            ElementPop(HtmlTag.Button, null, HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the fieldset.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Fieldset()
        {
            if (_formTag == null)
                throw new InvalidOperationException("Local.UndefinedHtmlForm");
            ElementPop(HtmlTag.Fieldset, null, HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the form.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Form()
        {
            if (_formTag == null)
                return this;
            ElementPop(HtmlTag.Form, null, HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the form reference.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_FormReference()
        {
            if (_formTag == null)
                return this;
            ElementPop(HtmlTag._FormReference, null, HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the input.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder x_Input(string name, string value, params string[] args) { return x_Input(name, value, Nparams.Parse(args)); }
        /// <summary>
        /// X_s the input.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public HtmlBuilder x_Input(string name, string value, Nparams args)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (value == null)
                throw new ArgumentNullException("value");
            if (_formTag == null)
                throw new InvalidOperationException("Local.UndefinedHtmlForm");
            _writeCount++;
            string type;
            if (args != null)
            {
                type = args.Slice<string>("type", "text");
                // scale
                if (args.ContainsKey("size"))
                {
                    var size = args.Slice<string>("size");
                    if (size.EndsWith("px", StringComparison.OrdinalIgnoreCase))
                        _textWriter.AddStyleAttributeIfUndefined(HtmlTextWriterStyle.Width, size);
                    else if (!size.EndsWith("u", StringComparison.OrdinalIgnoreCase))
                        _textWriter.AddStyleAttributeIfUndefined(HtmlTextWriterStyle.Width, (int.Parse(size) * 7).ToString() + "px");
                    else
                        _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Size, size.Substring(0, size.Length - 1));
                }
                if (args.HasValue())
                    AddAttribute(args, null);
            }
            else
                type = "text";
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Id, name);
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Name, name);
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Type, type);
            _textWriter.AddAttributeIfUndefined(HtmlTextWriterAttribute.Value, value);
            _textWriter.RenderBeginTag(HtmlTextWriterTag.Input);
            _textWriter.RenderEndTag();
            return this;
        }

        /// <summary>
        /// X_s the label.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Label()
        {
            if (_formTag == null)
                throw new InvalidOperationException("Local.UndefinedHtmlForm");
            ElementPop(HtmlTag.Label, null, HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the optgroup.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Optgroup()
        {
            if (_formTag == null)
                throw new InvalidOperationException("Local.UndefinedHtmlForm");
            ElementPop(HtmlTag.Unknown, "Optgroup", HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the option.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Option()
        {
            if (_formTag == null)
                throw new InvalidOperationException("Local.UndefinedHtmlForm");
            ElementPop(HtmlTag.Option, null, HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the select.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Select()
        {
            if (_formTag == null)
                return this;
            ElementPop(HtmlTag.Select, null, HtmlTag.__Undefined, null);
            return this;
        }

        /// <summary>
        /// X_s the textarea.
        /// </summary>
        /// <returns></returns>
        public HtmlBuilder x_Textarea()
        {
            if (_formTag == null)
                return this;
            ElementPop(HtmlTag.Textarea, null, HtmlTag.__Undefined, null);
            return this;
        }

        #endregion
    }
}