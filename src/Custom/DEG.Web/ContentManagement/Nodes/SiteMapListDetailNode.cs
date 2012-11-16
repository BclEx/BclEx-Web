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
using System.Collections;
using System.Collections.Specialized;
namespace DEG.ContentManagement.Nodes
{
    /// <summary>
    /// SiteMapListDetailNode
    /// </summary>
	public class SiteMapListDetailNode : SiteMapPageNode
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteMapListDetailNode"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="key">The key.</param>
        /// <param name="url">The URL.</param>
        /// <param name="title">The title.</param>
		public SiteMapListDetailNode(SiteMapProvider provider, string key, string url, string title)
			: base(provider, key, url, title) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteMapListDetailNode"/> class.
        /// </summary>
        /// <param name="provider">The <see cref="T:System.Web.SiteMapProvider"/> with which the node is associated.</param>
        /// <param name="key">A provider-specific lookup key.</param>
        /// <param name="url">The URL of the page that the node represents within the site.</param>
        /// <param name="title">A label for the node, often displayed by navigation controls.</param>
        /// <param name="description">A description of the page that the node represents.</param>
        /// <param name="roles">An <see cref="T:System.Collections.IList"/> of roles that are allowed to view the page represented by the <see cref="T:System.Web.SiteMapNode"/>.</param>
        /// <param name="attributes">A <see cref="T:System.Collections.Specialized.NameValueCollection"/> of additional attributes used to initialize the <see cref="T:System.Web.SiteMapNode"/>.</param>
        /// <param name="explicitResourceKeys">A <see cref="T:System.Collections.Specialized.NameValueCollection"/> of explicit resource keys used for localization.</param>
        /// <param name="implicitResourceKey">An implicit resource key used for localization.</param>
        /// <exception cref="T:System.ArgumentNullException">
        ///   <see cref="T:System.Web.SiteMapProvider"/> is null.
        /// - or -
        ///   <paramref name="key"/> is null.
        ///   </exception>
		public SiteMapListDetailNode(SiteMapProvider provider, string key, string url, string title, string description, IList roles, NameValueCollection attributes, NameValueCollection explicitResourceKeys, string implicitResourceKey)
			: base(provider, key, url, title, description, roles, attributes, explicitResourceKeys, implicitResourceKey) { }
	}
}