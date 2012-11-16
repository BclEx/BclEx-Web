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
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
[assembly: WebResource("Contoso.Resource_.SwfObject2.1.js", "text/javascript")]
[assembly: WebResource("Contoso.Resource_.SwfObject2_1.expressInstall.swf", "application/x-Shockwave-Flash")]
namespace Contoso.Web.UI.ClientShapes
{
    /// <summary>
    /// ClientScriptRegistrar
    /// </summary>
    public class ClientScriptRegistrarSwfObjectShape
    {
        private static Type _type = typeof(SwfObjectShape);
        /// <summary>
        /// SwfObjectVersion
        /// </summary>
        public const string SwfObjectVersion = "2.1";

        /// <summary>
        /// Registrations
        /// </summary>
        [Flags]
        public enum Registrations
        {
            /// <summary>
            /// SwfObject
            /// </summary>
            SwfObject = 0x1,
        }

        /// <summary>
        /// Registers the specified manager.
        /// </summary>
        /// <param name="manager">The manager.</param>
        /// <param name="registrations">The registrations.</param>
        /// <param name="attrib">The attrib.</param>
        public static void Register(IClientScriptManager manager, Registrations registrations, Nparams attrib)
        {
            if (manager == null)
                throw new ArgumentNullException("manager");
            if ((registrations & Registrations.SwfObject) == Registrations.SwfObject)
            {
                var version = SwfObjectVersion; // ((attrib != null) && attrib.TryGetValue("swfObjectVersion", out swfObjectVersion) ? swfObjectVersion : SwfObjectVersion);
                if (string.IsNullOrEmpty(version))
                    throw new InvalidOperationException("version");
                var versionFolder = "Contoso.Resource_.SwfObject" + version.Replace(".", "_");
                // STATE
                HttpContext.Current.Set<ClientScriptRegistrarSwfObjectShape>(new ClientScriptRegistrarSwfObjectShape
                {
                    SwfObjectExpressInstallFlashUrl = ClientScriptManagerEx.GetWebResourceUrl(_type, versionFolder + ".expressInstall.swf"),
                });
                // INCLUDES
                manager.EnsureItem<HtmlHead>("SwfObject", () => new IncludeForResourceClientScriptItem(_type, "Contoso.Resource_.SwfObject" + version + ".js"));
            }
        }

        /// <summary>
        /// Gets the SWF object express install flash URL.
        /// </summary>
        public string SwfObjectExpressInstallFlashUrl { get; private set; }

        /// <summary>
        /// Asserts the registered.
        /// </summary>
        /// <returns></returns>
        public static ClientScriptRegistrarSwfObjectShape AssertRegistered()
        {
            var registrar = HttpContext.Current.Get<ClientScriptRegistrarSwfObjectShape>();
            if (registrar == null)
                throw new InvalidOperationException("ClientScriptRegistrarSwfUploadShape.Current must be set first");
            return registrar;
        }
    }
}
