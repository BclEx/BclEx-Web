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
namespace Contoso.Web.UI
{
    /// <summary>
    /// HttpPage
    /// </summary>
    public class HttpPage
    {
        /// <summary>
        /// WebSyndicationFormat
        /// </summary>
        public enum WebSyndicationFormat
        {
            /// <summary>
            /// Atom
            /// </summary>
            Atom,
            /// <summary>
            /// Rss
            /// </summary>
            Rss,
        }

        /// <summary>
        /// WebSyndication
        /// </summary>
        public struct WebSyndication
        {
            /// <summary>
            /// Gets or sets the URI.
            /// </summary>
            /// <value>
            /// The URI.
            /// </value>
            public string Uri { get; set; }
            /// <summary>
            /// Gets or sets the title.
            /// </summary>
            /// <value>
            /// The title.
            /// </value>
            public string Title { get; set; }
            /// <summary>
            /// Gets or sets the format.
            /// </summary>
            /// <value>
            /// The format.
            /// </value>
            public WebSyndicationFormat Format { get; set; }
        }

        /// <summary>
        /// HttpHead
        /// </summary>
        public class HttpHead : IHttpPageMetatag
        {
            /// <summary>
            /// Gets or sets a value indicating whether [no index].
            /// </summary>
            /// <value>
            ///   <c>true</c> if [no index]; otherwise, <c>false</c>.
            /// </value>
            public bool NoIndex { get; set; }
            /// <summary>
            /// Gets or sets the canonical URI.
            /// </summary>
            /// <value>
            /// The canonical URI.
            /// </value>
            public string CanonicalUri { get; set; }
            /// <summary>
            /// Gets or sets the title.
            /// </summary>
            /// <value>
            /// The title.
            /// </value>
            public string Title { get; set; }
            /// <summary>
            /// Gets or sets the keywords.
            /// </summary>
            /// <value>
            /// The keywords.
            /// </value>
            public string Keywords { get; set; }
            /// <summary>
            /// Gets or sets the tag.
            /// </summary>
            /// <value>
            /// The tag.
            /// </value>
            public string Tag { get; set; }
            /// <summary>
            /// Gets or sets the author.
            /// </summary>
            /// <value>
            /// The author.
            /// </value>
            public string Author { get; set; }
            /// <summary>
            /// Gets or sets the developer.
            /// </summary>
            /// <value>
            /// The developer.
            /// </value>
            public string Developer { get; set; }
            /// <summary>
            /// Gets or sets the copyright.
            /// </summary>
            /// <value>
            /// The copyright.
            /// </value>
            public string Copyright { get; set; }
            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            /// <value>
            /// The description.
            /// </value>
            public string Description { get; set; }
            /// <summary>
            /// Gets or sets the icon URI.
            /// </summary>
            /// <value>
            /// The icon URI.
            /// </value>
            public string IconUri { get; set; }
            /// <summary>
            /// Gets or sets the syndications.
            /// </summary>
            /// <value>
            /// The syndications.
            /// </value>
            public WebSyndication[] Syndications { get; set; }
            /// <summary>
            /// Gets or sets the search.
            /// </summary>
            /// <value>
            /// The search.
            /// </value>
            public string Search { get; set; }
            /// <summary>
            /// Gets or sets the search title.
            /// </summary>
            /// <value>
            /// The search title.
            /// </value>
            public string SearchTitle { get; set; }
            /// <summary>
            /// Initializes a new instance of the <see cref="HttpHead"/> class.
            /// </summary>
            public HttpHead()
            {
                Developer = "Local.DeveloperName";
            }
        }

        /// <summary>
        /// HttpPageCachingApproach
        /// </summary>
        public enum HttpPageCachingApproach
        {
            /// <summary>
            /// Default
            /// </summary>
            Default,
            /// <summary>
            /// LastModifyDateWithoutCaching
            /// </summary>
            LastModifyDateWithoutCaching,
            /// <summary>
            /// NoCache
            /// </summary>
            NoCache,
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpPage"/> class.
        /// </summary>
        public HttpPage() { Head = new HttpHead(); }

        /// <summary>
        /// Gets or sets the head.
        /// </summary>
        /// <value>
        /// The head.
        /// </value>
        public HttpHead Head { get; set; }
        /// <summary>
        /// Gets or sets the last modify date.
        /// </summary>
        /// <value>
        /// The last modify date.
        /// </value>
        public DateTime? LastModifyDate { get; set; }
        /// <summary>
        /// Gets or sets the caching approach.
        /// </summary>
        /// <value>
        /// The caching approach.
        /// </value>
        public HttpPageCachingApproach CachingApproach { get; set; }
    }
}