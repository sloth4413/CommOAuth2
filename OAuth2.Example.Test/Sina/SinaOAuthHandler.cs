using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OAuth2.Entities.Sina;
using OAuth2.MessageHandler;
using OAuth2.Protocols;
using OAuth2.Sina;

namespace OAuth2.Example.Test.Sina
{
    public class SinaOAuthHandler : IOAuthHandler<SinaContentInfo>
    {
        public void Execute(SinaContentInfo context)
        {
            if (context == null) return;

            //上面代码比较Ugly吧?但是现在在没有提交泛型版本之前也只能这么写了.^_^
            SinaResourceSessionBuilder sessionBuilder = new SinaResourceSessionBuilder();

            var session = sessionBuilder.Build(new SinaRequestResSetting("http://weixinchat.ngrok.com/Response.aspx", context.Code)
            {
                ClientId = "2807558453",
                ClientSecret = "4568a75593978efe7f1fcf5d3c7fb658"
            });

            var userInfo = session.Request<SinaUserInfoResult>(new Uri(session.RequestUserInfoPtl()));

            context.Response.Write(userInfo.screen_name + userInfo.location);
            context.Response.End();
        }

        public Func<SinaContentInfo> DefContext { get; set; }
    }

    public class SinaContentInfo : ContextBase
    {
        /// <summary>
        /// 授权码
        /// </summary>
        public string Code { get; set; }

        public HttpResponse Response { get; set; }
    }
}