namespace QWeiboSDK
{
    using System;
    using System.Collections.Generic;

    public class Oauthkey2
    {
        public Oauthkey2(string appkey, string appSecret)
        {
            this.appKey = appkey;
            this.appSecret = appSecret;
        }

        //client_id=APP_KEY&response_type=code&redirect_uri=http://www.myurl.com/example

        public string urlUserAuthrize(string callbackUrl)
        {
            return "https://open.t.qq.com/cgi-bin/oauth2/authorize?response_type=code&client_id=" + this.appKey
                   + "&redirect_uri=" + callbackUrl;

        }

        public string urlAccessToken
        {
            get
            {
                return "https://open.t.qq.com/cgi-bin/oauth2/access_token";
            }
        }

        public string appKey { get; set; }

        public string appSecret
        {
            get;
            set;
        }

        public string tokenKey { get; set; }

        public string refreshKey { get; set; }

        public string tokenSecret
        {
            get;
            set;
        }

        public string openId { get; set; }

        public string code
        {
            get;
            set;
        }

        public string callbackUrl
        {
            get;
            set;
        }

        public System.Text.Encoding Charset
        {
            get;
            set;
        }

        //public bool GetAuthCode(string callback)
        //{
        //    List<Parameter> parameters = new List<Parameter>();
        //    if (string.IsNullOrEmpty(callback))
        //    {
        //        callbackUrl = "http://www.qq.com";
        //    }

        //    QWeiboRequest request = new QWeiboRequest();
        //    return ParseToken(request.SyncRequest(this, urlUserAuthrize, "GET", parameters, null));
        //}

        public bool GetAccessToken(string verifier)
        {
            return this.GetAccessToken(this.urlAccessToken, verifier);
        }

        public bool GetAccessToken(string url, string verifier)
        {
            List<Parameter> parameters = new List<Parameter>();
            this.code = verifier;

            QWeiboRequest request = new QWeiboRequest();

            return ParseToken(request.SyncRequest(this, url, "GET", parameters, null));
        }

        public bool ParseToken(string response)
        {
            this.code = StringParserHelper.QueryString(response, "code");
            this.openId = StringParserHelper.QueryString(response, "openid");
            this.tokenKey = StringParserHelper.QueryString(response, "access_token");
            this.refreshKey = StringParserHelper.QueryString(response, "refresh_token");
            return true;
        }
    }
}