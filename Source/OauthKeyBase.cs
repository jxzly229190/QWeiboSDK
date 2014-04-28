namespace QWeiboSDK
{
    using System.Text;

    public abstract class Oauthkey2
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OauthKey"/> class.
        /// </summary>
        /// <param name="appKey">The pcustomkey.</param>
        /// <param name="appSecret">The pcustomsecret.</param>
        /// <remarks></remarks>
        public Oauthkey2(string appKey, string appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract string urlUserAuthrize { get; }

        /// <summary>
        /// 
        /// </summary>
        public abstract string urlAccessToken { get; }

        /// <summary>
        /// Gets or sets the custom key.
        /// </summary>
        /// <value>The custom key.</value>
        /// <remarks></remarks>
        public abstract string appKey { get; set; }

        /// <summary>
        /// Gets or sets the custom secret.
        /// </summary>
        /// <value>The custom secret.</value>
        /// <remarks></remarks>
        public abstract string appSecret { get; set; }

        /// <summary>
        /// Gets or sets the token key.
        /// </summary>
        /// <value>The token key.</value>
        /// <remarks></remarks>
        public abstract string tokenKey { get; set; }

        /// <summary>
        /// Gets or sets the refresh key.
        /// </summary>
        public abstract string refreshKey { get; set; }

        /// <summary>
        /// Gets or sets the verify.
        /// </summary>
        /// <value>The verify.</value>
        /// <remarks></remarks>
        public abstract string code { get; set; }

        /// <summary>
        /// Gets or sets the callback URL.
        /// </summary>
        /// <value>The callback URL.</value>
        /// <remarks></remarks>
        public abstract string callbackUrl { get; set; }

        /// <summary>获取access token 重载
        /// Gets the access token.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="verifier">The verifier.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public abstract bool GetAccessToken(string url, string code);

        public abstract string openId { get; set; }
    }
}