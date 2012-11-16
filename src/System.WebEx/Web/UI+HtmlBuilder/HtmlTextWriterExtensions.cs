namespace System.Web.UI
{
    /// <summary>
    /// HtmlTextWriterExtensions
    /// </summary>
    public static class HtmlTextWriterExtensions
    {
        /// <summary>
        /// Gets the HTML builder.
        /// </summary>
        /// <param name="w">The w.</param>
        /// <returns></returns>
        public static HtmlBuilder GetHtmlBuilder(this HtmlTextWriter w)
        {
            var wEx = (w as HtmlTextWriterEx);
            if (wEx == null)
                throw new Exception("not left HtmlTextWriterEx");
            return wEx.HtmlBuilder;
        }
    }
}
