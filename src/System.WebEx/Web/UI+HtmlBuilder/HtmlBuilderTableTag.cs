namespace System.Web.UI
{
    /// <summary>
    /// HtmlBuilderTableTag
    /// </summary>
    public class HtmlBuilderTableTag
    {
        /// <summary>
        /// TableAttrib
        /// </summary>
        public class TableAttrib
        {
            /// <summary>
            /// Gets or sets the column count.
            /// </summary>
            /// <value>
            /// The column count.
            /// </value>
            public int? ColumnCount { get; set; }
            /// <summary>
            /// Gets or sets the null td body.
            /// </summary>
            /// <value>
            /// The null td body.
            /// </value>
            public string NullTdBody { get; set; }
            /// <summary>
            /// Gets or sets the row pitch.
            /// </summary>
            /// <value>
            /// The row pitch.
            /// </value>
            public int? RowPitch { get; set; }
            /// <summary>
            /// Gets or sets the column pitch.
            /// </summary>
            /// <value>
            /// The column pitch.
            /// </value>
            public int? ColumnPitch { get; set; }
            /// <summary>
            /// Gets or sets the selected class.
            /// </summary>
            /// <value>
            /// The selected class.
            /// </value>
            public string SelectedClass { get; set; }
            /// <summary>
            /// Gets or sets the selected style.
            /// </summary>
            /// <value>
            /// The selected style.
            /// </value>
            public string SelectedStyle { get; set; }
            /// <summary>
            /// Gets or sets the alternate class.
            /// </summary>
            /// <value>
            /// The alternate class.
            /// </value>
            public string AlternateClass { get; set; }
            /// <summary>
            /// Gets or sets the alternate style.
            /// </summary>
            /// <value>
            /// The alternate style.
            /// </value>
            public string AlternateStyle { get; set; }
            /// <summary>
            /// Gets or sets the tr close method.
            /// </summary>
            /// <value>
            /// The tr close method.
            /// </value>
            public TableTrCloseMethod? TrCloseMethod { get; set; }
            /// <summary>
            /// Gets or sets the alternate orientation.
            /// </summary>
            /// <value>
            /// The alternate orientation.
            /// </value>
            public TableAlternateOrientation? AlternateOrientation { get; set; }
        }

        /// <summary>
        /// TableStage
        /// </summary>
        public enum TableStage
        {
            /// <summary>
            /// Undefined
            /// </summary>
            Undefined,
            /// <summary>
            /// Colgroup
            /// </summary>
            Colgroup,
            /// <summary>
            /// TheadTfoot
            /// </summary>
            TheadTfoot,
            /// <summary>
            /// Tbody
            /// </summary>
            Tbody,
        }

        /// <summary>
        /// TableTrCloseMethod
        /// </summary>
        public enum TableTrCloseMethod
        {
            /// <summary>
            /// Undefined
            /// </summary>
            Undefined,
            /// <summary>
            /// Td
            /// </summary>
            Td,
            /// <summary>
            /// TdColspan
            /// </summary>
            TdColspan
        }

        /// <summary>
        /// TableAlternateOrientation
        /// </summary>
        public enum TableAlternateOrientation
        {
            /// <summary>
            /// Column
            /// </summary>
            Column,
            /// <summary>
            /// Row
            /// </summary>
            Row
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlBuilderTableTag"/> class.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="attrib">The attrib.</param>
        public HtmlBuilderTableTag(HtmlBuilder b, TableAttrib attrib)
        {
            if (attrib != null)
            {
                int? columnCount = attrib.ColumnCount;
                ColumnCount = (columnCount != null ? columnCount.Value : 0);
                NullTdBody = attrib.NullTdBody;
                int? rowPitch = attrib.RowPitch;
                RowPitch = (rowPitch != null ? rowPitch.Value : 1);
                int? columnPitch = attrib.ColumnPitch;
                ColumnPitch = (columnPitch != null ? columnPitch.Value : 1);
                SelectedClass = attrib.SelectedClass;
                SelectedStyle = attrib.SelectedStyle;
                AlternateClass = attrib.AlternateClass;
                AlternateStyle = attrib.AlternateStyle;
                TableTrCloseMethod? trCloseMethod = attrib.TrCloseMethod;
                TrCloseMethod = (trCloseMethod != null ? trCloseMethod.Value : TableTrCloseMethod.Undefined);
                TableAlternateOrientation? alternateOrientation = attrib.AlternateOrientation;
                AlternateOrientation = (alternateOrientation != null ? alternateOrientation.Value : TableAlternateOrientation.Row);
            }
            else
            {
                ColumnCount = 0;
                NullTdBody = string.Empty;
                RowPitch = 1;
                ColumnPitch = 1;
                SelectedClass = string.Empty;
                SelectedStyle = string.Empty;
                AlternateClass = string.Empty;
                AlternateStyle = string.Empty;
                TrCloseMethod = TableTrCloseMethod.Undefined;
                AlternateOrientation = TableAlternateOrientation.Row;
            }
        }

        /// <summary>
        /// Adds the attribute.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="w">The w.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="args">The args.</param>
        protected internal virtual void AddAttribute(HtmlBuilder b, HtmlTextWriterEx w, HtmlTag tag, Nparams args)
        {
            bool isSelected;
            string appendStyle;
            bool isStyleDefined;
            string appendClass;
            bool isClassDefined;
            if (args != null)
            {
                isSelected = args.Slice<bool>("selected");
                appendStyle = args.Slice<string>("appendStyle");
                isStyleDefined = args.ContainsKey("style");
                appendClass = args.Slice<string>("appendClass");
                isClassDefined = args.ContainsKey("class");
                if (tag == HtmlTag.Tr)
                    IsTrHeader = args.Slice<bool>("header");
                if (args.HasValue())
                    b.AddAttribute(args, null);
            }
            else
            {
                isSelected = false;
                appendStyle = string.Empty;
                isStyleDefined = false;
                appendClass = string.Empty;
                isClassDefined = false;
            }
            // only apply remaining to td/th
            if (tag == HtmlTag.Td || tag == HtmlTag.Th)
            {
                // style
                if (!isStyleDefined)
                {
                    string effectiveStyle;
                    if (isSelected && !string.IsNullOrEmpty(SelectedStyle))
                    {
                        effectiveStyle = (appendStyle.Length == 0 ? SelectedStyle : SelectedStyle + " " + appendStyle);
                        w.AddAttributeIfUndefined(HtmlTextWriterAttribute.Style, effectiveStyle);
                    }
                    else if (!string.IsNullOrEmpty(AlternateStyle))
                    {
                        effectiveStyle = (appendStyle.Length == 0 ? AlternateStyle : AlternateStyle + " " + appendStyle);
                        switch (AlternateOrientation)
                        {
                            case TableAlternateOrientation.Column:
                                if ((((ColumnIndex - ColumnOffset - 1 + ColumnPitch) / ColumnPitch) % 2) == 0)
                                    w.AddAttributeIfUndefined(HtmlTextWriterAttribute.Style, effectiveStyle);
                                else if (appendStyle.Length > 0)
                                    w.AddAttributeIfUndefined(HtmlTextWriterAttribute.Style, appendStyle);
                                break;
                            case TableAlternateOrientation.Row:
                                if ((((RowIndex - RowOffset - 1 + RowPitch) / RowPitch) % 2) == 0)
                                    w.AddAttributeIfUndefined(HtmlTextWriterAttribute.Style, effectiveStyle);
                                else if (appendStyle.Length > 0)
                                    w.AddAttributeIfUndefined(HtmlTextWriterAttribute.Style, appendStyle);
                                break;
                            default:
                                throw new InvalidOperationException();
                        }
                    }
                    else if (appendStyle.Length > 0)
                        w.AddAttributeIfUndefined(HtmlTextWriterAttribute.Style, appendStyle);
                }
                // class
                if (!isClassDefined)
                {
                    string effectiveClass;
                    if (isSelected && !string.IsNullOrEmpty(SelectedClass))
                    {
                        effectiveClass = (appendClass.Length == 0 ? SelectedClass : SelectedClass + " " + appendClass);
                        w.AddAttributeIfUndefined(HtmlTextWriterAttribute.Class, effectiveClass);
                    }
                    else if (!string.IsNullOrEmpty(AlternateClass))
                    {
                        effectiveClass = (appendClass.Length == 0 ? AlternateClass : AlternateClass + " " + appendClass);
                        switch (AlternateOrientation)
                        {
                            case TableAlternateOrientation.Column:
                                if ((((ColumnIndex - ColumnOffset - 1 + ColumnPitch) / ColumnPitch) % 2) == 0)
                                    w.AddAttributeIfUndefined(HtmlTextWriterAttribute.Class, effectiveClass);
                                else if (appendClass.Length > 0)
                                    w.AddAttributeIfUndefined(HtmlTextWriterAttribute.Class, appendClass);
                                break;
                            case TableAlternateOrientation.Row:
                                if ((((RowIndex - RowOffset - 1 + RowPitch) / RowPitch) % 2) == 0)
                                    w.AddAttributeIfUndefined(HtmlTextWriterAttribute.Class, effectiveClass);
                                else if (appendClass.Length > 0)
                                    w.AddAttributeIfUndefined(HtmlTextWriterAttribute.Class, appendClass);
                                break;
                            default:
                                throw new InvalidOperationException();
                        }
                    }
                    else if (appendClass.Length > 0)
                        w.AddAttributeIfUndefined(HtmlTextWriterAttribute.Class, appendClass);
                }
            }
        }

        /// <summary>
        /// Gets or sets the alternate class.
        /// </summary>
        /// <value>
        /// The alternate class.
        /// </value>
        public string AlternateClass { get; set; }

        /// <summary>
        /// Gets or sets the alternate style.
        /// </summary>
        /// <value>
        /// The alternate style.
        /// </value>
        public string AlternateStyle { get; set; }

        /// <summary>
        /// Gets or sets the alternate orientation.
        /// </summary>
        /// <value>
        /// The alternate orientation.
        /// </value>
        public TableAlternateOrientation AlternateOrientation { get; set; }

        /// <summary>
        /// Gets the column count.
        /// </summary>
        public int ColumnCount { get; internal set; }

        /// <summary>
        /// Gets the index of the column.
        /// </summary>
        /// <value>
        /// The index of the column.
        /// </value>
        public int ColumnIndex { get; internal set; }

        /// <summary>
        /// Gets or sets the column offset.
        /// </summary>
        /// <value>
        /// The column offset.
        /// </value>
        public int ColumnOffset { get; set; }

        /// <summary>
        /// Gets or sets the column pitch.
        /// </summary>
        /// <value>
        /// The column pitch.
        /// </value>
        public int ColumnPitch { get; set; }

        internal bool IsTrHeader { get; set; }

        /// <summary>
        /// Gets or sets the null td body.
        /// </summary>
        /// <value>
        /// The null td body.
        /// </value>
        public string NullTdBody { get; set; }

        /// <summary>
        /// Gets the index of the row.
        /// </summary>
        /// <value>
        /// The index of the row.
        /// </value>
        public int RowIndex { get; internal set; }

        /// <summary>
        /// Gets or sets the row offset.
        /// </summary>
        /// <value>
        /// The row offset.
        /// </value>
        public int RowOffset { get; set; }

        /// <summary>
        /// Gets or sets the row pitch.
        /// </summary>
        /// <value>
        /// The row pitch.
        /// </value>
        public int RowPitch { get; set; }

        /// <summary>
        /// Gets or sets the selected class.
        /// </summary>
        /// <value>
        /// The selected class.
        /// </value>
        public string SelectedClass { get; set; }

        /// <summary>
        /// Gets or sets the selected style.
        /// </summary>
        /// <value>
        /// The selected style.
        /// </value>
        public string SelectedStyle { get; set; }

        internal TableStage Stage { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public object Tag { get; set; }

        /// <summary>
        /// Gets or sets the tr close method.
        /// </summary>
        /// <value>
        /// The tr close method.
        /// </value>
        public TableTrCloseMethod TrCloseMethod { get; set; }
    }
}