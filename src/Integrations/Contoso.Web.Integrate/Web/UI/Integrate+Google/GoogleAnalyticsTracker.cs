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
using System.Web.UI;
using System;
using System.Web;
namespace Contoso.Web.UI.Integrate
{
    /// <summary>
    /// GoogleAnalyticsTracker
    /// </summary>
    // http://code.google.com/apis/analytics/docs/gaJS/gaJSApiEcommerce.html
    public class GoogleAnalyticsTracker : Control
    {
        //private static readonly string AppSettingID_OperationMode = "GoogleAnalyticsTracker::OperationMode";
        //private static readonly string AppSettingID_TrackerID = "GoogleAnalyticsTracker::TrackerID";
        private static readonly Type _trackerOperationModeType = typeof(TrackerOperationMode);

        #region Class Types

        /// <summary>
        /// AnalyticsAttributes
        /// </summary>
        public class AnalyticsAttributes
        {
            /// <summary>
            /// Gets or sets the allow linker.
            /// </summary>
            /// <value>
            /// The allow linker.
            /// </value>
            public bool? AllowLinker { get; set; }
            /// <summary>
            /// Gets or sets the name of the domain.
            /// </summary>
            /// <value>
            /// The name of the domain.
            /// </value>
            public string DomainName { get; set; }
            /// <summary>
            /// Gets or sets the allow hash.
            /// </summary>
            /// <value>
            /// The allow hash.
            /// </value>
            public bool? AllowHash { get; set; }
        }

        /// <summary>
        /// TrackerOperationMode
        /// </summary>
        public enum TrackerOperationMode
        {
            /// <summary>
            /// Production
            /// </summary>
            Production,
            /// <summary>
            /// Development
            /// </summary>
            Development,
            /// <summary>
            /// Commented
            /// </summary>
            Commented,
        }

        /// <summary>
        /// AnalyticsCommerceTransaction
        /// </summary>
        public class AnalyticsCommerceTransaction
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="AnalyticsCommerceTransaction"/> class.
            /// </summary>
            public AnalyticsCommerceTransaction()
            {
                Country = "USA";
            }

            /// <summary>
            /// OrderID
            /// </summary>
            public string OrderID { get; set; }

            /// <summary>
            /// AffiliationID
            /// </summary>
            public string AffiliationID { get; set; }

            /// <summary>
            /// TotalAmount
            /// </summary>
            public decimal TotalAmount { get; set; }

            /// <summary>
            /// TaxAmount
            /// </summary>
            public decimal TaxAmount { get; set; }

            /// <summary>
            /// ShippingAmount
            /// </summary>
            public decimal ShippingAmount { get; set; }

            /// <summary>
            /// City
            /// </summary>
            public string City { get; set; }

            /// <summary>
            /// State
            /// </summary>
            public string State { get; set; }

            /// <summary>
            /// Country
            /// </summary>
            public string Country { get; set; }
        }

        /// <summary>
        /// AnalyticsCommerceItem
        /// </summary>
        public class AnalyticsCommerceItem
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="AnalyticsCommerceItem"/> class.
            /// </summary>
            public AnalyticsCommerceItem() { }

            /// <summary>
            /// OrderID
            /// </summary>
            public string OrderID { get; set; }

            /// <summary>
            /// SkuID
            /// </summary>
            public string SkuID { get; set; }

            /// <summary>
            /// ProductName
            /// </summary>
            public string ProductName { get; set; }

            /// <summary>
            /// CategoryName
            /// </summary>
            public string CategoryName { get; set; }

            /// <summary>
            /// Price
            /// </summary>
            public decimal Price { get; set; }

            /// <summary>
            /// Count
            /// </summary>
            public int Count { get; set; }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleAnalyticsTracker"/> class.
        /// </summary>
        public GoogleAnalyticsTracker()
            : base()
        {
            DeploymentTarget = DeploymentEnvironment.Production;
            Version = 3;
            //var hash = Kernel.Instance.Hash;
            //// determine operationMode
            //object operationMode;
            //if (hash.TryGetValue(AppSettingID_OperationMode, out operationMode))
            //    OperationMode = (TrackerOperationMode)Enum.Parse(s_trackerOperationModeType, (string)operationMode);
            //else if (EnvironmentEx.DeploymentEnvironment == DeploymentTarget)
            //    OperationMode = TrackerOperationMode.Production;
            //else
            //    OperationMode = TrackerOperationMode.Development;
            //// determine trackerID
            //object trackerID;
            //if (hash.TryGetValue(AppSettingID_TrackerID, out trackerID))
            //    TrackerID = trackerID.Parse<string>();
        }

