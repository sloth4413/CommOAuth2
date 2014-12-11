using System;
using System.Web;
using OAuth2.MessageHandler;
using OAuth2.Protocols;
using OAuth2.WeiXin;
using OAuth2.Entities.WeiXin;

namespace OAuth2.Example.Test.WeiXin
{
    public class WxOAuthHandler : IOAuthHandler<WxContentInfo>
    {
        public void Execute(WxContentInfo context)
        {
            if (context == null) return;

            //上面代码比较Ugly吧?但是现在在没有提交泛型版本之前也只能这么写了.^_^
            WxResourceSessionBuilder sessionBuilder = new WxResourceSessionBuilder();

            var session = sessionBuilder.Build(new WxRequestResSetting("http://weixinchat.ngrok.com/Response.aspx", context.Code)
            {
                AppId = "wx62f0026ea2c556fd",
                AppSecret = "67c71c8d7edeb6637a9b3ee2c54cf28e"
            });

            var userInfo = session.Request<WxUserInfoResult>(new Uri(session.RequestUserInfoPtl()));

            context.Response.Write(userInfo.nickname + userInfo.country + userInfo.city + userInfo.province + userInfo.sex);
            context.Response.End();
        }

        public Func<WxContentInfo> DefContext { get; set; }
    }

    public class WxContentInfo : ContextBase
    {
        /// <summary>
        /// 授权码
        /// </summary>
        public string Code { get; set; }

        public HttpResponse Response { get; set; }
    }
}
