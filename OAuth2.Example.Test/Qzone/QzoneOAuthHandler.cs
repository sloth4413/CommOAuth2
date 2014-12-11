using System;
using System.Web;
using OAuth2.Entities.Qzone;
using OAuth2.MessageHandler;
using OAuth2.Protocols;
using OAuth2.Qzone;

namespace OAuth2.Example.Test.Qzone
{
    public class QzoneOAuthHandler:IOAuthHandler<QzoneContentInfo>
    {
        public void Execute(QzoneContentInfo context)
        {
            if (context == null) return;

            //上面代码比较Ugly吧?但是现在在没有提交泛型版本之前也只能这么写了.^_^
            QzoneResourceSessionBuilder sessionBuilder = new QzoneResourceSessionBuilder();

            var session = sessionBuilder.Build(new QzoneRequestResSetting("http://weixinchat.ngrok.com/Response.aspx")
            {
                AppId = "AppId",
                AppSecret = "AppSecret",
                Code = context.Code
            });

            var userInfo = session.Request<QzoneUserInfoResult>(new Uri(session.RequestUserInfoPtl()));

            context.Response.Write(userInfo.nickname + userInfo.figureurl);
            context.Response.End();
        }

        public Func<QzoneContentInfo> DefContext { get; set; }
    }

    public class QzoneContentInfo : ContextBase
    {
        public HttpResponse Response { get; set; }

        public string Code { get; set; }
    }
}