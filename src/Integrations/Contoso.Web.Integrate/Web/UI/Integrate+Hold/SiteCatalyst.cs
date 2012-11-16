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
using System.Web.UI;
namespace Contoso.Web.UI.Integrate
{
    /// <summary>
    /// SiteCatalyst
    /// </summary>
    public class SiteCatalyst : Control
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteCatalyst"/> class.
        /// </summary>
        public SiteCatalyst()
            : base()
        {
            DeploymentTarget = DeploymentEnvironment.Production;
        }

        /// <summary>
        /// Renders the specified w.
        /// </summary>
        /// <param name="w">The w.</param>
        protected override void Render(HtmlTextWriter w)
        {
            if (EnvironmentEx.DeploymentEnvironment == DeploymentTarget)
            {
                w.Write(@"<!-- SiteCatalyst code version: G.6.
Copyright 1997-2004 Omniture, Inc. More info available at http://www.omniture.com -->
<script language=""JavaScript""><!--
    /* You may give each page an identifying name, server, and channel on the next lines. */
    var s_pageName = "); w.Write(ClientScript.EncodeText(PageName ?? "")); w.Write(@";
    var s_server = "); w.Write(ClientScript.EncodeText(Server ?? "")); w.Write(@";
    var s_channel = "); w.Write(ClientScript.EncodeText(Channel ?? "")); w.Write(@";
    var s_hier1 = "); w.Write(ClientScript.EncodeText(Hier1 ?? "")); w.Write(@";
    var s_pageType = "); w.Write(ClientScript.EncodeText(PageType ?? "")); w.Write(@";
    var s_prop1 = "); w.Write(ClientScript.EncodeText(Property1 ?? "")); w.Write(@";
    var s_prop2 = "); w.Write(ClientScript.EncodeText(Property2 ?? "")); w.Write(@";
    var s_prop3 = "); w.Write(ClientScript.EncodeText(Property3 ?? "")); w.Write(@";
    /********* INSERT THE DOMAIN AND PATH TO YOUR CODE BELOW ************/ //--></script>
<script language=""JavaScript"" src="""); w.Write(ClientScript.EncodePartialText(RemoteCodeJsUri)); w.Write(@""" type=""text/javascript""></script>

<script language=""JavaScript"" type=""text/javascript""><!--    s_wds(s_account); s_ca(s_account); function sendAnalyticsEvent(str) { ns = s_account; if (str != null) ns += "","" + str; void (s_gs(ns)); }
    function sendLinkEvent(str, lnkname) {
        ns = s_account; if (str != """" && str != null) ns += "","" + str; s_linkType = ""o""; s_lnk = true; s_linkName = lnkname; void (s_gs(ns));
    } //--></script>

<!-- End SiteCatalyst code version: G.4. -->
</script>");
            }
            else
                w.WriteLine("<!-- Site Catalyst -->");
        }

        /// <summary>
        /// Gets or sets the channel.
        /// </summary>
        /// <value>
        /// The channel.
        /// </value>
        public string Channel { get; set; }
        /// <summary>
        /// Gets or sets the deployment target.
        /// </summary>
        /// <value>
        /// The deployment target.
        /// </value>
        public DeploymentEnvironment DeploymentTarget { get; set; }
        /// <summary>
        /// Gets or sets the hier1.
        /// </summary>
        /// <value>
        /// The hier1.
        /// </value>
        public string Hier1 { get; set; }
        /// <summary>
        /// Gets or sets the name of the page.
        /// </summary>
        /// <value>
        /// The name of the page.
        /// </value>
        public string PageName { get; set; }
        /// <summary>
        /// Gets or sets the type of the page.
        /// </summary>
        /// <value>
        /// The type of the page.
        /// </value>
        public string PageType { get; set; }
        /// <summary>
        /// Gets or sets the property1.
        /// </summary>
        /// <value>
        /// The property1.
        /// </value>
        public string Property1 { get; set; }
        /// <summary>
        /// Gets or sets the property2.
        /// </summary>
        /// <value>
        /// The property2.
        /// </value>
        public string Property2 { get; set; }
        /// <summary>
        /// Gets or sets the property3.
        /// </summary>
        /// <value>
        /// The property3.
        /// </value>
        public string Property3 { get; set; }
        /// <summary>
        /// Gets or sets the remote code js URI.
        /// </summary>
        /// <value>
        /// The remote code js URI.
        /// </value>
        public string RemoteCodeJsUri { get; set; }
        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>
        /// The server.
        /// </value>
        public string Server { get; set; }
    }
}