        /// <summary>
        /// Gets or sets the operation mode.
        /// </summary>
        /// <value>The operation mode.</value>
        public TrackerOperationMode OperationMode { get; set; }

        /// <summary>
        /// Sends server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter"/> object, which writes the content to be rendered on the client.
        /// </summary>
        /// <param name="w">The w.</param>
        protected override void Render(HtmlTextWriter w)
        {
            if (string.IsNullOrEmpty(TrackerID))
                return;
            OnPreEmit();
            var operationMode = OperationMode;
            switch (operationMode)
            {
                case TrackerOperationMode.Production:
                case TrackerOperationMode.Commented:
                    var emitCommented = (operationMode == TrackerOperationMode.Commented);
                    switch (Version)
                    {
                        case 3:
                            EmitVersion3(w, emitCommented);
                            break;
                        case 2:
                            EmitVersion2(w, emitCommented);
                            break;
                        case 1:
                            EmitVersion1(w, emitCommented);
                            break;
                        default:
                            throw new InvalidOperationException();
                    }
                    break;
                case TrackerOperationMode.Development:
                    w.WriteLine("<!--GoogleAnalyticsTracker[" + HttpUtility.HtmlEncode(TrackerID) + "]-->");
                    var commerceTransaction = CommerceTransaction;
                    if (commerceTransaction != null)
                        w.WriteLine("<!--GoogleAnalyticsTracker::CommerceTransaction[" + commerceTransaction.OrderID + "]-->");
                    var commerceItemArray = CommerceItems;
                    if (commerceItemArray != null)
                        w.WriteLine("<!--GoogleAnalyticsTracker::CommerceItemArray[" + commerceItemArray.Length.ToString() + "]-->");
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Gets or sets the deployment target.
        /// </summary>
        /// <value>
        /// The deployment target.
        /// </value>
        public DeploymentEnvironment DeploymentTarget { get; set; }

        #region Emit

        private void EmitCommerceVersion2(HtmlTextWriter w, bool emitCommented)
        {
            var commerceTransaction = CommerceTransaction;
            var commerceItems = CommerceItems;
            if (commerceTransaction != null || commerceItems != null)
            {
                if (commerceTransaction != null)
                {
                    w.Write("pageTracker._addTrans(");
                    w.Write(ClientScript.EncodeText(commerceTransaction.OrderID ?? string.Empty));
                    w.Write(","); w.Write(ClientScript.EncodeText(commerceTransaction.AffiliationID ?? string.Empty));
                    w.Write(","); w.Write(ClientScript.EncodeText(commerceTransaction.TotalAmount.ToString()));
                    w.Write(","); w.Write(ClientScript.EncodeText(commerceTransaction.TaxAmount.ToString()));
                    w.Write(","); w.Write(ClientScript.EncodeText(commerceTransaction.ShippingAmount.ToString()));
                    w.Write(","); w.Write(ClientScript.EncodeText(commerceTransaction.City ?? string.Empty));
                    w.Write(","); w.Write(ClientScript.EncodeText(commerceTransaction.State ?? string.Empty));
                    w.Write(","); w.Write(ClientScript.EncodeText(commerceTransaction.Country ?? string.Empty));
                    w.Write(");\n");
                }
                if (commerceItems != null)
                    foreach (var commerceItem in commerceItems)
                        if (commerceItem != null)
                        {
                            w.Write("pageTracker._addItem(");
                            w.Write(ClientScript.EncodeText(commerceItem.OrderID ?? string.Empty));
                            w.Write(","); w.Write(ClientScript.EncodeText(commerceItem.SkuID ?? string.Empty));
                            w.Write(","); w.Write(ClientScript.EncodeText(commerceItem.ProductName ?? string.Empty));
                            w.Write(","); w.Write(ClientScript.EncodeText(commerceItem.CategoryName ?? string.Empty));
                            w.Write(","); w.Write(ClientScript.EncodeText(commerceItem.Price.ToString()));
                            w.Write(","); w.Write(ClientScript.EncodeText(commerceItem.Count.ToString()));
                            w.Write(");\n");
                        }
                w.Write("pageTracker._trackTrans();\n");
            }
        }

        private void EmitVersion3(HtmlTextWriter w, bool emitCommented)
        {
            w.Write(!emitCommented ? "<script type=\"text/javascript\">\n" : "<!--script type=\"text/javascript\">\n");
            w.Write(@"//<![CDATA[
var _gaq = _gaq || [];
_gaq.push(['_setAccount', '"); w.Write(TrackerID); w.WriteLine(@"']);");
            if (Attributes != null)
            {
                if (!string.IsNullOrEmpty(Attributes.DomainName))
                {
                    w.Write(@"_gaq.push(['_setDomainName', "); w.Write(ClientScript.EncodeText(Attributes.DomainName)); w.WriteLine(@"]);");
                }
                if (Attributes.AllowLinker.HasValue)
                {
                    w.Write(@"_gaq.push(['setAllowLinker', "); w.Write(ClientScript.EncodeBool(Attributes.AllowLinker.Value)); w.WriteLine(@"]);");
                }
                if (Attributes.AllowHash.HasValue)
                {
                    w.Write(@"_gaq.push(['setAllowHash', "); w.Write(ClientScript.EncodeBool(Attributes.AllowHash.Value)); w.WriteLine(@"]);");
                }
            }
            w.Write(@"_gaq.push(['_trackPageview']);

  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();
            //]]>");
            w.Write(!emitCommented ? "</script>\n" : "</script-->");
        }

        private void EmitVersion2(HtmlTextWriter w, bool emitCommented)
        {
            w.Write(!emitCommented ? "<script type=\"text/javascript\">\n" : "<!--script type=\"text/javascript\">\n");
            w.Write(@"//<![CDATA[
var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www."");
document.write(unescape(""%3Cscript src='"" + gaJsHost + ""google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E""));
//]]>");
            w.Write(!emitCommented ? "</script><script type=\"text/javascript\">\n" : "</script--><!--script type=\"text/javascript\">\n");
            w.Write(@"//<![CDATA[
try {
var pageTracker = _gat._getTracker("""); w.Write(TrackerID); w.Write("\");\n");
            w.Write("pageTracker._trackPageview();\n");
            EmitCommerceVersion2(w, emitCommented);
            w.Write(@"} catch(err) {}
//]]>");
            w.Write(!emitCommented ? "</script>\n" : "</script-->");
        }

        private void EmitVersion1(HtmlTextWriter w, bool emitCommented)
        {
            w.Write(!emitCommented ? "<script src=\"http://www.google-analytics.com/urchin.js\" type=\"text/javascript\"></script><script type=\"text/javascript\">" : "<!--script src=\"http://www.google-analytics.com/urchin.js\" type=\"text/javascript\"></script--><!--script type=\"text/javascript\">");
            w.Write(@"//<![CDATA[
_uacct = """); w.Write(TrackerID); w.Write(@""";
urchinTracker();
//]]>");
            w.Write(!emitCommented ? "</script>" : "</script-->");
        }

        #endregion

        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>
        /// The attributes.
        /// </value>
        public AnalyticsAttributes Attributes { get; set; }

        /// <summary>
        /// Gets or sets the commerce transaction.
        /// </summary>
        /// <value>
        /// The commerce transaction.
        /// </value>
        public AnalyticsCommerceTransaction CommerceTransaction { get; set; }

        /// <summary>
        /// Gets or sets the commerce item array.
        /// </summary>
        /// <value>
        /// The commerce item array.
        /// </value>
        public AnalyticsCommerceItem[] CommerceItems { get; set; }

        /// <summary>
        /// Gets or sets the tracker id.
        /// </summary>
        /// <value>
        /// The tracker id.
        /// </value>
        public string TrackerID { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        //+ should be: VersionID
        public int Version { get; set; }

        /// <summary>
        /// Called when [pre emit].
        /// </summary>
        protected virtual void OnPreEmit()
        {
            var preEmit = PreEmit;
            if (preEmit != null)
                preEmit(this, EventArgs.Empty);
        }

        /// <summary>
        /// Occurs when [pre emit].
        /// </summary>
        public event EventHandler PreEmit;
    }
}
