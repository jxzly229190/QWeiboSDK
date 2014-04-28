using System;

namespace WebAPITest.Oauth
{
    using QWeiboSDK;

    public partial class GetAccessToken : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsCallback)
            {
                Oauthkey2 oauthKey = new Oauthkey2(
                    StringParserHelper.GetConfig("AppKey"),
                    StringParserHelper.GetConfig("AppSercet"));

                oauthKey.ParseToken(this.Request.Url.ToString());
                oauthKey.callbackUrl = StringParserHelper.GetConfig("CallbackUrl");

                var oauth2 = new Oauth(oauthKey);
                var accessToken = oauth2.GetAccessToken();

                if (string.IsNullOrWhiteSpace(accessToken))
                {
                    this.Response.Write("获取Access_Token失败");
                }
                this.Session["accessToken"] = accessToken;
                txtMsg.Text = "授权成功，accessToken:" + accessToken;
                var user = new user(oauthKey, "UTF-8").info();

                txtUserInfo.Text = "账户信息：\r\n" + user;
            }
        }
    }
}