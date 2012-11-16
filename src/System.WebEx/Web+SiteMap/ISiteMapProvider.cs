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
    /// <summary>
    /// ISiteMapProvider
    /// </summary>
    public interface ISiteMapProvider
    {
        /// <summary>
        /// Gets the current node.
        /// </summary>
        SiteMapNode CurrentNode { get; }
        /// <summary>
        /// Gets the root node.
        /// </summary>
        SiteMapNode RootNode { get; }
        /// <summary>
        /// Finds the site map node.
        /// </summary>
        /// <typeparam name="TNode">The type of the node.</typeparam>
        /// <param name="rawUrl">The raw URL.</param>
        /// <returns></returns>
        TNode FindSiteMapNode<TNode>(string rawUrl)
            where TNode : SiteMapNode;
        /// <summary>
        /// Finds the site map node.
        /// </summary>
        /// <typeparam name="TNode">The type of the node.</typeparam>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        TNode FindSiteMapNode<TNode>(HttpContext context)
            where TNode : SiteMapNode;
        /// <summary>
        /// Finds the site map node from key.
        /// </summary>
        /// <typeparam name="TNode">The type of the node.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        TNode FindSiteMapNodeFromKey<TNode>(string key)
            where TNode : SiteMapNode;
        /// <summary>
        /// Gets the child nodes.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        SiteMapNodeCollection GetChildNodes(SiteMapNode node);
        /// <summary>
        /// Gets the parent node.
        /// </summary>
        /// <typeparam name="TNode">The type of the node.</typeparam>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        TNode GetParentNode<TNode>(SiteMapNode node)
            where TNode : SiteMapNode;
        /// <summary>
        /// Clears this instance.
        /// </summary>
        void Clear();
    }
}