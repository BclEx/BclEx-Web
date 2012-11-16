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
    /// <summary>
    /// HtmlAttribute
    /// </summary>
    public enum HtmlAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        Accesskey,
        /// <summary>
        /// 
        /// </summary>
        Align,
        /// <summary>
        /// 
        /// </summary>
        Alt,
        /// <summary>
        /// 
        /// </summary>
        Background,
        /// <summary>
        /// 
        /// </summary>
        Bgcolor,
        /// <summary>
        /// 
        /// </summary>
        Border,
        /// <summary>
        /// 
        /// </summary>
        Bordercolor,
        /// <summary>
        /// 
        /// </summary>
        Cellpadding,
        /// <summary>
        /// 
        /// </summary>
        Cellspacing,
        /// <summary>
        /// 
        /// </summary>
        Checked,
        /// <summary>
        /// 
        /// </summary>
        Class,
        /// <summary>
        /// 
        /// </summary>
        Cols,
        /// <summary>
        /// 
        /// </summary>
        Colspan,
        /// <summary>
        /// 
        /// </summary>
        Disabled,
        /// <summary>
        /// 
        /// </summary>
        For,
        /// <summary>
        /// 
        /// </summary>
        Height,
        /// <summary>
        /// 
        /// </summary>
        Href,
        /// <summary>
        /// 
        /// </summary>
        Id,
        /// <summary>
        /// 
        /// </summary>
        Maxlength,
        /// <summary>
        /// 
        /// </summary>
        Multiple,
        /// <summary>
        /// 
        /// </summary>
        Name,
        /// <summary>
        /// 
        /// </summary>
        Nowrap,
        /// <summary>
        /// 
        /// </summary>
        Onchange,
        /// <summary>
        /// 
        /// </summary>
        Onclick,
        /// <summary>
        /// 
        /// </summary>
        ReadOnly,
        /// <summary>
        /// 
        /// </summary>
        Rows,
        /// <summary>
        /// 
        /// </summary>
        Rowspan,
        /// <summary>
        /// 
        /// </summary>
        Rules,
        /// <summary>
        /// 
        /// </summary>
        Selected,
        /// <summary>
        /// 
        /// </summary>
        Size,
        /// <summary>
        /// 
        /// </summary>
        Src,
        /// <summary>
        /// 
        /// </summary>
        Style,
        /// <summary>
        /// 
        /// </summary>
        Tabindex,
        /// <summary>
        /// 
        /// </summary>
        Target,
        /// <summary>
        /// 
        /// </summary>
        Title,
        /// <summary>
        /// 
        /// </summary>
        Type,
        /// <summary>
        /// 
        /// </summary>
        Valign,
        /// <summary>
        /// 
        /// </summary>
        Value,
        /// <summary>
        /// 
        /// </summary>
        Width,
        /// <summary>
        /// 
        /// </summary>
        Wrap,
        /// <summary>
        /// 
        /// </summary>
        Abbr,
        /// <summary>
        /// 
        /// </summary>
        AutoComplete,
        /// <summary>
        /// 
        /// </summary>
        Axis,
        /// <summary>
        /// 
        /// </summary>
        Content,
        /// <summary>
        /// 
        /// </summary>
        Coords,
        /// <summary>
        /// 
        /// </summary>
        DesignerRegion,
        /// <summary>
        /// 
        /// </summary>
        Dir,
        /// <summary>
        /// 
        /// </summary>
        Headers,
        /// <summary>
        /// 
        /// </summary>
        Longdesc,
        /// <summary>
        /// 
        /// </summary>
        Rel,
        /// <summary>
        /// 
        /// </summary>
        Scope,
        /// <summary>
        /// 
        /// </summary>
        Shape,
        /// <summary>
        /// 
        /// </summary>
        Usemap,
        /// <summary>
        /// 
        /// </summary>
        VCardName,
        /// <summary>
        /// 
        /// </summary>
        __Undefined,
        /// <summary>
        /// 
        /// </summary>
        StyleBackgroundColor,
        /// <summary>
        /// 
        /// </summary>
        StyleBackgroundImage,
        /// <summary>
        /// 
        /// </summary>
        StyleBorderCollapse,
        /// <summary>
        /// 
        /// </summary>
        StyleBorderColor,
        /// <summary>
        /// 
        /// </summary>
        StyleBorderStyle,
        /// <summary>
        /// 
        /// </summary>
        StyleBorderWidth,
        /// <summary>
        /// 
        /// </summary>
        StyleColor,
        /// <summary>
        /// 
        /// </summary>
        StyleFontFamily,
        /// <summary>
        /// 
        /// </summary>
        StyleFontSize,
        /// <summary>
        /// 
        /// </summary>
        StyleFontStyle,
        /// <summary>
        /// 
        /// </summary>
        StyleFontWeight,
        /// <summary>
        /// 
        /// </summary>
        StyleHeight,
        /// <summary>
        /// 
        /// </summary>
        StyleTextDecoration,
        /// <summary>
        /// 
        /// </summary>
        StyleWidth,
        /// <summary>
        /// 
        /// </summary>
        StyleListStyleImage,
        /// <summary>
        /// 
        /// </summary>
        StyleListStyleType,
        /// <summary>
        /// 
        /// </summary>
        StyleCursor,
        /// <summary>
        /// 
        /// </summary>
        StyleDirection,
        /// <summary>
        /// 
        /// </summary>
        StyleDisplay,
        /// <summary>
        /// 
        /// </summary>
        StyleFilter,
        /// <summary>
        /// 
        /// </summary>
        StyleFontVariant,
        /// <summary>
        /// 
        /// </summary>
        StyleLeft,
        /// <summary>
        /// 
        /// </summary>
        StyleMargin,
        /// <summary>
        /// 
        /// </summary>
        StyleMarginBottom,
        /// <summary>
        /// 
        /// </summary>
        StyleMarginLeft,
        /// <summary>
        /// 
        /// </summary>
        StyleMarginRight,
        /// <summary>
        /// 
        /// </summary>
        StyleMarginTop,
        /// <summary>
        /// 
        /// </summary>
        StyleOverflow,
        /// <summary>
        /// 
        /// </summary>
        StyleOverflowX,
        /// <summary>
        /// 
        /// </summary>
        StyleOverflowY,
        /// <summary>
        /// 
        /// </summary>
        StylePadding,
        /// <summary>
        /// 
        /// </summary>
        StylePaddingBottom,
        /// <summary>
        /// 
        /// </summary>
        StylePaddingLeft,
        /// <summary>
        /// 
        /// </summary>
        StylePaddingRight,
        /// <summary>
        /// 
        /// </summary>
        StylePaddingTop,
        /// <summary>
        /// 
        /// </summary>
        StylePosition,
        /// <summary>
        /// 
        /// </summary>
        StyleTextAlign,
        /// <summary>
        /// 
        /// </summary>
        StyleVerticalAlign,
        /// <summary>
        /// 
        /// </summary>
        StyleTextOverflow,
        /// <summary>
        /// 
        /// </summary>
        StyleTop,
        /// <summary>
        /// 
        /// </summary>
        StyleVisibility,
        /// <summary>
        /// 
        /// </summary>
        StyleWhiteSpace,
        /// <summary>
        /// 
        /// </summary>
        StyleZIndex
    }
}