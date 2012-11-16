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
namespace System.Web
{
    /// <summary>
    /// IHttpSessionProviderBase
    /// </summary>
    public interface IHttpSessionExProvider : Collections.IIndexer<string, object>
    {
        /// <summary>
        /// Deletes this instance.
        /// </summary>
        void Delete();
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        object GetValue(object key);
        /// <summary>
        /// Gets a value indicating whether this instance is new session.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is new session; otherwise, <c>false</c>.
        /// </value>
        bool IsNewSession { get; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
        /// <summary>
        /// Occurs when [new session created].
        /// </summary>
        event EventHandler NewSessionCreated;
        /// <summary>
        /// Called when [new session created].
        /// </summary>
        void OnNewSessionCreated();
        /// <summary>
        /// Called when [session acquired].
        /// </summary>
        void OnSessionAcquired();
        /// <summary>
        /// Occurs when [session acquired].
        /// </summary>
        event EventHandler SessionAcquired;
        /// <summary>
        /// Gets or sets the session ID.
        /// </summary>
        /// <value>
        /// The session ID.
        /// </value>
        string SessionID { get; set; }
        /// <summary>
        /// Gets the session uid.
        /// </summary>
        string SessionUid { get; }
        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void SetValue(object key, object value);
    }

    /// <summary>
    /// HttpSessionProviderBase
    /// </summary>
    public abstract class HttpSessionExProviderBase : IHttpSessionExProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpSessionExProviderBase"/> class.
        /// </summary>
        public HttpSessionExProviderBase()
            : base()
        {
            IsNewSession = true;
            SessionUid = ((string)GetValue("_suid") ?? string.Empty);
        }

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified key.
        /// </summary>
        public object this[string key]
        {
            get { return GetValue(key); }
            set { SetValue(key, value); }
        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        public virtual void Delete()
        {
            IsNewSession = true;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public abstract object GetValue(object key);

        /// <summary>
        /// Gets or sets a value indicating whether this instance is new session.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is new session; otherwise, <c>false</c>.
        /// </value>
        public bool IsNewSession { get; protected set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public virtual string Name { get; set; }

        /// <summary>
        /// Occurs when [new session created].
        /// </summary>
        public event EventHandler NewSessionCreated;

        /// <summary>
        /// Called when [new session created].
        /// </summary>
        public virtual void OnNewSessionCreated()
        {
            var sessionUid = SessionUid = Guid.NewGuid().ToString();
            SetValue("_suid", sessionUid);
            var newSessionCreated = NewSessionCreated;
            if (newSessionCreated != null)
                newSessionCreated(this, EventArgs.Empty);
        }

        /// <summary>
        /// Called when [session acquired].
        /// </summary>
        public virtual void OnSessionAcquired()
        {
            var sessionAcquired = SessionAcquired;
            if (sessionAcquired != null)
                sessionAcquired(this, EventArgs.Empty);
        }

        /// <summary>
        /// Occurs when [session acquired].
        /// </summary>
        public event EventHandler SessionAcquired;

        /// <summary>
        /// Gets or sets the session ID.
        /// </summary>
        /// <value>
        /// The session ID.
        /// </value>
        public string SessionID { get; set; }

        /// <summary>
        /// Gets or sets the session uid.
        /// </summary>
        /// <value>
        /// The session uid.
        /// </value>
        public string SessionUid { get; protected set; }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public abstract void SetValue(object key, object value);

        /// <summary>
        /// Sets the session provider.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="sessionExProvider">The session ex provider.</param>
        protected static void SetSessionProvider(HttpContext httpContext, HttpSessionExProviderBase sessionExProvider)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            if (sessionExProvider == null)
                throw new ArgumentNullException("sessionExProvider");
            httpContext.SetSessionExProvider(sessionExProvider);
        }
    }
}