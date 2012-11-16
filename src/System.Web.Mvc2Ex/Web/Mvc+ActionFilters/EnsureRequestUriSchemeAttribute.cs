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
namespace System.Web.Mvc
{
    /// <summary>
    /// EnsureRequestUriSchemeAttribute
    /// </summary>
    public class EnsureRequestUriSchemeAttribute : ActionFilterAttribute
    {
        private Func<bool> _wantsSecureFunc = () => Convert.ToBoolean(SiteMap.CurrentNode["wantsSecure"] ?? (object)false);

        /// <summary>
        /// Gets or sets the wants secure func.
        /// </summary>
        /// <value>
        /// The wants secure func.
        /// </value>
        public Func<bool> WantsSecureFunc
        {
            get { return _wantsSecureFunc; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _wantsSecureFunc = value;
            }
        }

        /// <summary>
        /// Gets or sets the URI builder injector.
        /// </summary>
        /// <value>
        /// The URI builder injector.
        /// </value>
        public Func<UriBuilder, UriBuilder> UriBuilderInjector { get; set; }

        /// <summary>
        /// Called by the MVC framework before the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var r = filterContext.HttpContext.Request;
            if (r.HttpMethod != "GET")
                return;
            var wantsSecure = WantsSecureFunc();
            if ((wantsSecure && r.IsSecureConnection) || (!wantsSecure && !r.IsSecureConnection))
                return;
            // build new uri
            var uriBuilder = new UriBuilder(r.Url);
            uriBuilder.Scheme = (wantsSecure ? "https" : "http");
            uriBuilder.Port = -1;
            // append session query part
            var sessionQueryPart = GetSessionQueryPart();
            if (!string.IsNullOrEmpty(sessionQueryPart))
                uriBuilder.Query = (uriBuilder.Query == null || uriBuilder.Query.Length <= 1 ? sessionQueryPart : uriBuilder.Query.Substring(1) + "&" + sessionQueryPart);
            if (UriBuilderInjector != null)
                uriBuilder = UriBuilderInjector(uriBuilder);
            // redirect
            filterContext.HttpContext.Response.Redirect(uriBuilder.ToString());
        }

        private string GetSessionQueryPart()
        {
            return "s=" + HttpUtility.UrlEncode(HttpContext.Current.Session.SessionID);
        }
    }

    //// global.asa
    //protected void Application_BeginRequest()
    //{
    //    string forceSessionID = HttpContext.Current.Request["s"];
    //    if (!string.IsNullOrEmpty(forceSessionID))
    //        SessionIDManagerEx.ForceSessionID(forceSessionID);
    //}
}