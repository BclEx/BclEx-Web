#region Foreign-License
// .Net40 Kludge
#endregion
#if !CLR4
using System.Reflection;
using System.Web.UI;
using System.Text;
using System.Web.Routing;
using System.Runtime.CompilerServices;
namespace System.Web
{
    /// <summary>
    /// HttpResponseKludge
    /// </summary>
    public static partial class HttpResponseKludge
    {
        #region This

        /// <summary>
        /// This
        /// </summary>
        private class This : ExtensionThisBase<This, HttpResponse>
        {
            private static readonly FieldInfo _isRequestBeingRedirectedField = typeof(HttpResponse).GetField("_isRequestBeingRedirected", BindingFlags.Instance | BindingFlags.NonPublic);
            private static readonly FieldInfo _contextField = typeof(HttpResponse).GetField("_context", BindingFlags.Instance | BindingFlags.NonPublic);

            public HttpContext _context
            {
                get { return (HttpContext)_contextField.GetValue(t); }
                set { _contextField.SetValue(t, value); }
            }

            public bool _isRequestBeingRedirected
            {
                get { return (bool)_isRequestBeingRedirectedField.GetValue(t); }
                set { _isRequestBeingRedirectedField.SetValue(t, value); }
            }

            internal HttpRequest Request
            {
                get { return (_context == null ? null : _context.Request); }
            }
        }

        #endregion

        //private static string UrlEncodeRedirect(this HttpResponse t, string url)
        //{
        //    var @this = This.Get(t);
        //    int index = url.IndexOf('?');
        //    if (index >= 0)
        //    {
        //        var httpRequest = HttpContext.Current.Request;
        //        Encoding e = (@this.Request != null ? httpRequest.ContentEncoding : t.ContentEncoding);
        //        url = HttpEncoderUtility.UrlEncodeSpaces(HttpUtility.UrlEncodeNonAscii(url.Substring(0, index), Encoding.UTF8)) + HttpUtility.UrlEncodeNonAscii(url.Substring(index), e);
        //        return url;
        //    }
        //    url = HttpEncoderUtility.UrlEncodeSpaces(HttpUtility.UrlEncodeNonAscii(url, Encoding.UTF8));
        //    return url;
        //}

        //[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        /// <summary>
        /// Picses the specified HTTP response.
        /// </summary>
        /// <param name="httpResponse">The HTTP response.</param>
        /// <param name="value">The value.</param>
        public static void Pics(this HttpResponse httpResponse, string value)
        {
            httpResponse.AppendHeader("PICS-Label", value);
        }

        internal static void Redirect(this HttpResponse t, string url, bool endResponse, bool permanent)
        {
            var @this = This.Get(t);
            if (url == null)
                throw new ArgumentNullException("url");
            if (url.IndexOf('\n') >= 0)
                throw new ArgumentException(EnvironmentEx2.GetResourceString("Cannot_redirect_to_newline"));
            //if (_headersWritten)
            //    throw new HttpException(EnvironmentEx.GetResourceString("Cannot_redirect_after_headers_sent"));
            var page = (@this._context.Handler as Page);
            if ((page != null) && page.IsCallback)
                throw new ApplicationException(EnvironmentEx2.GetResourceString("Redirect_not_allowed_in_callback"));
            //url = t.ApplyRedirectQueryStringIfRequired(url);
            //url = t.ApplyAppPathModifier(url);
            //url = t.ConvertToFullyQualifiedRedirectUrlIfRequired(url);
            //url = t.UrlEncodeRedirect(url);
            t.Clear();
#pragma warning disable 0618
            if (page != null && page.IsPostBack && page.SmartNavigation && @this.Request["__smartNavPostBack"] == "true")
            {
                t.Write("<BODY><ASP_SMARTNAV_RDIR url=\"");
                t.Write(HttpUtility.HtmlEncode(url));
                t.Write("\"></ASP_SMARTNAV_RDIR>");
                t.Write("</BODY>");
            }
            else
            {
                t.StatusCode = (permanent ? 301 : 302);
                t.RedirectLocation = url;
                url = (HttpContextEx.GetIsAbsoluteUrl(url) ? HttpUtility.HtmlAttributeEncode(url) : HttpUtility.HtmlAttributeEncode(HttpUtility.UrlEncode(url)));
                t.Write("<html><head><title>Object moved</title></head><body>\r\n");
                t.Write("<h2>Object moved to <a href=\"" + url + "\">here</a>.</h2>\r\n");
                t.Write("</body></html>\r\n");
            }
#pragma warning restore 0618
            @this._isRequestBeingRedirected = true;
            //var redirecting = httpResponse.Redirecting;
            //if (redirecting != null)
            //    redirecting(this, EventArgs.Empty);
            if (endResponse)
                t.End();
        }

