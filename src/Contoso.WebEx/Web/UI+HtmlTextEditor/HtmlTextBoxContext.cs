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
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI;
using Contoso.Web.UI.Configuration;
namespace Contoso.Web.UI
{
    /// <summary>
    /// HtmlTextBoxContext
    /// </summary>
    public class HtmlTextBoxContext : IHtmlTextBoxContext, ICloneable
    {
        #region Primitives

        /// <summary>
        /// 
        /// </summary>
        public class Primitives
        {
            /// <summary>
            /// DesignModeCssUri
            /// </summary>
            public static readonly string DesignModeCssUri = "/App_/ROOT/PageFrame/HtmlTextEditorStyleSheet.css";
            /// <summary>
            /// DesignModeBodyTagCssClass
            /// </summary>
            public static readonly string DesignModeBodyTagCssClass = "contentPane";
            /// <summary>
            /// Fonts
            /// </summary>
            public static readonly Dictionary<string, string> Fonts = new Dictionary<string, string>();
            /// <summary>
            /// ElementStyles
            /// </summary>
            public static readonly Dictionary<string, string> ElementStyles = new Dictionary<string, string>();
            /// <summary>
            /// BodyCssStyles
            /// </summary>
            public static readonly Dictionary<string, string> BodyCssStyles = new Dictionary<string, string>();
            /// <summary>
            /// AnchorCssStyles
            /// </summary>
            public static readonly Dictionary<string, string> AnchorCssStyles = new Dictionary<string, string>();
            /// <summary>
            /// TableCssStyles
            /// </summary>
            public static readonly Dictionary<string, string> TableCssStyles = new Dictionary<string, string>();
            /// <summary>
            /// ImageCssStyles
            /// </summary>
            public static readonly Dictionary<string, string> ImageCssStyles = new Dictionary<string, string>();
            /// <summary>
            /// Plugins
            /// </summary>
            public static readonly Dictionary<string, string> Plugins = new Dictionary<string, string>();
            /// <summary>
            /// ToolbarCommands
            /// </summary>
            public static readonly HtmlTextBoxCommands ToolbarCommands = HtmlTextBoxCommands.Format | HtmlTextBoxCommands.Align | HtmlTextBoxCommands.Insert | HtmlTextBoxCommands.Table | HtmlTextBoxCommands.Bullet | HtmlTextBoxCommands.ElementStyle | HtmlTextBoxCommands.Indent;
            /// <summary>
            /// ToolbarBreakOn
            /// </summary>
            public static readonly HtmlTextBoxCommands ToolbarBreakOn = HtmlTextBoxCommands.None;
            /// <summary>
            /// Context
            /// </summary>
            public static readonly HtmlTextBoxContext Context = new HtmlTextBoxContext
            {
                DesignModeCssUri = DesignModeCssUri,
                DesignModeBodyTagCssClass = DesignModeBodyTagCssClass,
                Fonts = Fonts,
                ToolbarCommands = ToolbarCommands,
                ToolbarBreakOn = ToolbarBreakOn,
                ElementStyles = ElementStyles,
                BodyCssStyles = BodyCssStyles,
                AnchorCssStyles = AnchorCssStyles,
                TableCssStyles = TableCssStyles,
                ImageCssStyles = ImageCssStyles,
                Plugins = Plugins,
            };

            static Primitives()
            {
                Fonts.Add("Times New Roman", "times new roman,times,serif");
                Fonts.Add("Trebuchet MS", "trebuchet ms,geneva, sans-serif");
                Fonts.Add("Arial", "arial, sans-serif");
                Fonts.Add("Verdana", "verdana,geneva, sans-serif");
                //
                ElementStyles.Add("Normal", "p");
                ElementStyles.Add("Heading 1", "h1");
                ElementStyles.Add("Heading 2", "h2");
                ElementStyles.Add("Heading 3", "h3");
                ElementStyles.Add("Heading 4", "h4");
                //
                BodyCssStyles.Add("Class 1", "class1");
                BodyCssStyles.Add("Class 2", "class2");
                BodyCssStyles.Add("Class 3", "class3");
                BodyCssStyles.Add("Class 4", "class4");
            }
        }

