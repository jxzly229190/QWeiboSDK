namespace QWeiboSDK
{
    using System.Net;
    using System.Collections.Generic;

    public class Oauth
    {
        private Oauthkey2 Oauthkey2 = null;

        public Oauth(Oauthkey2 oauthkey2)
        {
            this.Oauthkey2 = oauthkey2;
        }

        //https://open.t.qq.com/cgi-bin/oauth2/authorize?client_id=APP_KEY&response_type=code&redirect_uri=http://www.myurl.com/example
        //https://open.t.qq.com/cgi-bin/oauth2/access_token?client_id=APP_KEY&client_secret=APP_SECRET&redirect_uri=http://www.myurl.com/example&grant_type=authorization_code&code=CODE

        public string GetOauthUrl(
            string url,
            string appKey,
            string openId,
            string tokenKey,
            string callbackUrl,
            List<Parameter> parameters,
            out string queryString)
        {
            string urlWithParameter = url;

            if (parameters == null)
            {
                parameters = new List<Parameter>();
            }

            //oauth_consumer_key=APP_KEY&access_token=ACCESSTOKEN&openid=OPENID&clientip=CLIENTIP&oauth_version=2.a&scope=all
            parameters.Add(new Parameter("oauth_consumer_key", appKey));
            parameters.Add(new Parameter("access_token", tokenKey));
            parameters.Add(new Parameter("openid", this.Oauthkey2.openId));
            parameters.Add(new Parameter("oauth_version", "2.a"));
            parameters.Add(new Parameter("scope", "all"));
            parameters.Add(new Parameter("clientip", Dns.GetHostAddresses(Dns.GetHostName()).ToString()));

            if (!string.IsNullOrEmpty(tokenKey))
            {
                parameters.Add(new Parameter("access_token ", tokenKey));
            }

            queryString = BuildQueryString(parameters);

            return urlWithParameter;
        }

        public string GetAccessToken()
        {
            var request=new QWeiboRequest();
            var result = request.SyncRequest(
                this.Oauthkey2,
                this.Oauthkey2.urlAccessToken,
                "GET",
                new List<Parameter>()
                    {
                        new Parameter(
                            "grant_type",
                            "authorization_code"),
                            new Parameter("code", Oauthkey2.code),
                            new Parameter("redirect_uri",this.Oauthkey2.callbackUrl),
                            new Parameter("client_id",this.Oauthkey2.appKey),
                            new Parameter("client_secret",this.Oauthkey2.appSecret)
                    },
                null);

            Oauthkey2.ParseToken(result);

            return Oauthkey2.tokenKey;
        }

        private string BuildQueryString(List<Parameter> parameters)
        {
            string queryString = "";
            if (parameters == null)
            {
                return queryString;
            }

            foreach (var parameter in parameters)
            {
                queryString += parameter.Name + "=" + parameter.Value + "&";
            }

            return queryString;
        }
    }
}