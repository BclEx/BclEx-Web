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
using System;
using System.Linq;
using System.Collections;
using System.Reflection;
using System.Web.UI;
using System.IO;
using System.Text;
namespace System.Web.Mvc
{
    /// <summary>
    /// ResourceFileStreamResult
    /// </summary>
    public class ResourceFileStreamResult : FileResult
    {
        private const int _bufferSize = 0x1000;
        private static readonly IDictionary _cache = Hashtable.Synchronized(new Hashtable());
        private static readonly PropertyInfo _contentTypeProperty = typeof(FileResult).GetProperty("ContentType", BindingFlags.NonPublic | BindingFlags.Instance);
        //private static readonly Regex _webResourceRegex = new WebResourceRegex();

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceFileStreamResult"/> class.
        /// </summary>
        /// <param name="resourceType">Type of the resource.</param>
        /// <param name="resourceID">The resource ID.</param>
        public ResourceFileStreamResult(Type resourceType, string resourceID)
            : base("plain/text")
        {
            if (resourceType == null)
                throw new ArgumentNullException("resourceType");
            ResourceType = resourceType;
            ResourceID = resourceID;
            string contentType;
            bool performSubstitution;
            FileStream = GetStream(resourceType.Assembly, resourceID, out contentType, out performSubstitution);
            SetContentType(contentType);
            PerformSubstitution = performSubstitution;
        }

        private void SetContentType(string contentType)
        {
            _contentTypeProperty.SetValue(this, contentType, null);
        }

        private Stream GetStream(Assembly assembly, string webResource, out string contentType, out bool performSubstitution)
        {
            int cacheID = HashCodeCombiner.CombineHashCodes(assembly.GetHashCode(), webResource.GetHashCode());
            var triplet = (Triplet)_cache[cacheID];
            if (triplet == null)
            {
                var attribute = assembly.GetCustomAttributes(false).OfType<WebResourceAttribute>().Where(x => x.WebResource == webResource).FirstOrDefault();
                triplet = (attribute != null ? new Triplet { First = true, Second = attribute.ContentType, Third = attribute.PerformSubstitution } : new Triplet { First = false });
                _cache[cacheID] = triplet;
            }
            if (!(bool)triplet.First)
                throw new HttpException(0x194, "AssemblyResourceLoader_InvalidRequest");
            contentType = (string)triplet.Second;
            performSubstitution = (bool)triplet.Third;
            return assembly.GetManifestResourceStream(webResource);
        }

        /// <summary>
        /// Writes the file to the response.
        /// </summary>
        /// <param name="response">The response.</param>
        protected override void WriteFile(HttpResponseBase response)
        {
            var outputStream = response.OutputStream;
            using (FileStream)
            {
                var b = new byte[0x1000];
                while (true)
                {
                    var count = FileStream.Read(b, 0, 0x1000);
                    if (count == 0)
                        return;
                    outputStream.Write(b, 0, count);
                }
            }
        }

        //protected void WriteFileWithReplace(HttpResponseBase response)
        //{
        //    string fileStreamAsText;
        //    Encoding fileStreamEncoding;
        //    using (var r = new StreamReader(FileStream, true))
        //    {
        //        fileStreamAsText = r.ReadToEnd();
        //        fileStreamEncoding = r.CurrentEncoding;
        //    }
        //    int startIndex = 0;
        //    var webResource = ResourceID;
        //    var assembly = ResourceType.Assembly;
        //    var b = new StringBuilder();
        //    foreach (Match match in _webResourceRegex.Matches(fileStreamAsText))
        //    {
        //        b.Append(fileStreamAsText.Substring(startIndex, match.Index - startIndex));
        //        var group = match.Groups["resourceName"];
        //        if (group != null)
        //        {
        //            string a = group.ToString();
        //            if (a.Length > 0)
        //            {
        //                if (string.Equals(a, webResource, StringComparison.Ordinal))
        //                    throw new HttpException(0x194, "AssemblyResourceLoader_NoCircularReferences");
        //                b.Append(GetWebResourceUrlInternal(assembly, a, false));
        //            }
        //        }
        //        startIndex = match.Index + match.Length;
        //    }
        //    b.Append(fileStreamAsText.Substring(startIndex, fileStreamAsText.Length - startIndex));
        //    using (var w = new StreamWriter(response.OutputStream, fileStreamEncoding))
        //        w.Write(b.ToString());
        //}

        //private char[] GetWebResourceUrlInternal(Assembly assembly, string a, bool p)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// Gets the type of the resource.
        /// </summary>
        /// <value>
        /// The type of the resource.
        /// </value>
        public Type ResourceType { get; private set; }
        /// <summary>
        /// Gets the resource ID.
        /// </summary>
        public string ResourceID { get; private set; }
        /// <summary>
        /// Gets the file stream.
        /// </summary>
        public Stream FileStream { get; private set; }
        /// <summary>
        /// Gets a value indicating whether [perform substitution].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [perform substitution]; otherwise, <c>false</c>.
        /// </value>
        public bool PerformSubstitution { get; private set; }
    }
}