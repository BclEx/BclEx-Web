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
using System.Web.UI.HtmlControls;
namespace Contoso.Web.UI
{
    /// <summary>
    /// HttpPageMapperExtentions
    /// </summary>
    public static class HttpPageMapperExtentions
    {
        /// <summary>
        /// HeaderControlId
        /// </summary>
        public class HeaderControlID
        {
            /// <summary>
            /// 
            /// </summary>
            public const string NoIndex = "HtmlHeadNoIndex";
            /// <summary>
            /// 
            /// </summary>
            public const string Canonical = "HtmlHeadCanonical";
            /// <summary>
            /// 
            /// </summary>
            public const string Icon = "HtmlHeadIcon";
            /// <summary>
            /// 
            /// </summary>
            public const string ShortcutIcon = "HtmlHeadShortcutIcon";
            /// <summary>
            /// 
            /// </summary>
            public const string Search = "HtmlHeadSearch";
            /// <summary>
            /// 
            /// </summary>
            public const string Syndication = "HtmlHeadRss";
            /// <summary>
            /// 
            /// </summary>
            public const string Title = "HtmlHeadTitle";
            /// <summary>
            /// 
            /// </summary>
            public const string Keyword = "HtmlHeadKeyword";
            /// <summary>
            /// 
            /// </summary>
            public const string Description = "HtmlHeadDescription";
            /// <summary>
            /// 
            /// </summary>
            public const string Tag = "HtmlHeadTag";
            /// <summary>
            /// 
            /// </summary>
            public const string Author = "HtmlHeadAuthor";
            /// <summary>
            /// 
            /// </summary>
            public const string Copyright = "HtmlHeadCopyright";
            /// <summary>
            /// 
            /// </summary>
            public const string Developer = "HtmlHeadDeveloper";
        }

