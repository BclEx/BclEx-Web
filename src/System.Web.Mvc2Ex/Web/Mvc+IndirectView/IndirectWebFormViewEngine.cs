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
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace System.Web.Mvc
{
    /// <summary>
    /// IndirectWebFormViewEngine
    /// </summary>
    public class IndirectWebFormViewEngine : WebFormViewEngine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndirectWebFormViewEngine"/> class.
        /// </summary>
        public IndirectWebFormViewEngine() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="IndirectWebFormViewEngine"/> class.
        /// </summary>
        /// <param name="viewDirectors">The view directors.</param>
        public IndirectWebFormViewEngine(params IndirectViewDirector[] viewDirectors)
        {
            ViewDirectors = viewDirectors;
        }

        /// <summary>
        /// Finds the specified view by using the specified controller context and master view name.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="viewName">The name of the view.</param>
        /// <param name="masterName">The name of the master view.</param>
        /// <param name="useCache">true to use the cached view.</param>
        /// <returns>
        /// The page view.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="controllerContext"/> parameter is null (Nothing in Visual Basic).</exception>
        ///   
        /// <exception cref="T:System.ArgumentException">The <paramref name="viewName"/> parameter is null or empty.</exception>
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            if (!EnumerableEx.IsNullOrEmpty(ViewDirectors))
                foreach (var viewDirector in ViewDirectors.Where(x => x.CanIndirect(controllerContext)))
                {
                    var result = base.FindView(controllerContext, (viewDirector.ViewNameBuilder != null ? viewDirector.ViewNameBuilder(controllerContext, viewName) : viewName), (viewDirector.MasterNameBuilder != null ? viewDirector.ViewNameBuilder(controllerContext, masterName) : masterName), useCache);
                    if ((result != null) && (result.View != null))
                        return result;
                }
            return base.FindView(controllerContext, viewName, masterName, useCache);
        }

        /// <summary>
        /// Finds the specified partial view by using the specified controller context.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="partialViewName">The name of the partial view.</param>
        /// <param name="useCache">true to use the cached partial view.</param>
        /// <returns>
        /// The partial view.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="controllerContext"/> parameter is null (Nothing in Visual Basic).</exception>
        ///   
        /// <exception cref="T:System.ArgumentException">The <paramref name="partialViewName"/> parameter is null or empty.</exception>
        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            if (!EnumerableEx.IsNullOrEmpty(ViewDirectors))
                foreach (var director in ViewDirectors.Where(x => x.CanIndirect(controllerContext)))
                {
                    var result = base.FindPartialView(controllerContext, (director.PartialViewNameBuilder != null ? director.PartialViewNameBuilder(controllerContext, partialViewName) : partialViewName), useCache);
                    if (result != null && result.View != null)
                        return result;
                }
            return base.FindPartialView(controllerContext, partialViewName, useCache);
        }

        /// <summary>
        /// Gets or sets the view directors.
        /// </summary>
        /// <value>
        /// The view directors.
        /// </value>
        public IEnumerable<IndirectViewDirector> ViewDirectors { get; set; }
    }
}