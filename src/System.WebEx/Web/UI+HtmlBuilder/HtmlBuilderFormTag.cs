using System.Patterns.UI.Forms;
namespace System.Web.UI
{
    /// <summary>
    /// HtmlBuilderFormTag
    /// </summary>
    public class HtmlBuilderFormTag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlBuilderFormTag"/> class.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="formContext">The form context.</param>
        /// <param name="args">The args.</param>
        public HtmlBuilderFormTag(HtmlBuilder b, IFormContext formContext, Nparams args) { }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public object Tag { get; set; }
    }
}