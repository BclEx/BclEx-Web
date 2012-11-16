//using System.Collections;
//using System.Collections.Specialized;
//using System.Reflection;
//using System.Web.Caching;
//namespace System.Web.Hosting
//{
//    public class EmbeddedResourcePathProvider : VirtualPathProvider
//    {
//        private const string ApplicationRootPath = "~/";
//        public const string ConfigSectionName = "embeddedFileAssemblies";
//        public const string ConfigKeyAllowOverrides = "Paraesthesia.Web.Hosting.EmbeddedResourcePathProvider.AllowOverrides";
//        private VirtualFileBaseCollection _files = new VirtualFileBaseCollection();

//        //public virtual bool AllowOverrides
//        //{
//        //    get
//        //    {
//        //        string toParse = System.Configuration.ConfigurationManager.AppSettings[ConfigKeyAllowOverrides];
//        //        if (String.IsNullOrEmpty(toParse))
//        //        {
//        //            return false;
//        //        }
//        //        bool retVal;
//        //        bool.TryParse(toParse, out retVal);
//        //        return retVal;
//        //    }
//        //}

//        //public virtual VirtualFileBaseCollection Files
//        //{
//        //    get { return _files; }
//        //}

//        public EmbeddedResourcePathProvider() : base() { }

//        public override bool FileExists(string virtualPath)
//        {
//            if (virtualPath == null)
//                throw new ArgumentNullException("virtualPath");
//            string absolutePath = VirtualPathUtility.ToAbsolute(virtualPath);
//            if (this.Files.Contains(absolutePath))
//            {
//                return true;
//            }
//            return base.FileExists(absolutePath);
//        }

//        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
//        {
//            if (virtualPath == null)
//                throw new ArgumentNullException("virtualPath");
//            string absolutePath = VirtualPathUtility.ToAbsolute(virtualPath);

//            // Lazy initialize the return value so we can return null if needed
//            AggregateCacheDependency retVal = null;

//            // Handle chained dependencies
//            if (virtualPathDependencies != null)
//            {
//                foreach (string virtualPathDependency in virtualPathDependencies)
//                {
//                    CacheDependency dependencyToAdd = this.GetCacheDependency(virtualPathDependency, null, utcStart);
//                    if (dependencyToAdd == null)
//                    {
//                        // Ignore items that have no dependency
//                        continue;
//                    }

//                    if (retVal == null)
//                    {
//                        retVal = new AggregateCacheDependency();
//                    }
//                    retVal.Add(dependencyToAdd);
//                }
//            }

//            // Handle the primary file
//            CacheDependency primaryDependency = null;
//            if (this.FileHandledByBaseProvider(absolutePath))
//            {
//                primaryDependency = base.GetCacheDependency(absolutePath, null, utcStart);
//            }
//            else
//            {
//                primaryDependency = new CacheDependency(((EmbeddedResourceVirtualFile)this.Files[absolutePath]).ContainingAssembly.Location, utcStart);
//            }

//            if (primaryDependency != null)
//            {
//                if (retVal == null)
//                {
//                    retVal = new AggregateCacheDependency();
//                }
//                retVal.Add(primaryDependency);
//            }

//            return retVal;
//        }

//        public override VirtualFile GetFile(string virtualPath)
//        {
//            // virtualPath comes in absolute form: /MyApplication/Subfolder/OtherFolder/Control.ascx
//            // * ToAppRelative: ~/Subfolder/OtherFolder/Control.ascx
//            // * ToAbsolute: /MyApplication/Subfolder/OtherFolder/Control.ascx
//            if (virtualPath == null)
//                throw new ArgumentNullException("virtualPath");
//            string absolutePath = System.Web.VirtualPathUtility.ToAbsolute(virtualPath);
//            if (this.FileHandledByBaseProvider(absolutePath))
//            {
//                return base.GetFile(absolutePath);
//            }
//            else
//            {
//                return (VirtualFile)this.Files[absolutePath];
//            }
//        }

//        protected override void Initialize()
//        {
//            StringCollection configuredAssemblyNames = GetConfiguredAssemblyNames();
//            if (configuredAssemblyNames.Count != 0)
//            {
//                foreach (string configuredAssemblyName in configuredAssemblyNames)
//                {
//                    this.ProcessEmbeddedFiles(configuredAssemblyName);
//                }
//            }
//            base.Initialize();
//        }

