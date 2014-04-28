using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QWeiboSDK
{
    public class QWeiboApiBase : QWeiboRequest
    {
        public Oauthkey2 Oauthkey2;
        public string format;

        public QWeiboApiBase(Oauthkey2 authkey, string format)
        {
            this.Oauthkey2 = authkey;
            this.format = format;
        }

        public string SyncRequest(TypeOption option, List<Parameter> listParam, List<Parameter> listFile)
        {
            return base.SyncRequest(this.Oauthkey2, ApiType.GetUrl(option), ApiType.GetHttpMethod(option), listParam, listFile);
        }

        public bool AsyncRequest(TypeOption option,List<Parameter> listParam, List<Parameter> listFile,
            AsyncRequestCallback callback, out int callbkey)
        {
            return base.AsyncRequest(ApiType.GetUrl(option), ApiType.GetHttpMethod(option), 
                            Oauthkey2,listParam,listFile,callback,out callbkey);
        }
    }
}