        #endregion

        /// <summary>
        /// Gets the anchor CSS styles.
        /// </summary>
        public Dictionary<string, string> AnchorCssStyles { get; private set; }
        /// <summary>
        /// Gets the body CSS styles.
        /// </summary>
        public Dictionary<string, string> BodyCssStyles { get; private set; }
        /// <summary>
        /// Gets or sets a value indicating whether [in debug mode].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [in debug mode]; otherwise, <c>false</c>.
        /// </value>
        public bool InDebugMode { get; set; }
        /// <summary>
        /// Gets or sets the design mode body tag CSS class.
        /// </summary>
        /// <value>
        /// The design mode body tag CSS class.
        /// </value>
        public string DesignModeBodyTagCssClass { get; set; }
        /// <summary>
        /// Gets or sets the design mode CSS URI.
        /// </summary>
        /// <value>
        /// The design mode CSS URI.
        /// </value>
        public string DesignModeCssUri { get; set; }
        /// <summary>
        /// Gets the element styles.
        /// </summary>
        public Dictionary<string, string> ElementStyles { get; private set; }
        /// <summary>
        /// Gets or sets the element CSS URI.
        /// </summary>
        /// <value>
        /// The element CSS URI.
        /// </value>
        public string ElementCssUri { get; set; }
        /// <summary>
        /// Gets the fonts.
        /// </summary>
        public Dictionary<string, string> Fonts { get; private set; }
        /// <summary>
        /// Gets the image CSS styles.
        /// </summary>
        public Dictionary<string, string> ImageCssStyles { get; private set; }
        /// <summary>
        /// Gets or sets the resource folder.
        /// </summary>
        /// <value>
        /// The resource folder.
        /// </value>
        public string ResourceFolder { get; set; }
        /// <summary>
        /// Gets the plugins.
        /// </summary>
        public Dictionary<string, string> Plugins { get; private set; }
        /// <summary>
        /// Gets the table CSS styles.
        /// </summary>
        public Dictionary<string, string> TableCssStyles { get; private set; }
        /// <summary>
        /// Gets or sets the toolbar break on.
        /// </summary>
        /// <value>
        /// The toolbar break on.
        /// </value>
        public HtmlTextBoxCommands ToolbarBreakOn { get; set; }
        /// <summary>
        /// Gets or sets the toolbar commands.
        /// </summary>
        /// <value>
        /// The toolbar commands.
        /// </value>
        public HtmlTextBoxCommands ToolbarCommands { get; set; }

