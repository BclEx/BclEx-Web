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
namespace System.Web.Mvc
{
    /// <summary>
    /// ObservableResult
    /// </summary>
    public abstract class ObservableResult<T> : ActionResult, IObservable<T>
    {
        private Func<HttpResponseBase, IObserver<T>> _observer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObservableResult&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public ObservableResult(Func<HttpResponseBase, IObserver<T>> observer)
        {
            _observer = observer;
        }

        /// <summary>
        /// Subscribes the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <returns></returns>
        public abstract IDisposable Subscribe(IObserver<T> observer);

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult"/> class.
        /// </summary>
        /// <param name="context">The context in which the result is executed. The context information includes the controller, HTTP content, request context, and route data.</param>
        public override void ExecuteResult(ControllerContext context)
        {
            var r = context.HttpContext.Response;
            r.Clear();
            r.Cache.SetCacheability(HttpCacheability.NoCache);
            if (!string.IsNullOrEmpty(ContentType))
                r.ContentType = ContentType;
            Subscribe(_observer(r));
        }

        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>
        /// The type of the content.
        /// </value>
        public string ContentType { get; set; }
    }
}
