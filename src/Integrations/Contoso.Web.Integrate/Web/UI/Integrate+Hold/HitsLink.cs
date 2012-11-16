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
using System.Web;
using System.Web.UI;
namespace Contoso.Web.UI.Integrate
{
    /// <summary>
    /// HitsLink
    /// </summary>
    public class HitsLink : Control
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HitsLink"/> class.
        /// </summary>
        public HitsLink()
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
                w.WriteLine(@"<!-- Industrial Quick Search Referring Site Stats web tools statistics hit counter code -->");
                w.WriteLine(@"<script type=""text/javascript"" id=""wa_u""></script>
<script type=""text/javascript"">
//<![CDATA[
    wa_account='" + Account + @"'; wa_location=" + Location + @";
    wa_pageName=" + (!string.IsNullOrEmpty(PageName) ? ClientScript.EncodeText(PageName) : "location.pathname") + @";
    document.cookie='__support_check=1';wa_hp='http';
    wa_rf=document.referrer;wa_sr=window.location.search;
    wa_tz=new Date();if(location.href.substr(0,6).toLowerCase()=='https:')
    wa_hp='https';wa_data='&an='+escape(navigator.appName)+ 
    '&sr='+escape(wa_sr)+'&ck='+document.cookie.length+
    '&rf='+escape(wa_rf)+'&sl='+escape(navigator.systemLanguage)+
    '&av='+escape(navigator.appVersion)+'&l='+escape(navigator.language)+
    '&pf='+escape(navigator.platform)+'&pg='+escape(wa_pageName);
    wa_data=wa_data+'&cd='+
    screen.colorDepth+'&rs='+escape(screen.width+ ' x '+screen.height)+
    '&tz='+wa_tz.getTimezoneOffset()+'&je='+ navigator.javaEnabled();
    wa_img=new Image();wa_img.src=wa_hp+'://loc1.hitsprocessor.com/statistics.asp'+
    '?v=1&s='+wa_location+'&eacct='+wa_account+wa_data+'&tks='+wa_tz.getTime();
    document.getElementById('wa_u').src=wa_hp+'://loc1.hitsprocessor.com/track.js';
//]]>
</script>
<!-- End Indust -->");
            }
            else
                w.WriteLine("<!-- Hits Link : " + HttpUtility.HtmlEncode(Account + "/" + Location) + " -->");
        }

        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        /// <value>
        /// The account.
        /// </value>
        public string Account { get; set; }
        /// <summary>
        /// Gets or sets the deployment target.
        /// </summary>
        /// <value>
        /// The deployment target.
        /// </value>
        public DeploymentEnvironment DeploymentTarget { get; set; }
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets the name of the page.
        /// </summary>
        /// <value>
        /// The name of the page.
        /// </value>
        public string PageName { get; set; }
    }
}
