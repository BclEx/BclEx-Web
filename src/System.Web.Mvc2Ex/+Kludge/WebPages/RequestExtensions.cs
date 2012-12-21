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
#if MVC2
namespace System.Web.WebPages
{
    /// <summary>
    /// RequestExtensions
    /// </summary>
    public static class RequestExtensions
    {
        /// <summary>
        /// Determines whether [is URL local to host] [the specified request].
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="url">The URL.</param>
        /// <returns>
        ///   <c>true</c> if [is URL local to host] [the specified request]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsUrlLocalToHost(this HttpRequestBase request, string url)
        {
            return (string.IsNullOrEmpty(url) ? false : (url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || ((url.Length > 1 && url[0] == '~') && url[1] == '/'));
        }
    }
}
#endif