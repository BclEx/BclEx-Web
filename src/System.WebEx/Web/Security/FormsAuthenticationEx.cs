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
//using System.Reflection;
//namespace System.Web.Security
//{
//    public static class FormsAuthenticationEx
//    {
//        private static readonly MethodInfo _encryptInfo;
//        private static readonly MethodInfo _fromUtcInfo;
//        private static readonly Type _cookielessHelperClassType;
//        private static readonly MethodInfo _useCookielessInfo;
//        private static readonly MethodInfo _setCookieValueInfo;

//        static FormsAuthenticationEx()
//        {
//            _encryptInfo = typeof(FormsAuthentication).GetMethod("Encrypt", BindingFlags.NonPublic | BindingFlags.Static);
//            if (_encryptInfo == null)
//                throw new Exception("Unable to get all required FormsAuthentication method Infos.");
//            _fromUtcInfo = typeof(FormsAuthenticationTicket).GetMethod("FromUtc", BindingFlags.NonPublic | BindingFlags.Static);
//            if (_fromUtcInfo == null)
//                throw new Exception("Unable to get all required FormsAuthenticationModule method Infos.");
//            _cookielessHelperClassType = typeof(FormsAuthenticationTicket).Assembly.GetType("System.Web.Security.CookielessHelperClass");
//            if (_cookielessHelperClassType == null)
//                throw new Exception("Unable to find CookielessHelperClass type.");
//            _useCookielessInfo = _cookielessHelperClassType.GetMethod("UseCookieless", BindingFlags.NonPublic | BindingFlags.Static);
//            _setCookieValueInfo = _cookielessHelperClassType.GetMethod("SetCookieValue", BindingFlags.NonPublic | BindingFlags.Instance);
//            if (_useCookielessInfo == null || _setCookieValueInfo == null)
//                throw new Exception("Unable to get all required CookielessHelperClass method Infos.");
//        }

//        public static HttpCookie GetAuthCookie(string userName, string userData, bool createPersistentCookie)
//        {
//            FormsAuthentication.Initialize();
//            return GetAuthCookie(userName, userData, createPersistentCookie, FormsAuthentication.FormsCookiePath);
//        }

//        //[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
//        public static HttpCookie GetAuthCookie(string userName, string userData, bool createPersistentCookie, string strCookiePath) { return GetAuthCookie(userName, userData, createPersistentCookie, strCookiePath, true); }

//        private static HttpCookie GetAuthCookie(string userName, string userData, bool createPersistentCookie, string strCookiePath, bool hexEncodedTicket)
//        {
//            FormsAuthentication.Initialize();
//            if (userName == null)
//                userName = string.Empty;
//            if (strCookiePath == null || strCookiePath.Length < 1)
//                strCookiePath = FormsAuthentication.FormsCookiePath;
//            var utcNow = DateTime.UtcNow;
//            var expirationUtc = utcNow.AddMinutes((double)FormsAuthentication.Timeout.Minutes);
//            var ticket = (FormsAuthenticationTicket)_fromUtcInfo.Invoke(null, new object[] { 2, userName, utcNow, expirationUtc, createPersistentCookie, userData ?? string.Empty, strCookiePath });
//            var str = (string)_encryptInfo.Invoke(null, new object[] { ticket, hexEncodedTicket });
//            if (str == null || str.Length < 1)
//                throw new HttpException("Unable_to_encrypt_cookie_ticket");
//            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, str)
//            {
//                HttpOnly = true,
//                Path = strCookiePath,
//                Secure = FormsAuthentication.RequireSSL
//            };
//            if (FormsAuthentication.CookieDomain != null)
//                cookie.Domain = FormsAuthentication.CookieDomain;
//            if (ticket.IsPersistent)
//                cookie.Expires = ticket.Expiration;
//            return cookie;
//        }

//        public static void SetAuthCookie(string userName, string userData, bool createPersistentCookie)
//        {
//            FormsAuthentication.Initialize();
//            SetAuthCookie(userName, userData, createPersistentCookie, FormsAuthentication.FormsCookiePath);
//        }

//        public static void SetAuthCookie(string userName, string userData, bool createPersistentCookie, string strCookiePath)
//        {
//            FormsAuthentication.Initialize();
//            var current = HttpContext.Current;
//            if (!current.Request.IsSecureConnection && FormsAuthentication.RequireSSL)
//                throw new HttpException("Connection_not_secure_creating_secure_cookie");
//            var flag = (bool)_useCookielessInfo.Invoke(null, new object[] { current, false, FormsAuthentication.CookieMode });
//            var cookie = GetAuthCookie(userName, userData, createPersistentCookie, flag ? "/" : strCookiePath, !flag);
//            var cookielessHelper = GetCookielessHelper(current);
//            if (!flag)
//            {
//                HttpContext.Current.Response.Cookies.Add(cookie);
//                _setCookieValueInfo.Invoke(cookielessHelper, new object[] { 'F', null });
//            }
//            else
//                _setCookieValueInfo.Invoke(cookielessHelper, new object[] { 'F', cookie.Value });
//        }

//        internal static object GetCookielessHelper(HttpContext context)
//        {
//            var items = context.Items;
//            if (items.Contains(_cookielessHelperClassType))
//                return items[_cookielessHelperClassType];
//            return items[_cookielessHelperClassType] = Activator.CreateInstance(_cookielessHelperClassType, BindingFlags.NonPublic | BindingFlags.Instance, null, new object[] { context }, null);
//        }
//    }
//}
