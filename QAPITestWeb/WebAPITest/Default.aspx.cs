using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAPITest
{
    using System.Configuration;

    using QWeiboSDK;

    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsCallback)
            {
                var oauthKey = new Oauthkey2(StringParserHelper.GetConfig("AppKey"),StringParserHelper.GetConfig("AppSercet"));
                oauthKey.callbackUrl = "http://127.0.0.1:1472/OAuth/GetAccessToken";

                authLink.NavigateUrl = oauthKey.urlUserAuthrize(oauthKey.callbackUrl);
            }
        }
    }

    public partial class Default : _Default
    {
    }
}
