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
    /// HttpContextBase
    /// </summary>
    //[TypeForwardedFrom("System.Web.Abstractions, Version=3.5.0.0, Culture=Neutral, PublicKeyToken=31bf3856ad364e35")]
    public abstract class HttpContextBase : IServiceProvider
    {
        //[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        protected HttpContextBase() { }

        public virtual void AddError(Exception errorInfo) { throw new NotImplementedException(); }
        public virtual void ClearError() { throw new NotImplementedException(); }
        public virtual object GetGlobalResourceObject(string classKey, string resourceKey) { throw new NotImplementedException(); }
        public virtual object GetGlobalResourceObject(string classKey, string resourceKey, CultureInfo culture) { throw new NotImplementedException(); }
        public virtual object GetLocalResourceObject(string virtualPath, string resourceKey) { throw new NotImplementedException(); }
        public virtual object GetLocalResourceObject(string virtualPath, string resourceKey, CultureInfo culture) { throw new NotImplementedException(); }
        public virtual object GetSection(string sectionName) { throw new NotImplementedException(); }
        public virtual object GetService(Type serviceType) { throw new NotImplementedException(); }
        public virtual void RemapHandler(IHttpHandler handler) { throw new NotImplementedException(); }
        public virtual void RewritePath(string path) { throw new NotImplementedException(); }
        public virtual void RewritePath(string path, bool rebaseClientPath) { throw new NotImplementedException(); }
        public virtual void RewritePath(string filePath, string pathInfo, string queryString) { throw new NotImplementedException(); }
        public virtual void RewritePath(string filePath, string pathInfo, string queryString, bool setClientFilePath) { throw new NotImplementedException(); }

        public virtual void SetSessionStateBehavior(SessionStateBehavior sessionStateBehavior) { throw new NotImplementedException(); }

        public virtual Exception[] AllErrors
        {
            get { throw new NotImplementedException(); }
        }
        public virtual HttpApplicationStateBase Application
        {
            get { throw new NotImplementedException(); }
        }
        public virtual HttpApplication ApplicationInstance
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public virtual Cache Cache
        {
            get { throw new NotImplementedException(); }
        }
        public virtual IHttpHandler CurrentHandler
        {
            get { throw new NotImplementedException(); }
        }
        public virtual RequestNotification CurrentNotification
        {
            get { throw new NotImplementedException(); }
        }
        public virtual Exception Error
        {
            get { throw new NotImplementedException(); }
        }
        public virtual IHttpHandler Handler
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public virtual bool IsCustomErrorEnabled
        {
            get { throw new NotImplementedException(); }
        }
        public virtual bool IsDebuggingEnabled
        {
            get { throw new NotImplementedException(); }
        }
        public virtual bool IsPostNotification
        {
            get { throw new NotImplementedException(); }
        }
        public virtual IDictionary Items
        {
            get { throw new NotImplementedException(); }
        }
        public virtual IHttpHandler PreviousHandler
        {
            get { throw new NotImplementedException(); }
        }
        public virtual ProfileBase Profile
        {
            get { throw new NotImplementedException(); }
        }
        public virtual HttpRequestBase Request
        {
            get { throw new NotImplementedException(); }
        }
        public virtual HttpResponseBase Response
        {
            get { throw new NotImplementedException(); }
        }
        public virtual HttpServerUtilityBase Server
        {
            get { throw new NotImplementedException(); }
        }
        public virtual HttpSessionStateBase Session
        {
            get { throw new NotImplementedException(); }
        }
        public virtual bool SkipAuthorization
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public virtual DateTime Timestamp
        {
            get { throw new NotImplementedException(); }
        }
        public virtual TraceContext Trace
        {
            get { throw new NotImplementedException(); }
        }
        public virtual IPrincipal User
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}
#endif