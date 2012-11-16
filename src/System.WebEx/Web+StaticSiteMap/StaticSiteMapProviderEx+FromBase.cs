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
using System.Reflection;
using System.Collections;
namespace System.Web
{
    public partial class StaticSiteMapProviderEx
    {
        /// <summary>
        /// Rebases the nodes recurse.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="rebaseUrl">The rebase URL.</param>
        public void RebaseNodesRecurse(SiteMapNode node, string rebaseUrl)
        {
            var nodeUrl = node.Url;
            var newNodeUrl = rebaseUrl + nodeUrl;
            node.Url = newNodeUrl;
            _providerUrlTable.Remove(nodeUrl);
            _providerUrlTable.Add(newNodeUrl, node);
            // duplicate root node
            if (nodeUrl == "/")
                _providerUrlTable.Add(rebaseUrl, node);
            if (node.HasChildNodes)
                foreach (SiteMapNode childNode in node.ChildNodes)
                    RebaseNodesRecurse(childNode, rebaseUrl);
        }

        /// <summary>
        /// Finds the site map node from key ex.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="searchBase">if set to <c>true</c> [search base].</param>
        /// <returns></returns>
        public virtual SiteMapNode FindSiteMapNodeFromKeyEx(string key, bool searchBase)
        {
            SiteMapNode node;
            if (!searchBase)
            {
                BuildSiteMap();
                node = (SiteMapNode)_providerKeyTable[key];
            }
            else
            {
                node = base.FindSiteMapNodeFromKey(key);
                if (node == null)
                    node = (SiteMapNode)_providerKeyTable[key];
            }
            return ReturnNodeIfAccessibleEx(node);
        }

        /// <summary>
        /// Returns the node if accessible ex.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        protected SiteMapNode ReturnNodeIfAccessibleEx(SiteMapNode node)
        {
            var ctx = HttpContext.Current;
            return (ctx != null && node != null && node.IsAccessibleToUser(ctx) ? node : null);
        }
    }
}