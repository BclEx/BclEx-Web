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
using System;
namespace Contoso.Web.Integrate
{
    /// <summary>
    /// GoogleSiteMapNode
    /// </summary>
    public struct GoogleSiteMapNode
    {
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url { get; set; }
        /// <summary>
        /// Gets or sets the page dynamism.
        /// </summary>
        /// <value>
        /// The page dynamism.
        /// </value>
        public string PageDynamism { get; set; }
        /// <summary>
        /// Gets or sets the last modify date.
        /// </summary>
        /// <value>
        /// The last modify date.
        /// </value>
        public DateTime? LastModifyDate { get; set; }
        /// <summary>
        /// Gets or sets the page priority.
        /// </summary>
        /// <value>
        /// The page priority.
        /// </value>
        public double? PagePriority { get; set; }
    }
}