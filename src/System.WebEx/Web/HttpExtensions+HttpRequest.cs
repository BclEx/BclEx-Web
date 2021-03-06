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
    public static partial class HttpExtensions
    {
        /// <summary>
        /// Gets the user host address is intranet address.
        /// </summary>
        /// <param name="httpRequest">The HTTP request.</param>
        /// <returns></returns>
        public static bool GetUserHostAddressIsIntranetAddress(this HttpRequest httpRequest)
        {
            if (httpRequest == null)
                throw new ArgumentNullException("httpRequest");
            var remoteHost = httpRequest.UserHostAddress;
            // class c, b, and a respectivly
            return (remoteHost.StartsWith("192.168.") || remoteHost.StartsWith("172.16.") || remoteHost.StartsWith("10."));
        }

        /// <summary>
        /// Gets the is known spider.
        /// </summary>
        /// <param name="httpRequest">The HTTP request.</param>
        /// <returns></returns>
        public static bool GetIsKnownSpider(this HttpRequest httpRequest)
        {
            if (httpRequest == null)
                throw new ArgumentNullException("httpRequest");
            return httpRequest.Browser.Crawler;
        }
    }
}