        /// <summary>
        /// Creates the specified configuration set.
        /// </summary>
        /// <param name="configurationSet">The configuration set.</param>
        /// <param name="id">The id.</param>
        /// <param name="toolbarId">The toolbar id.</param>
        /// <param name="resourceFolder">The resource folder.</param>
        /// <returns></returns>
        public static HtmlTextBoxContext Create(HtmlTextBoxConfigurationCollection configurationSet, string id, string toolbarId, string resourceFolder)
        {
            if (string.IsNullOrEmpty(resourceFolder))
                resourceFolder = "/App_/Resource_/TinyMce";
            HtmlTextBoxContext context;
            HtmlTextBoxConfiguration configuration;
            if (configurationSet == null || !configurationSet.TryGetValue(id, out configuration))
            {
                context = (HtmlTextBoxContext)Primitives.Context.Clone();
                context.ResourceFolder = resourceFolder;
                return context;
            }
            context = new HtmlTextBoxContext { ResourceFolder = resourceFolder };
            context.DesignModeCssUri = configuration.DesignModeCssUri;
            context.DesignModeBodyTagCssClass = configuration.DesignModeBodyTagCssClass;
            // fonts
            if (configuration.Fonts.Count > 0)
                context.Fonts = configuration.Fonts
                    .Cast<HtmlTextBoxFontElement>()
                    .ToDictionary(k => k.Name, e => e.Value);
            else
                context.Fonts = new Dictionary<string, string>(Primitives.Fonts);
            // toolbar
            if (!string.IsNullOrEmpty(toolbarId))
            {
                HtmlTextBoxToolbarElement toolbarConfiguration;
                if (!configuration.Toolbars.TryGetValue(toolbarId, out toolbarConfiguration))
                {
                    context.ToolbarCommands = toolbarConfiguration.Commands;
                    context.ToolbarBreakOn = toolbarConfiguration.BreakOn;
                }
                else
                    throw new ArgumentException(string.Format("Local.UndefinedHtmlTextBoxToolbar", toolbarId), "toolbarId");
            }
            else
            {
                context.ToolbarCommands = configuration.ToolbarCommands;
                context.ToolbarBreakOn = configuration.ToolbarBreakOn;
            }
            // elementStyles
            context.ElementCssUri = ((HtmlTextBoxElementStyleElementCollection)configuration.ElementStyles).CssUri;
            if (configuration.ElementStyles.Count > 0)
                context.ElementStyles = configuration.ElementStyles
                    .Cast<HtmlTextBoxElementStyleElement>()
                    .ToDictionary(k => k.Name, e => (string.IsNullOrEmpty(e.CssClass) ? e.Value : string.Format("{0};{1}", e.Value, e.CssClass)));
            else
                context.ElementStyles = new Dictionary<string, string>(Primitives.ElementStyles);
            // cssStyle
            var bodyCssStyles = context.BodyCssStyles = new Dictionary<string, string>();
            var anchorCssStyles = context.AnchorCssStyles = new Dictionary<string, string>();
            var tableCssStyles = context.TableCssStyles = new Dictionary<string, string>();
            var imageCssStyles = context.ImageCssStyles = new Dictionary<string, string>();
            if (configuration.CssStyles.Count > 0)
                configuration.CssStyles
                    .Cast<HtmlTextBoxCssStyleElement>()
                    .SelectMany(c => c.Element.ToLowerInvariant().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries), (e, k) => new { Element = k, Name = e.Name, Value = e.Value })
                    .ToList()
                    .ForEach(e =>
                    {
                        switch (e.Element)
                        {
                            case "body":
                                bodyCssStyles[e.Name] = e.Value;
                                break;
                            case "anchor":
                                anchorCssStyles[e.Name] = e.Value;
                                break;
                            case "table":
                                tableCssStyles[e.Name] = e.Value;
                                break;
                            case "image":
                                imageCssStyles[e.Name] = e.Value;
                                break;
                        }
                    });
            else
                bodyCssStyles.Insert(Primitives.BodyCssStyles);
            // plugins
            if (configuration.Plugins.Count > 0)
                context.Plugins = configuration.Plugins
                    .Cast<HtmlTextBoxPluginConfiguration>()
                    .ToDictionary(k => k.Name, e => e.Path);
            else
                context.Plugins = new Dictionary<string, string>(Primitives.Plugins);
            return context;
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            var context = (HtmlTextBoxContext)MemberwiseClone();
            context.Fonts = new Dictionary<string, string>(context.Fonts);
            context.ElementStyles = new Dictionary<string, string>(context.ElementStyles);
            context.BodyCssStyles = new Dictionary<string, string>(context.BodyCssStyles);
            context.AnchorCssStyles = new Dictionary<string, string>(context.AnchorCssStyles);
            context.TableCssStyles = new Dictionary<string, string>(context.TableCssStyles);
            context.ImageCssStyles = new Dictionary<string, string>(context.ImageCssStyles);
            context.Plugins = new Dictionary<string, string>(context.Plugins);
            return context;
        }
    }
}
