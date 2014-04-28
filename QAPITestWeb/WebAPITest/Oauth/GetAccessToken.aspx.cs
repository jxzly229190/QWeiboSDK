using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAPITest.Oauth
{
    using QWeiboSDK;

    public partial class GetAccessToken : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsCallback)
            {
                var queryString = "";

                Oauthkey2 oauthKey = new Oauthkey2(
                    StringParserHelper.GetConfig("AppKey"),
                    StringParserHelper.GetConfig("AppSercet"));

                oauthKey.ParseToken(this.Request.Url.ToString());

                oauthKey.callbackUrl = StringParserHelper.GetConfig("CallbackUrl");

                var oauth2 = new Oauth(oauthKey);
                var url = oauth2.GetAccessToken();

                var user = new QWeiboSDK.user(oauthKey, "UTF-8").info();

                this.Response.Write(user);
            }
        }
    }
}