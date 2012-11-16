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
        /// Moderns the transfer.
        /// </summary>
        /// <param name="httpServerUtility">The HTTP server utility.</param>
        /// <param name="path">The path.</param>
        public static void ModernTransfer(this HttpServerUtility httpServerUtility, string path)
        {
            if (httpServerUtility == null)
                throw new ArgumentNullException("httpServerUtility");
            if (HttpRuntime.UsingIntegratedPipeline)
                httpServerUtility.TransferRequest(path);
            else
                httpServerUtility.Transfer(path);
        }

        /// <summary>
        /// Moderns the transfer.
        /// </summary>
        /// <param name="httpServerUtility">The HTTP server utility.</param>
        /// <param name="path">The path.</param>
        /// <param name="preserveForm">if set to <c>true</c> [preserve form].</param>
        public static void ModernTransfer(this HttpServerUtility httpServerUtility, string path, bool preserveForm)
        {
            if (httpServerUtility == null)
                throw new ArgumentNullException("httpServerUtility");
            if (HttpRuntime.UsingIntegratedPipeline)
                httpServerUtility.TransferRequest(path, preserveForm);
            else
                httpServerUtility.Transfer(path, preserveForm);
        }

        /// <summary>
        /// Moderns the transfer for URL routing.
        /// </summary>
        /// <param name="httpServerUtility">The HTTP server utility.</param>
        /// <param name="path">The path.</param>
        /// <param name="handlerBuilder">The handler builder.</param>
        public static void ModernTransferForUrlRouting(this HttpServerUtility httpServerUtility, string path, Func<IHttpHandler> handlerBuilder)
        {
            if (httpServerUtility == null)
                throw new ArgumentNullException("httpServerUtility");
            if (HttpRuntime.UsingIntegratedPipeline)
                httpServerUtility.TransferRequest(path);
            else
                HttpContext.Current.TransferForUrlRouting(path, handlerBuilder);
        }
    }
}