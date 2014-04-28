using System;
using System.Web.UI;

namespace WebAPITest
{
    using QWeiboSDK;

    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsCallback)
            {
                var appKey = StringParserHelper.GetConfig("AppKey");
                if (string.IsNullOrWhiteSpace(appKey))
                {
                    this.Response.Write("<script>alert('AppKey为空，请确认Web.Config中是否已经配置相关信息。')</script>");
                    return;
                }
                var appSecret = StringParserHelper.GetConfig("AppSercet");
                if (string.IsNullOrWhiteSpace(appSecret))
                {
                    this.Response.Write("<script>alert('AppSecret为空，请确认Web.Config中是否已经配置相关信息。')</script>");
                    return;
                }
                var callbackUrl = StringParserHelper.GetConfig("CallbackUrl");
                if (string.IsNullOrWhiteSpace(callbackUrl))
                {
                    this.Response.Write("<script>alert('CallbackUrl为空，请确认Web.Config中是否已经配置相关信息。')</script>");
                    return;
                }

                var oauthKey = new Oauthkey2(appKey, appSecret);
                oauthKey.callbackUrl = callbackUrl;

                authLink.NavigateUrl = oauthKey.urlUserAuthrize(oauthKey.callbackUrl);
            }
        }
    }

}