        /// <summary>
        /// Maps to HTTP response.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="response">The response.</param>
        public static void MapToHttpResponse(this HttpPage page, HttpResponse response)
        {
            if (page == null)
                throw new ArgumentNullException("page");
            if (response == null)
                throw new ArgumentNullException("response");
            switch (page.CachingApproach)
            {
                case HttpPage.HttpPageCachingApproach.Default:
                    break;
                case HttpPage.HttpPageCachingApproach.LastModifyDateWithoutCaching:
                    var lastModifyDate = page.LastModifyDate;
                    if (lastModifyDate != null)
                    {
                        //NOTE: adding headers instead of Response.Cache because issues with NoCache and Last-Modified header
                        response.AddHeader("Cache-Control", "no-cache");
                        response.AddHeader("Pragma", "no-cache");
                        response.AddHeader("Expires", "-1");
                        response.AddHeader("Last-Modified", lastModifyDate.Value.ToUniversalTime().ToString("R"));
                    }
                    else
                        response.Cache.SetCacheability(HttpCacheability.NoCache);
                    break;
                case HttpPage.HttpPageCachingApproach.NoCache:
                    response.Cache.SetCacheability(HttpCacheability.NoCache);
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Maps to HTML head.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="htmlHead">The HTML head.</param>
        public static void MapToHtmlHead(this HttpPage page, HtmlHead htmlHead)
        {
            if (page == null)
                throw new ArgumentNullException("page");
            if (htmlHead == null)
                throw new ArgumentNullException("htmlHead");
            var pageHead = page.Head;
            if (pageHead == null)
                throw new NullReferenceException("page.Head");
            var htmlHeadControls = htmlHead.Controls;
            HtmlLink htmlLink;
            string text;
            // no-index
            if (pageHead.NoIndex)
                htmlHeadControls.Add(new HtmlMeta { ID = HeaderControlID.NoIndex, Name = "robots", Content = "noindex" });
            // canonical
            if (!string.IsNullOrEmpty(text = pageHead.CanonicalUri))
            {
                htmlLink = new HtmlLink { ID = HeaderControlID.Canonical, Href = text };
                htmlLink.Attributes["rel"] = "canonical";
                htmlHeadControls.Add(htmlLink);
            }
            // icon
            if (!string.IsNullOrEmpty(text = pageHead.IconUri))
            {
                if (string.Compare(text, "/favicon.ico", StringComparison.OrdinalIgnoreCase) != 0)
                    throw new InvalidOperationException(string.Format("InvalidHttpHeadIconA {0}", "/favicon.ico"));
                // icon (browser type A)
                htmlLink = new HtmlLink { ID = HeaderControlID.Icon, Href = text };
                htmlLink.Attributes["rel"] = "icon";
                htmlLink.Attributes["type"] = "image/x-icon";
                htmlHeadControls.Add(htmlLink);
                // shortcut icon (browser type B)
                htmlLink = new HtmlLink { ID = HeaderControlID.ShortcutIcon, Href = text };
                htmlLink.Attributes["rel"] = "shortcut icon";
                htmlLink.Attributes["type"] = "image/x-icon";
                htmlHeadControls.Add(htmlLink);
            }
            // search
            if (!string.IsNullOrEmpty(text = pageHead.Search))
            {
                htmlLink = new HtmlLink { ID = HeaderControlID.Search, Href = text };
                var title = pageHead.SearchTitle;
                if (!string.IsNullOrEmpty(title))
                    htmlLink.Attributes["title"] = title;
                htmlLink.Attributes["rel"] = "search";
                htmlLink.Attributes["type"] = "application/opensearchdescription+xml";
                htmlHeadControls.Add(htmlLink);
            }
            // rss/atom
            var syndications = pageHead.Syndications;
            if (syndications != null)
            {
                var id = string.Empty;
                for (int syndicationIndex = 1; syndicationIndex < syndications.Length; syndicationIndex++)
                {
                    var syndication = syndications[syndicationIndex];
                    htmlLink = new HtmlLink { ID = HeaderControlID.Syndication + id, Href = syndication.Uri };
                    var title = syndication.Title;
                    if (!string.IsNullOrEmpty(title))
                        htmlLink.Attributes["title"] = title;
                    htmlLink.Attributes["rel"] = "alternate";
                    htmlLink.Attributes["type"] = (syndication.Format == HttpPage.WebSyndicationFormat.Atom ? "application/atom+xml" : "application/rss+xml");
                    htmlHeadControls.Add(htmlLink);
                    id = (syndicationIndex++).ToString();
                }
            }
            // page title
            if (!string.IsNullOrEmpty(text = pageHead.Title))
                htmlHeadControls.Add(new HtmlTitle { ID = HeaderControlID.Title, Text = HttpUtility.HtmlEncode(text) });
            // page keyword
            if (!string.IsNullOrEmpty(text = pageHead.Keywords))
                htmlHeadControls.Add(new HtmlMeta { ID = HeaderControlID.Keyword, Name = "keywords", Content = text });
            // page description
            if (!string.IsNullOrEmpty(text = pageHead.Description))
                htmlHeadControls.Add(new HtmlMeta() { ID = HeaderControlID.Description, Name = "description", Content = text });
            // add search tag
            if (!string.IsNullOrEmpty(text = pageHead.Tag))
                htmlHeadControls.Add(new HtmlMeta { ID = HeaderControlID.Tag, Name = "tag", Content = text });
            // author
            if (!string.IsNullOrEmpty(text = pageHead.Author))
                htmlHeadControls.Add(new HtmlMeta { ID = HeaderControlID.Author, Name = "author", Content = text });
            // copyright
            if (!string.IsNullOrEmpty(text = pageHead.Copyright))
                htmlHeadControls.Add(new HtmlMeta { ID = HeaderControlID.Copyright, Name = "copyright", Content = text });
            // developer
            if (!string.IsNullOrEmpty(text = pageHead.Developer))
                htmlHeadControls.Add(new HtmlMeta { ID = HeaderControlID.Developer, Name = "developer", Content = text });
        }

        /// <summary>
        /// Maps to HTTP page.
        /// </summary>
        /// <param name="pageMetatag">The page metatag.</param>
        /// <param name="page">The page.</param>
        public static void MapToHttpPage(this IHttpPageMetatag pageMetatag, HttpPage page) { MapToHttpPage(pageMetatag, page, false); }
        /// <summary>
        /// Maps to HTTP page.
        /// </summary>
        /// <param name="pageMetatag">The page metatag.</param>
        /// <param name="page">The page.</param>
        /// <param name="forceMapping">if set to <c>true</c> [force mapping].</param>
        public static void MapToHttpPage(this IHttpPageMetatag pageMetatag, HttpPage page, bool forceMapping)
        {
            if (pageMetatag == null)
                throw new ArgumentNullException("metatag");
            if (page == null)
                throw new ArgumentNullException("page");
            var pageHead = page.Head;
            if (pageHead == null)
                throw new NullReferenceException("page.Head");
            //
            string text;
            if (!string.IsNullOrEmpty(text = pageMetatag.Description) || forceMapping)
                pageHead.Description = text;
            if (!string.IsNullOrEmpty(text = pageMetatag.Keywords) || forceMapping)
                pageHead.Keywords = text;
            if (!string.IsNullOrEmpty(text = pageMetatag.Title) || forceMapping)
                pageHead.Title = text;
            if (!string.IsNullOrEmpty(text = pageMetatag.Tag) || forceMapping)
                pageHead.Tag = text;
        }
    }
}