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
using System.Web.Hosting;
using System.IO;
using System.Reflection;
using System.Web.Compilation;
using System.Linq;
using System.Web.Configuration;
using System.Configuration;
namespace System.Web
{
    /// <summary>
    /// HttpContextEx
    /// </summary>
    public static class HttpContextEx
    {
        /// <summary>
        /// EmptyHtml
        /// </summary>
        public const string EmptyHtml = "\u00A0";
        private static List<Assembly> _assemblies;
        private static object _lock = new object();

        static HttpContextEx()
        {
            LoadFromConfiguration();
        }

        /// <summary>
        /// Gets the is absolute URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public static bool GetIsAbsoluteUrl(string url)
        {
            return (url.IndexOf(":", StringComparison.Ordinal) == -1 || url.StartsWith("http:", StringComparison.OrdinalIgnoreCase) || url.StartsWith("https:", StringComparison.OrdinalIgnoreCase) || url.StartsWith("ftp:", StringComparison.OrdinalIgnoreCase) || url.StartsWith("file:", StringComparison.OrdinalIgnoreCase) || url.StartsWith("news:", StringComparison.OrdinalIgnoreCase));
        }

        private static IEnumerable<string> GetAssemblyFiles()
        {
            var path = (HostingEnvironment.IsHosted ? HttpRuntime.BinDirectory : Path.GetDirectoryName(typeof(HttpContextEx).Assembly.Location));
            return Directory.GetFiles(path, "*.dll");
        }

        /// <summary>
        /// Gets the assemblies.
        /// </summary>
        public static IEnumerable<Assembly> Assemblies
        {
            get
            {
                if (_assemblies == null)
                    lock (_lock)
                        if (_assemblies == null)
                        {
                            var assemblies = new List<Assembly>();
                            if (HostingEnvironment.IsHosted && BuildManager.CodeAssemblies != null)
                                _assemblies.AddRange(BuildManager.CodeAssemblies.OfType<Assembly>());
                            foreach (var c in GetAssemblyFiles())
                                try { assemblies.Add(Assembly.LoadFrom(c)); }
                                catch { }
                            _assemblies = assemblies.Except(IgnoredAssemblies)
                                .ToList();
                        }
                return _assemblies;
            }
        }

        /// <summary>
        /// Gets the ignored assemblies.
        /// </summary>
        public static IEnumerable<Assembly> IgnoredAssemblies { get; private set; }

        private static void LoadFromConfiguration()
        {
            try
            {
                var section = WebExSection.GetSection();
                IgnoredAssemblies = section.IgnoredAssemblies
                    .Cast<ConfigurationElementCollectionEx.AssemblyElement>()
                    .Select(x => x.Assembly)
                    .ToList();
            }
            catch { }
        }
    }
}