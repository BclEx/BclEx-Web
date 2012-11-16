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
        //public static bool RedirectToErrorPage(this HttpResponse httpResponse, string url)
        //{
        //    return false;
        //}

		// use built-in caching setters : httpResponse.Cache.SetCacheability(HttpCacheability.NoCache);
        //[Obsolete]
        //public static void AttachNoCache(this HttpResponse httpResponse)
        //{
        //    if (httpResponse == null)
        //        throw new ArgumentNullException("httpResponse");
        //    httpResponse.Expires = -1;
        //    httpResponse.AddHeader("Pragma", "no-cache");
        //    httpResponse.CacheControl = "no-cache";
        //    httpResponse.CacheControl = "Private";
        //}

        /// <summary>
        /// Attaches the file header.
        /// </summary>
        /// <param name="httpResponse">The HTTP response.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="fileName">Name of the file.</param>
		public static void AttachFileHeader(this HttpResponse httpResponse, string contentType, string fileName)
		{
			if (httpResponse == null)
				throw new ArgumentNullException("httpResponse");
			httpResponse.ContentType = contentType;
			httpResponse.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
		}
	}
}