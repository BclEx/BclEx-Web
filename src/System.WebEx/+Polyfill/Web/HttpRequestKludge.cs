#region Foreign-License
// .Net40 Kludge
#endregion
#if !CLR4
using System.Reflection;
using System.Web.UI;
using System.Text;
using System.Web.Routing;
namespace System.Web
{
    /// <summary>
    /// HttpResponseKludge
    /// </summary>
    public static partial class HttpRequestKludge
    {
        #region This

        /// <summary>
        /// This
        /// </summary>
        private class This : ExtensionThisBase<This, HttpRequest>
        {
            private static readonly FieldInfo _requestContextField = typeof(HttpRequest).GetField("_requestContext", BindingFlags.Instance | BindingFlags.NonPublic);
            private static readonly FieldInfo _contextField = typeof(HttpRequest).GetField("_context", BindingFlags.Instance | BindingFlags.NonPublic);

            public HttpContext _context
            {
                get { return (HttpContext)_contextField.GetValue(t); }
                set { _contextField.SetValue(t, value); }
            }

            public RequestContext _requestContext
            {
                get { return (RequestContext)_requestContextField.GetValue(t); }
                set { _requestContextField.SetValue(t, value); }
            }


            internal HttpContext Context
            {
                get { return _context; }
                set { _context = value; }
            }
        }

        #endregion

        internal static RequestContext get_RequestContext(this HttpRequest t)
        {
            var @this = This.Get(t);
            if (@this._requestContext == null)
            {
                HttpContext httpContext = @this.Context ?? HttpContext.Current;
                @this._requestContext = new RequestContext(new HttpContextWrapper(httpContext), new RouteData());
            }
            return @this._requestContext;
        }
        //[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        internal static void set_RequestContext(this HttpRequest t, RequestContext value) { var @this = This.Get(t); @this._requestContext = value; }
    }
}
#endif