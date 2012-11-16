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
#if !CLR4
using System.Collections.Specialized;
using System.Collections;
namespace System.Web
{
    /// <summary>
    /// HttpContextBase
    /// </summary>
    //[TypeForwardedFrom("System.Web.Abstractions, Version=3.5.0.0, Culture=Neutral, PublicKeyToken=31bf3856ad364e35")]
    public abstract class HttpApplicationStateBase : NameObjectCollectionBase, ICollection, IEnumerable
    {
        //[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        protected HttpApplicationStateBase() { }
        public virtual void Add(string name, object value) { throw new NotImplementedException(); }
        public virtual void Clear() { throw new NotImplementedException(); }
        public virtual void CopyTo(Array array, int index) { throw new NotImplementedException(); }
        public virtual object Get(int index) { throw new NotImplementedException(); }
        public virtual object Get(string name) { throw new NotImplementedException(); }
        public override IEnumerator GetEnumerator() { throw new NotImplementedException(); }
        public virtual string GetKey(int index) { throw new NotImplementedException(); }
        public virtual void Lock() { throw new NotImplementedException(); }
        public virtual void Remove(string name) { throw new NotImplementedException(); }
        public virtual void RemoveAll() { throw new NotImplementedException(); }
        public virtual void RemoveAt(int index) { throw new NotImplementedException(); }
        public virtual void Set(string name, object value) { throw new NotImplementedException(); }
        public virtual void UnLock() { throw new NotImplementedException(); }
        public virtual string[] AllKeys
        {
            get { throw new NotImplementedException(); }
        }
        public virtual HttpApplicationStateBase Contents
        {
            get { throw new NotImplementedException(); }
        }
        public override int Count
        {
            get { throw new NotImplementedException(); }
        }
        public virtual bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }
        public virtual object this[string name]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public virtual object this[int index]
        {
            get { throw new NotImplementedException(); }
        }
        public virtual HttpStaticObjectsCollectionBase StaticObjects
        {
            get { throw new NotImplementedException(); }
        }
        public virtual object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }
    }
}
#endif