//        protected static StringCollection GetConfiguredAssemblyNames()
//        {
//            StringCollection retVal = System.Configuration.ConfigurationManager.GetSection(ConfigSectionName) as StringCollection;
//            return retVal ?? new StringCollection();
//        }

//        protected static string MapResourceToWebApplication(string baseNamespace, string resourcePath)
//        {
//            // Validate parameters
//            ValidateResourcePath("baseNamespace", baseNamespace);
//            ValidateResourcePath("resourcePath", resourcePath);

//            // Ensure that the base namespace (with the period delimiter) appear in the resource path
//            if (resourcePath.IndexOf(baseNamespace + ".") != 0)
//            {
//                throw new InvalidOperationException("Base resource namespace must appear at the start of the embedded resource path.");
//            }

//            // Remove the base namespace from the resource path
//            string newResourcePath = resourcePath.Remove(0, baseNamespace.Length + 1);

//            // Find the last period - that's the file extension
//            int extSeparator = newResourcePath.LastIndexOf(".");

//            // Replace all but the last period with a directory separator
//            string resourceFilePath = newResourcePath.Substring(0, extSeparator).Replace(".", "/") + newResourcePath.Substring(extSeparator, newResourcePath.Length - extSeparator);

//            // Map the path into the web app and return
//            string retVal = System.Web.VirtualPathUtility.Combine("~/", resourceFilePath);
//            return retVal;
//        }

//        private static void ValidateResourcePath(string paramName, string path)
//        {
//            if (path == null)
//            {
//                throw new ArgumentNullException("paramName");
//            }
//            if (path.Length == 0)
//            {
//                throw new ArgumentOutOfRangeException("paramName");
//            }
//            if (path.StartsWith(".") || path.EndsWith("."))
//            {
//                throw new ArgumentOutOfRangeException(paramName, path, paramName + " may not start or end with a period.");
//            }
//            if (path.IndexOf("..") >= 0)
//            {
//                throw new ArgumentOutOfRangeException(paramName, path, paramName + " may not contain two or more periods together.");
//            }
//        }

//        private bool FileHandledByBaseProvider(string absolutePath)
//        {
//            return (this.AllowOverrides && base.FileExists(absolutePath)) ||
//                            !this.Files.Contains(absolutePath);
//        }

//        protected virtual void ProcessEmbeddedFiles(string assemblyName)
//        {
//            if (assemblyName == null)
//            {
//                throw new ArgumentNullException("assemblyName");
//            }
//            if (assemblyName.Length == 0)
//            {
//                throw new ArgumentOutOfRangeException("assemblyName");
//            }

//            Assembly assembly = Assembly.Load(assemblyName);

//            // Get the embedded files specified in the assembly; bail early if there aren't any.
//            EmbeddedResourceFileAttribute[] attribs = (EmbeddedResourceFileAttribute[])assembly.GetCustomAttributes(typeof(EmbeddedResourceFileAttribute), true);
//            if (attribs.Length == 0)
//            {
//                return;
//            }

//            // Get the complete set of embedded resource names in the assembly; bail early if there aren't any.
//            System.Collections.Generic.List<String> assemblyResourceNames = new System.Collections.Generic.List<string>(assembly.GetManifestResourceNames());
//            if (assemblyResourceNames.Count == 0)
//            {
//                return;
//            }

//            foreach (EmbeddedResourceFileAttribute attrib in attribs)
//            {
//                // Ensure the resource specified actually exists in the assembly
//                if (!assemblyResourceNames.Contains(attrib.ResourcePath))
//                {
//                    continue;
//                }

//                // Map the path into the web application
//                string mappedPath;
//                try
//                {
//                    mappedPath = System.Web.VirtualPathUtility.ToAbsolute(MapResourceToWebApplication(attrib.ResourceNamespace, attrib.ResourcePath));
//                }
//                catch (ArgumentNullException)
//                {
//                    continue;
//                }
//                catch (ArgumentOutOfRangeException)
//                {
//                    continue;
//                }

//                // Create the file and ensure it's unique
//                EmbeddedResourceVirtualFile file = new EmbeddedResourceVirtualFile(mappedPath, assembly, attrib.ResourcePath);
//                if (this.Files.Contains(file.VirtualPath))
//                {
//                    continue;
//                }

//                // The file is unique; add it to the filesystem
//                this.Files.Add(file);
//            }
//        }
//    }
//}


