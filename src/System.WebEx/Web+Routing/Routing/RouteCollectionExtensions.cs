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
using System.Reflection;
using System.Threading;
namespace System.Web.Routing
{
    /// <summary>
    /// RouteCollectionExtensions
    /// </summary>
    public static class RouteCollectionExtensions
    {
        /// <summary>
        /// Ignores the route ex.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="urls">The urls.</param>
        public static void IgnoreRouteEx(this RouteCollection routes, string[] urls) { foreach (var url in urls) routes.IgnoreRouteEx(url, null); }
        /// <summary>
        /// Ignores the route ex.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="urls">The urls.</param>
        /// <param name="constraints">The constraints.</param>
        public static void IgnoreRouteEx(this RouteCollection routes, string[] urls, object constraints) { foreach (var url in urls) routes.IgnoreRouteEx(url, constraints); }
        /// <summary>
        /// Ignores the route ex.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="url">The URL.</param>
        public static void IgnoreRouteEx(this RouteCollection routes, string url) { routes.IgnoreRouteEx(url, null); }
        /// <summary>
        /// Ignores the route ex.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="url">The URL.</param>
        /// <param name="constraints">The constraints.</param>
        public static void IgnoreRouteEx(this RouteCollection routes, string url, object constraints)
        {
            if (routes == null)
                throw new ArgumentNullException("routes");
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url");
            routes.Add(new IgnoreRouteExInternal(url) { Constraints = new RouteValueDictionary(constraints) });
        }

        /// <summary>
        /// Throws the route ex.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="urls">The urls.</param>
        public static void ThrowRouteEx(this RouteCollection routes, Exception exception, string[] urls) { foreach (var url in urls) routes.ThrowRouteEx(exception, url, null); }
        /// <summary>
        /// Throws the route ex.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="urls">The urls.</param>
        /// <param name="constraints">The constraints.</param>
        public static void ThrowRouteEx(this RouteCollection routes, Exception exception, string[] urls, object constraints) { foreach (var url in urls) routes.ThrowRouteEx(exception, url, constraints); }
        /// <summary>
        /// Throws the route ex.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="url">The URL.</param>
        public static void ThrowRouteEx(this RouteCollection routes, Exception exception, string url) { routes.ThrowRouteEx(exception, url, null); }
        /// <summary>
        /// Throws the route ex.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="url">The URL.</param>
        /// <param name="constraints">The constraints.</param>
        public static void ThrowRouteEx(this RouteCollection routes, Exception exception, string url, object constraints)
        {
            if (routes == null)
                throw new ArgumentNullException("routes");
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url");
            routes.Add(new ThrowRouteExInternal(url, exception) { Constraints = new RouteValueDictionary(constraints) });
        }

        /// <summary>
        /// Aliases the route ex.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="aliases">The aliases.</param>
        /// <param name="url">The URL.</param>
        public static void AliasRouteEx(this RouteCollection routes, string[] aliases, string url) { foreach (var alias in aliases) routes.AliasRouteEx(alias, url, null, (left, right) => left); }
        /// <summary>
        /// Aliases the route ex.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="aliases">The aliases.</param>
        /// <param name="url">The URL.</param>
        /// <param name="aliasConstraints">The alias constraints.</param>
        public static void AliasRouteEx(this RouteCollection routes, string[] aliases, string url, object aliasConstraints) { foreach (var alias in aliases) routes.AliasRouteEx(alias, url, null, (left, right) => left); }
        /// <summary>
        /// Aliases the route ex.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="alias">The alias.</param>
        /// <param name="url">The URL.</param>
        public static void AliasRouteEx(this RouteCollection routes, string alias, string url) { routes.AliasRouteEx(alias, url, null, (left, right) => left); }
        /// <summary>
        /// Aliases the route ex.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="alias">The alias.</param>
        /// <param name="url">The URL.</param>
        /// <param name="aliasConstraints">The alias constraints.</param>
        public static void AliasRouteEx(this RouteCollection routes, string alias, string url, object aliasConstraints) { routes.AliasRouteEx(alias, url, null, (left, right) => left); }
        /// <summary>
        /// Aliases the route ex.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="alias">The alias.</param>
        /// <param name="url">The URL.</param>
        /// <param name="aliasConstraints">The alias constraints.</param>
        /// <param name="routeDataJoiner">The route data joiner.</param>
        public static void AliasRouteEx(this RouteCollection routes, string alias, string url, object aliasConstraints, Func<RouteData, RouteData, RouteData> routeDataJoiner)
        {
            if (routes == null)
                throw new ArgumentNullException("routes");
            if (alias == null)
                throw new ArgumentNullException("alias");
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url");
            if (routeDataJoiner == null)
                throw new ArgumentNullException("routeDataJoiner");
#if CLR4
            EnsureRouteCollectionReaderWriterLock(routes);
#endif
            routes.Add(new AliasRouteExInternal(alias, () => routes.FindRouteDataByUrl(HttpContext.Current, url), routeDataJoiner) { Constraints = new RouteValueDictionary(aliasConstraints) });
        }

