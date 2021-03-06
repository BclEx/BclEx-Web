﻿//using System.Collections;
//using System.Collections.Specialized;
//using System.Reflection;
//using System.Web.Caching;
//using System.Security.Permissions;
//namespace System.Web.Hosting
//{
//    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Medium)]
//    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.High)]
//    public class SamplePathProvider : VirtualPathProvider
//    {
//        private string _dataFile;

//        public SamplePathProvider()
//            : base() { }

//        protected override void Initialize()
//        {
//            // Set the datafile path relative to the application's path.
//            _dataFile = HostingEnvironment.ApplicationPhysicalPath + "App_Data\\XMLData.xml";
//        }

//        //public DataSet GetVirtualData()
//        //{
//        //    // Get the data from the cache.
//        //    DataSet ds = (DataSet)HostingEnvironment.Cache.Get("VPPData");
//        //    if (ds == null)
//        //    {
//        //        // Data not in cache. Read XML file.
//        //        ds = new DataSet();
//        //        ds.ReadXml(_dataFile);

//        //        // Make DataSet dependent on XML file.
//        //        CacheDependency cd = new CacheDependency(_dataFile);

//        //        // Put DataSet into cache for maximum of 20 minutes.
//        //        HostingEnvironment.Cache.Add("VPPData", ds, cd, Cache.NoAbsoluteExpiration, new TimeSpan(0, 20, 0), CacheItemPriority.Default, null);

//        //        // Set data timestamp.
//        //        DateTime dataTimeStamp = DateTime.Now;
//        //        // Cache it so we can get the timestamp in later calls.
//        //        HostingEnvironment.Cache.Insert("dataTimeStamp", dataTimeStamp, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 20, 0), CacheItemPriority.Default, null);
//        //    }
//        //    return ds;
//        //}

//        private bool IsPathVirtual(string virtualPath)
//        {
//            String checkPath = VirtualPathUtility.ToAppRelative(virtualPath);
//            return checkPath.StartsWith("~/vrdir", StringComparison.InvariantCultureIgnoreCase);
//        }

//        public override bool FileExists(string virtualPath)
//        {
//            if (IsPathVirtual(virtualPath))
//            {
//                SampleVirtualFile file = (SampleVirtualFile)GetFile(virtualPath);
//                return file.Exists;
//            }
//            else
//                return Previous.FileExists(virtualPath);
//        }

//        public override bool DirectoryExists(string virtualDir)
//        {
//            if (IsPathVirtual(virtualDir))
//            {
//                SampleVirtualDirectory dir = (SampleVirtualDirectory)GetDirectory(virtualDir);
//                return dir.Exists;
//            }
//            else
//                return Previous.DirectoryExists(virtualDir);
//        }

//        public override VirtualFile GetFile(string virtualPath)
//        {
//            if (IsPathVirtual(virtualPath))
//                return new SampleVirtualFile(virtualPath, this);
//            else
//                return Previous.GetFile(virtualPath);
//        }

//        public override VirtualDirectory GetDirectory(string virtualDir)
//        {
//            if (IsPathVirtual(virtualDir))
//                return new SampleVirtualDirectory(virtualDir, this);
//            else
//                return Previous.GetDirectory(virtualDir);
//        }

//        public override CacheDependency GetCacheDependency(string virtualPath, System.Collections.IEnumerable virtualPathDependencies, DateTime utcStart)
//        {
//            if (IsPathVirtual(virtualPath))
//            {
//                System.Collections.Specialized.StringCollection fullPathDependencies = null;

//                // Get the full path to all dependencies.
//                foreach (string virtualDependency in virtualPathDependencies)
//                {
//                    if (fullPathDependencies == null)
//                        fullPathDependencies = new System.Collections.Specialized.StringCollection();

//                    fullPathDependencies.Add(virtualDependency);
//                }
//                if (fullPathDependencies == null)
//                    return null;

//                // Copy the list of full-path dependencies into an array.
//                string[] fullPathDependenciesArray = new string[fullPathDependencies.Count];
//                fullPathDependencies.CopyTo(fullPathDependenciesArray, 0);
//                // Copy the virtual path into an array.
//                string[] virtualPathArray = new string[1];
//                virtualPathArray[0] = virtualPath;

//                return new CacheDependency(virtualPathArray, fullPathDependenciesArray, utcStart);
//            }
//            else
//                return Previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
//        }
//    }
//}


