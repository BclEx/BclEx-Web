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
namespace System.Web.Mvc
{
    public static partial class MvcExtensions
    {
        /// <summary>
        /// Determines whether the specified model metadata has extent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelMetadata">The model metadata.</param>
        /// <returns>
        ///   <c>true</c> if the specified model metadata has extent; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasExtent<T>(this ModelMetadata modelMetadata)
        {
            if (modelMetadata == null)
                throw new ArgumentNullException("modelMetadata");
            return modelMetadata.AdditionalValues.ContainsKey(typeof(T).ToString());
        }
        /// <summary>
        /// Determines whether the specified model metadata has extent.
        /// </summary>
        /// <param name="modelMetadata">The model metadata.</param>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if the specified model metadata has extent; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasExtent(this ModelMetadata modelMetadata, Type type)
        {
            if (modelMetadata == null)
                throw new ArgumentNullException("modelMetadata");
            return modelMetadata.AdditionalValues.ContainsKey(type.ToString());
        }

        /// <summary>
        /// Clears the specified model metadata.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelMetadata">The model metadata.</param>
        public static void Clear<T>(this ModelMetadata modelMetadata)
        {
            if (modelMetadata == null)
                throw new ArgumentNullException("modelMetadata");
            modelMetadata.AdditionalValues[typeof(T).ToString()] = null;
        }
        /// <summary>
        /// Clears the specified model metadata.
        /// </summary>
        /// <param name="modelMetadata">The model metadata.</param>
        /// <param name="type">The type.</param>
        public static void Clear(this ModelMetadata modelMetadata, Type type)
        {
            if (modelMetadata == null)
                throw new ArgumentNullException("modelMetadata");
            if (type == null)
                throw new ArgumentNullException("type");
            modelMetadata.AdditionalValues[type.ToString()] = null;
        }

        /// <summary>
        /// Gets the specified model metadata.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelMetadata">The model metadata.</param>
        /// <returns></returns>
        public static T Get<T>(this ModelMetadata modelMetadata)
        {
            if (modelMetadata == null)
                throw new ArgumentNullException("modelMetadata");
            return (T)modelMetadata.AdditionalValues[typeof(T).ToString()];
        }
        /// <summary>
        /// Gets the many.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelMetadata">The model metadata.</param>
        /// <returns></returns>
        public static IEnumerable<T> GetMany<T>(this ModelMetadata modelMetadata)
        {
            if (modelMetadata == null)
                throw new ArgumentNullException("modelMetadata");
            return (IEnumerable<T>)modelMetadata.AdditionalValues[typeof(IEnumerable<T>).ToString()];
        }
        /// <summary>
        /// Gets the specified model metadata.
        /// </summary>
        /// <param name="modelMetadata">The model metadata.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static object Get(this ModelMetadata modelMetadata, Type type)
        {
            if (modelMetadata == null)
                throw new ArgumentNullException("modelMetadata");
            if (type == null)
                throw new ArgumentNullException("type");
            return modelMetadata.AdditionalValues[type.ToString()];
        }

        /// <summary>
        /// Sets the specified model metadata.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelMetadata">The model metadata.</param>
        /// <param name="value">The value.</param>
        public static void Set<T>(this ModelMetadata modelMetadata, T value)
        {
            if (modelMetadata == null)
                throw new ArgumentNullException("modelMetadata");
            modelMetadata.AdditionalValues[typeof(T).ToString()] = value;
        }
        /// <summary>
        /// Sets the many.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelMetadata">The model metadata.</param>
        /// <param name="value">The value.</param>
        public static void SetMany<T>(this ModelMetadata modelMetadata, IEnumerable<T> value)
        {
            if (modelMetadata == null)
                throw new ArgumentNullException("modelMetadata");
            modelMetadata.AdditionalValues[typeof(IEnumerable<T>).ToString()] = value;
        }
        /// <summary>
        /// Sets the specified model metadata.
        /// </summary>
        /// <param name="modelMetadata">The model metadata.</param>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        public static void Set(this ModelMetadata modelMetadata, Type type, object value)
        {
            if (modelMetadata == null)
                throw new ArgumentNullException("modelMetadata");
            if (type == null)
                throw new ArgumentNullException("type");
            modelMetadata.AdditionalValues[type.ToString()] = value;
        }

        /// <summary>
        /// Tries the get extent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelMetadata">The model metadata.</param>
        /// <param name="extent">The extent.</param>
        /// <returns></returns>
        public static bool TryGetExtent<T>(this ModelMetadata modelMetadata, out T extent)
        {
            if (modelMetadata == null)
                throw new ArgumentNullException("modelMetadata");
            object value;
            if (!modelMetadata.AdditionalValues.TryGetValue(typeof(T).ToString(), out value))
            {
                extent = default(T);
                return false;
            }
            extent = (T)value;
            return true;
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="modelMetadata">The model metadata.</param>
        /// <param name="extents">The extents.</param>
        public static void AddRange(this ModelMetadata modelMetadata, IEnumerable<object> extents)
        {
            if (modelMetadata == null)
                throw new ArgumentNullException("modelMetadata");
            if (extents == null)
                throw new ArgumentNullException("extents");
            foreach (var extent in extents)
                Set(modelMetadata, extent.GetType(), extent);
        }
    }
}