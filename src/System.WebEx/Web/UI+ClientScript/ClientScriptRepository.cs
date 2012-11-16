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
namespace System.Web.UI
{
    /// <summary>
    /// IClientScriptRepository
    /// </summary>
    public interface IClientScriptRepository
    {
        /// <summary>
        /// Gets the includes.
        /// </summary>
        Dictionary<string, ClientScriptItemBase> Includes { get; }
        /// <summary>
        /// Gets the items.
        /// </summary>
        Dictionary<string, ClientScriptItemBase> Items { get; }
        /// <summary>
        /// Ensures the item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="item">The item.</param>
        void EnsureItem(string id, Func<ClientScriptItemBase> item);
        /// <summary>
        /// Inserts the item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="item">The item.</param>
        void InsertItem(string id, ClientScriptItemBase item);
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="item">The item.</param>
        void AddRange(ClientScriptItemBase item);
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="literal">The literal.</param>
        void AddRange(string literal);
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="items">The items.</param>
        void AddRange(params object[] items);
    }

    /// <summary>
    /// ClientScriptRepository
    /// </summary>
    public class ClientScriptRepository : IClientScriptRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientScriptRepository"/> class.
        /// </summary>
        public ClientScriptRepository()
        {
            Includes = new Dictionary<string, ClientScriptItemBase>();
            Items = new Dictionary<string, ClientScriptItemBase>();
        }

        /// <summary>
        /// Gets the includes.
        /// </summary>
        public Dictionary<string, ClientScriptItemBase> Includes { get; private set; }
        /// <summary>
        /// Gets the items.
        /// </summary>
        public Dictionary<string, ClientScriptItemBase> Items { get; private set; }

        /// <summary>
        /// Ensures the item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="item">The item.</param>
        public void EnsureItem(string id, Func<ClientScriptItemBase> item)
        {
            if (!Items.ContainsKey(id) && !Includes.ContainsKey(id))
                InsertItem(id, item());
        }

        /// <summary>
        /// Inserts the item.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="item">The item.</param>
        public void InsertItem(string id, ClientScriptItemBase item)
        {
            var itemAsInclude = (item as IncludeClientScriptItem);
            if (itemAsInclude == null)
                Items[id] = item;
            else
                Includes[id] = itemAsInclude;
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddRange(ClientScriptItemBase item)
        {
            var itemAsInclude = (item as IncludeClientScriptItem);
            if (itemAsInclude == null)
                Items[Items.Count.ToString()] = item;
            else
                Includes[Includes.Count.ToString()] = itemAsInclude;
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="literal">The literal.</param>
        public void AddRange(string literal)
        {
            Items[Items.Count.ToString()] = new LiteralClientScriptItem(literal);
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="items">The items.</param>
        public void AddRange(params object[] items)
        {
            foreach (object item in items)
            {
                if (item == null)
                    continue;
                var itemAsString = (item as string);
                if (itemAsString != null)
                {
                    Items[Items.Count.ToString()] = new LiteralClientScriptItem(itemAsString);
                    continue;
                }
                var itemAsInclude = (item as IncludeClientScriptItem);
                if (itemAsInclude != null)
                {
                    Includes[Items.Count.ToString()] = itemAsInclude;
                    continue;
                }
                var itemAsItem = (item as ClientScriptItemBase);
                if (itemAsItem != null)
                {
                    Items[Items.Count.ToString()] = itemAsItem;
                    continue;
                }
                throw new InvalidOperationException();
            }
        }
    }
}