        //[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        /// <summary>
        /// Redirects the permanent.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="url">The URL.</param>
        public static void RedirectPermanent(this HttpResponse t, string url) { Redirect(t, url, true, true); }
        //[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        /// <summary>
        /// Redirects the permanent.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="url">The URL.</param>
        /// <param name="endResponse">if set to <c>true</c> [end response].</param>
        public static void RedirectPermanent(this HttpResponse t, string url, bool endResponse) { Redirect(t, url, endResponse, true); }

        /// <summary>
        /// Redirects to route.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="routeValues">The route values.</param>
        public static void RedirectToRoute(this HttpResponse t, object routeValues) { t.RedirectToRoute(new RouteValueDictionary(routeValues)); }
        //[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        /// <summary>
        /// Redirects to route.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="routeName">Name of the route.</param>
        public static void RedirectToRoute(this HttpResponse t, string routeName) { t.RedirectToRoute(routeName, null, false); }
        //[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        /// <summary>
        /// Redirects to route.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="routeValues">The route values.</param>
        public static void RedirectToRoute(this HttpResponse t, RouteValueDictionary routeValues) { t.RedirectToRoute(null, routeValues, false); }
        /// <summary>
        /// Redirects to route.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        public static void RedirectToRoute(this HttpResponse t, string routeName, object routeValues) { t.RedirectToRoute(routeName, new RouteValueDictionary(routeValues), false); }
        //[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        /// <summary>
        /// Redirects to route.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        public static void RedirectToRoute(this HttpResponse t, string routeName, RouteValueDictionary routeValues) { t.RedirectToRoute(routeName, routeValues, false); }
        private static void RedirectToRoute(this HttpResponse t, string routeName, RouteValueDictionary routeValues, bool permanent)
        {
            var @this = This.Get(t);
            string virtualPath = null;
            var httpRequest = HttpContext.Current.Request;
            var data = RouteTable.Routes.GetVirtualPath(@this.Request.get_RequestContext(), routeName, routeValues);
            if (data != null)
                virtualPath = data.VirtualPath;
            if (string.IsNullOrEmpty(virtualPath))
                throw new InvalidOperationException(EnvironmentEx2.GetResourceString("No_Route_Found_For_Redirect"));
            t.Redirect(virtualPath, false, permanent);
        }

        /// <summary>
        /// Redirects to route permanent.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="routeValues">The route values.</param>
        public static void RedirectToRoutePermanent(this HttpResponse t, object routeValues) { t.RedirectToRoutePermanent(new RouteValueDictionary(routeValues)); }
        //[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        /// <summary>
        /// Redirects to route permanent.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="routeName">Name of the route.</param>
        public static void RedirectToRoutePermanent(this HttpResponse t, string routeName) { t.RedirectToRoute(routeName, null, true); }
        //[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        /// <summary>
        /// Redirects to route permanent.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="routeValues">The route values.</param>
        public static void RedirectToRoutePermanent(this HttpResponse t, RouteValueDictionary routeValues) { t.RedirectToRoute(null, routeValues, true); }
        /// <summary>
        /// Redirects to route permanent.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        public static void RedirectToRoutePermanent(this HttpResponse t, string routeName, object routeValues) { t.RedirectToRoute(routeName, new RouteValueDictionary(routeValues), true); }
        //[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        /// <summary>
        /// Redirects to route permanent.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        public static void RedirectToRoutePermanent(this HttpResponse t, string routeName, RouteValueDictionary routeValues) { t.RedirectToRoute(routeName, routeValues, true); }
    }
}
#endif