        /// <summary>
        /// Aliases the route ex.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="aliases">The aliases.</param>
        /// <param name="routeData">The route data.</param>
        public static void AliasRouteEx(this RouteCollection routes, string[] aliases, RouteData routeData) { foreach (var alias in aliases) routes.AliasRouteEx(alias, routeData, null, (left, right) => left); }
        /// <summary>
        /// Aliases the route ex.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="aliases">The aliases.</param>
        /// <param name="routeData">The route data.</param>
        /// <param name="aliasConstraints">The alias constraints.</param>
        public static void AliasRouteEx(this RouteCollection routes, string[] aliases, RouteData routeData, object aliasConstraints) { foreach (var alias in aliases) routes.AliasRouteEx(alias, routeData, null, (left, right) => left); }
        /// <summary>
        /// Aliases the route ex.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="alias">The alias.</param>
        /// <param name="routeData">The route data.</param>
        public static void AliasRouteEx(this RouteCollection routes, string alias, RouteData routeData) { routes.AliasRouteEx(alias, routeData, null, (left, right) => left); }
        /// <summary>
        /// Aliases the route ex.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="alias">The alias.</param>
        /// <param name="routeData">The route data.</param>
        /// <param name="aliasConstraints">The alias constraints.</param>
        public static void AliasRouteEx(this RouteCollection routes, string alias, RouteData routeData, object aliasConstraints) { routes.AliasRouteEx(alias, routeData, null, (left, right) => left); }
        /// <summary>
        /// Aliases the route ex.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="alias">The alias.</param>
        /// <param name="routeData">The route data.</param>
        /// <param name="aliasConstraints">The alias constraints.</param>
        /// <param name="routeDataJoiner">The route data joiner.</param>
        public static void AliasRouteEx(this RouteCollection routes, string alias, RouteData routeData, object aliasConstraints, Func<RouteData, RouteData, RouteData> routeDataJoiner)
        {
            if (routes == null)
                throw new ArgumentNullException("routes");
            if (string.IsNullOrEmpty(alias))
                throw new ArgumentNullException("alias");
            if (routeData == null)
                throw new ArgumentNullException("routeData");
            if (routeDataJoiner == null)
                throw new ArgumentNullException("routeDataJoiner");
#if CLR4
            EnsureRouteCollectionReaderWriterLock(routes);
#endif
            routes.Add(new AliasRouteExInternal(alias, () => routeData, routeDataJoiner) { Constraints = new RouteValueDictionary(aliasConstraints) });
        }

#if CLR4
        private readonly static FieldInfo _rwLockField = typeof(RouteCollection).GetField("_rwLock", BindingFlags.NonPublic | BindingFlags.Instance);
        private readonly static FieldInfo _fIsReentrantField = typeof(ReaderWriterLockSlim).GetField("fIsReentrant", BindingFlags.NonPublic | BindingFlags.Instance);
        private static void EnsureRouteCollectionReaderWriterLock(RouteCollection routes)
        {
            var rwLock = (ReaderWriterLockSlim)_rwLockField.GetValue(routes);
            if (rwLock.RecursionPolicy != LockRecursionPolicy.SupportsRecursion)
                _fIsReentrantField.SetValue(rwLock, true);
        }
#endif

        #region Internal-Routes

        private sealed class IgnoreRouteExInternal : Route
        {
            public IgnoreRouteExInternal(string url)
                : base(url, new StopRoutingHandler()) { }
            public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary routeValues) { return null; }
        }

        private sealed class AliasRouteExInternal : Route
        {
            private Func<RouteData> _routeDataFinder;
            private Func<RouteData, RouteData, RouteData> _routeDataJoiner;
            public AliasRouteExInternal(string alias, Func<RouteData> routeDataFinder, Func<RouteData, RouteData, RouteData> routeDataJoiner)
                : base(alias, null) { _routeDataFinder = routeDataFinder; _routeDataJoiner = routeDataJoiner; }
            public override RouteData GetRouteData(HttpContextBase httpContext)
            {
                var aliasRouteData = base.GetRouteData(httpContext);
                if (aliasRouteData == null)
                    return null;
                var routeData = _routeDataFinder();
                return (routeData != null ? _routeDataJoiner(routeData, aliasRouteData) : null);
            }
            public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
            {
                return null; // base.GetVirtualPath(requestContext, values);
            }
        }

        private sealed class ThrowRouteExInternal : Route
        {
            public ThrowRouteExInternal(string url, Exception exception)
                : base(url, new ThrowRouteExHandlerInternal(exception)) { }
            public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary routeValues)
            {
                return null;
            }
        }

        private sealed class ThrowRouteExHandlerInternal : IRouteHandler
        {
            private Exception _exception;
            public ThrowRouteExHandlerInternal(Exception exception)
            {
                if (exception == null)
                    throw new ArgumentNullException("exception");
                _exception = exception;
            }
            public IHttpHandler GetHttpHandler(RequestContext requestContext) { throw _exception; }
        }

        #endregion

        #region Find Route-Data

        /// <summary>
        /// Finds the route data by URL.
        /// </summary>
        /// <param name="routes">The routes.</param>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public static RouteData FindRouteDataByUrl(this RouteCollection routes, HttpContext httpContext, string url)
        {
            if (routes == null)
                throw new ArgumentNullException("routes");
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url");
            var injectedHttpContext = new HttpContextInjector(httpContext, new HttpRequestInjector(httpContext.Request, url));
            return routes.GetRouteData(injectedHttpContext);
        }

        private sealed class HttpContextInjector : HttpContextWrapper
        {
            private HttpRequestBase _request;
            public HttpContextInjector(HttpContext httpContext, HttpRequestBase request)
                : base(httpContext) { _request = request; }
            public override HttpRequestBase Request
            {
                get { return _request; }
            }
        }

        private sealed class HttpRequestInjector : HttpRequestWrapper
        {
            private string _appRelativeCurrentExecutionFilePath;
            public HttpRequestInjector(HttpRequest httpRequest, string appRelativeCurrentExecutionFilePath)
                : base(httpRequest) { _appRelativeCurrentExecutionFilePath = appRelativeCurrentExecutionFilePath; }
            public override string AppRelativeCurrentExecutionFilePath
            {
                get { return _appRelativeCurrentExecutionFilePath; }
            }
        }

        #endregion
    }
}