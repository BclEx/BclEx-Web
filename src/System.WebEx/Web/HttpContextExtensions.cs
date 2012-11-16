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
using System.Collections.Generic;
namespace System.Web
{
    /// <summary>
    /// HttpContextExtensions
    /// </summary>
    public static partial class HttpContextExtensions
    {
        private static readonly object _sessionExProviderKey = new object();

        /// <summary>
        /// Sets the session ex provider.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="sessionExProvider">The session ex provider.</param>
        public static void SetSessionExProvider(this HttpContext httpContext, HttpSessionExProviderBase sessionExProvider)
        {
            if (sessionExProvider == null)
                throw new ArgumentNullException("sessionExProvider");
            httpContext.Items[_sessionExProviderKey] = sessionExProvider;
        }

        /// <summary>
        /// Gets the session ex provider.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns></returns>
        public static HttpSessionExProviderBase GetSessionExProvider(this HttpContext httpContext)
        {
            return (HttpSessionExProviderBase)httpContext.Items[_sessionExProviderKey];
        }

        /// <summary>
        /// Transfers for URL routing.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="path">The path.</param>
        /// <param name="handlerBuilder">The handler builder.</param>
        public static void TransferForUrlRouting(this HttpContext httpContext, string path, Func<IHttpHandler> handlerBuilder)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");
            if (handlerBuilder == null)
                throw new ArgumentNullException("handlerBuilder");
            var originalPath = httpContext.Request.Path;
            httpContext.RewritePath(path, false);
            var httpHandler = handlerBuilder();
            if (httpHandler == null)
                throw new InvalidOperationException();
            httpHandler.ProcessRequest(httpContext);
            httpContext.RewritePath(originalPath, false);
        }

        /// <summary>
        /// Determines whether the specified HTTP context has extent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns>
        ///   <c>true</c> if the specified HTTP context has extent; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasExtent<T>(this HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            return httpContext.Items.Contains(typeof(T));
        }
        /// <summary>
        /// Determines whether the specified HTTP context has extent.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if the specified HTTP context has extent; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasExtent(this HttpContext httpContext, Type type)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            if (type == null)
                throw new ArgumentNullException("type");
            return httpContext.Items.Contains(type);
        }

        /// <summary>
        /// Clears the specified HTTP context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpContext">The HTTP context.</param>
        public static void Clear<T>(this HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            httpContext.Items[typeof(T)] = null;
        }
        /// <summary>
        /// Clears the specified HTTP context.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="type">The type.</param>
        public static void Clear(this HttpContext httpContext, Type type)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            if (type == null)
                throw new ArgumentNullException("type");
            httpContext.Items[type] = null;
        }

        /// <summary>
        /// Gets the specified HTTP context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns></returns>
        public static T Get<T>(this HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            return (T)httpContext.Items[typeof(T)];
        }
        /// <summary>
        /// Gets the many.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns></returns>
        public static IEnumerable<T> GetMany<T>(this HttpContext httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            return (IEnumerable<T>)httpContext.Items[typeof(IEnumerable<T>)];
        }
        /// <summary>
        /// Gets the specified HTTP context.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static object Get(this HttpContext httpContext, Type type)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            if (type == null)
                throw new ArgumentNullException("type");
            return httpContext.Items[type];
        }

        /// <summary>
        /// Sets the specified HTTP context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="value">The value.</param>
        public static void Set<T>(this HttpContext httpContext, T value)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            httpContext.Items[typeof(T)] = value;
        }
        /// <summary>
        /// Sets the many.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="value">The value.</param>
        public static void SetMany<T>(this HttpContext httpContext, IEnumerable<T> value)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            httpContext.Items[typeof(IEnumerable<T>)] = value;
        }
        /// <summary>
        /// Sets the specified HTTP context.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        public static void Set(this HttpContext httpContext, Type type, object value)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            if (type == null)
                throw new ArgumentNullException("type");
            httpContext.Items[type] = value;
        }

        /// <summary>
        /// Tries the get extent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="extent">The extent.</param>
        /// <returns></returns>
        public static bool TryGetExtent<T>(this HttpContext httpContext, out T extent)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            var key = typeof(T).ToString();
            if (!httpContext.Items.Contains(key))
            {
                extent = default(T);
                return false;
            }
            extent = (T)httpContext.Items[key];
            return true;
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="extents">The extents.</param>
        public static void AddRange(this HttpContext httpContext, IEnumerable<object> extents)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            if (extents == null)
                throw new ArgumentNullException("extents");
            foreach (var extent in extents)
                Set(httpContext, extent.GetType(), extent);
        }

        #region Abstractions

        /// <summary>
        /// Determines whether the specified HTTP context has extent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns>
        ///   <c>true</c> if the specified HTTP context has extent; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasExtent<T>(this HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            return httpContext.Items.Contains(typeof(T));
        }
        /// <summary>
        /// Determines whether the specified HTTP context has extent.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if the specified HTTP context has extent; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasExtent(this HttpContextBase httpContext, Type type)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            if (type == null)
                throw new ArgumentNullException("type");
            return httpContext.Items.Contains(type);
        }

        /// <summary>
        /// Clears the specified HTTP context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpContext">The HTTP context.</param>
        public static void Clear<T>(this HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            httpContext.Items[typeof(T)] = null;
        }
        /// <summary>
        /// Clears the specified HTTP context.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="type">The type.</param>
        public static void Clear(this HttpContextBase httpContext, Type type)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            if (type == null)
                throw new ArgumentNullException("type");
            httpContext.Items[type] = null;
        }

        /// <summary>
        /// Gets the specified HTTP context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns></returns>
        public static T Get<T>(this HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            return (T)httpContext.Items[typeof(T)];
        }
        /// <summary>
        /// Gets the many.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns></returns>
        public static IEnumerable<T> GetMany<T>(this HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            return (IEnumerable<T>)httpContext.Items[typeof(IEnumerable<T>)];
        }
        /// <summary>
        /// Gets the specified HTTP context.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static object Get(this HttpContextBase httpContext, Type type)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            if (type == null)
                throw new ArgumentNullException("type");
            return httpContext.Items[type];
        }

        /// <summary>
        /// Sets the specified HTTP context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="value">The value.</param>
        public static void Set<T>(this HttpContextBase httpContext, T value)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            httpContext.Items[typeof(T)] = value;
        }
        /// <summary>
        /// Sets the many.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="value">The value.</param>
        public static void SetMany<T>(this HttpContextBase httpContext, IEnumerable<T> value)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            httpContext.Items[typeof(IEnumerable<T>)] = value;
        }
        /// <summary>
        /// Sets the specified HTTP context.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        public static void Set(this HttpContextBase httpContext, Type type, object value)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            if (type == null)
                throw new ArgumentNullException("type");
            httpContext.Items[type] = value;
        }
        /// <summary>
        /// Tries the get extent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="extent">The extent.</param>
        /// <returns></returns>
        public static bool TryGetExtent<T>(this HttpContextBase httpContext, out T extent)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            var key = typeof(T).ToString();
            if (!httpContext.Items.Contains(key))
            {
                extent = default(T);
                return false;
            }
            extent = (T)httpContext.Items[key];
            return true;
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="extents">The extents.</param>
        public static void AddRange(this HttpContextBase httpContext, IEnumerable<object> extents)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");
            if (extents == null)
                throw new ArgumentNullException("extents");
            foreach (var extent in extents)
                Set(httpContext, extent.GetType(), extent);
        }

        #endregion
    }
}