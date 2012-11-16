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
#if !CLR4
using System.Globalization;
using System.Collections;
using System.Security.Principal;
using System.Web.Caching;
namespace System.Web
{
    /// <summary>
    /// HttpContextWrapper
    /// </summary>
    //[TypeForwardedFrom("System.Web.Abstractions, Version=3.5.0.0, Culture=Neutral, PublicKeyToken=31bf3856ad364e35")]
    public class HttpContextWrapper : HttpContextBase
    {
        private readonly HttpContext _context;

        public HttpContextWrapper(HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            _context = httpContext;
        }

        public override void AddError(Exception errorInfo) { _context.AddError(errorInfo); }
        public override void ClearError() { _context.ClearError(); }
        public override object GetGlobalResourceObject(string classKey, string resourceKey) { return HttpContext.GetGlobalResourceObject(classKey, resourceKey); }
        public override object GetGlobalResourceObject(string classKey, string resourceKey, CultureInfo culture) { return HttpContext.GetGlobalResourceObject(classKey, resourceKey, culture); }
        public override object GetLocalResourceObject(string virtualPath, string resourceKey) { return HttpContext.GetLocalResourceObject(virtualPath, resourceKey); }
        public override object GetLocalResourceObject(string virtualPath, string resourceKey, CultureInfo culture) { return HttpContext.GetLocalResourceObject(virtualPath, resourceKey, culture); }
        public override object GetSection(string sectionName) { return _context.GetSection(sectionName); }
        public override object GetService(Type serviceType) { return ((IServiceProvider)_context).GetService(serviceType); }
        public override void RemapHandler(IHttpHandler handler) { _context.RemapHandler(handler); }
        public override void RewritePath(string path) { _context.RewritePath(path); }
        public override void RewritePath(string path, bool rebaseClientPath) { _context.RewritePath(path, rebaseClientPath); }
        public override void RewritePath(string filePath, string pathInfo, string queryString) { _context.RewritePath(filePath, pathInfo, queryString); }
        public override void RewritePath(string filePath, string pathInfo, string queryString, bool setClientFilePath) { _context.RewritePath(filePath, pathInfo, queryString, setClientFilePath); }
        public override void SetSessionStateBehavior(SessionStateBehavior sessionStateBehavior) { _context.SetSessionStateBehavior(sessionStateBehavior); }

        public override Exception[] AllErrors
        {
            get { return _context.AllErrors; }
        }
        public override HttpApplicationStateBase Application
        {
            get { return new HttpApplicationStateWrapper(_context.Application); }
        }
        public override HttpApplication ApplicationInstance
        {
            get { return _context.ApplicationInstance; }
            set { _context.ApplicationInstance = value; }
        }
        public override Cache Cache
        {
            get { return _context.Cache; }
        }
        public override IHttpHandler CurrentHandler
        {
            get { return _context.CurrentHandler; }
        }
        public override RequestNotification CurrentNotification
        {
            get { return _context.CurrentNotification; }
        }
        public override Exception Error
        {
            get { return _context.Error; }
        }
        public override IHttpHandler Handler
        {
            get { return _context.Handler; }
            set { _context.Handler = value; }
        }
        public override bool IsCustomErrorEnabled
        {
            get { return _context.IsCustomErrorEnabled; }
        }
        public override bool IsDebuggingEnabled
        {
            get { return _context.IsDebuggingEnabled; }
        }
        public override bool IsPostNotification
        {
            get { return _context.IsDebuggingEnabled; }
        }
        public override IDictionary Items
        {
            get { return _context.Items; }
        }
        public override IHttpHandler PreviousHandler
        {
            get { return _context.PreviousHandler; }
        }
        public override ProfileBase Profile
        {
            get { return _context.Profile; }
        }
        public override HttpRequestBase Request
        {
            get { return new HttpRequestWrapper(_context.Request); }
        }
        public override HttpResponseBase Response
        {
            get { return new HttpResponseWrapper(_context.Response); }
        }
        public override HttpServerUtilityBase Server
        {
            get { return new HttpServerUtilityWrapper(_context.Server); }
        }
        public override HttpSessionStateBase Session
        {
            get
            {
                var session = _context.Session;
                return (session == null ? null : new HttpSessionStateWrapper(session));
            }
        }
        public override bool SkipAuthorization
        {
            get { return _context.SkipAuthorization; }
            set { _context.SkipAuthorization = value; }
        }
        public override DateTime Timestamp
        {
            get { return _context.Timestamp; }
        }
        public override TraceContext Trace
        {
            get { return _context.Trace; }
        }
        public override IPrincipal User
        {
            get { return _context.User; }
            set { _context.User = value; }
        }
    }
}
#endif