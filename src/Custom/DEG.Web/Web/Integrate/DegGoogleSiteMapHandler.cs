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
using System.Web;
using DEG.ContentManagement.Nodes;
namespace Contoso.Web.Integrate
{
    /// <summary>
    /// GoogleSiteMapHDegGoogleSiteMapHandlerandler
    /// </summary>
    public class DegGoogleSiteMapHandler : GoogleSiteMapHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DegGoogleSiteMapHandler"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        public DegGoogleSiteMapHandler(string baseUrl)
            : base(baseUrl) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="DegGoogleSiteMapHandler"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="rootNode">The root node.</param>
        public DegGoogleSiteMapHandler(string baseUrl, SiteMapNode rootNode)
            : base(baseUrl, rootNode) { }

        /// <summary>
        /// Creates the site map node.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        protected override GoogleSiteMapNode CreateSiteMapNode(string baseUrl, SiteMapNode node)
        {
            var pageNode = (node as SiteMapPageNode);
            return (pageNode != null ? new GoogleSiteMapNode
            {
                Url = baseUrl + pageNode.Url,
                LastModifyDate = pageNode.LastModifyDate,
                PageDynamism = pageNode.PageDynamism,
                PagePriority = pageNode.PagePriority,
            } : new GoogleSiteMapNode { Url = baseUrl + node.Url });
        }
    }
}