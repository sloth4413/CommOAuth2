using System;
using OAuth2.Example.Test.Ali;
using OAuth2.Example.Test.Qzone;
using OAuth2.Example.Test.Sina;
using OAuth2.Example.Test.WeiXin;
using OAuth2.Extension;
using OAuth2.MessageHandler;

namespace OAuth2.Example.Test
{
    /// <summary>
    /// 该处理器用于和服务商的认证服务器之间交互
    /// </summary>
    public partial class ResponseAuthentication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //开始执行
            if (Request["state"] != null && Request["state"] == "wx")
            {
                HandlerController.Singleton.Execute(()=>
                {
                    var contentInfo = new WxContentInfo();
                    if (Request["code"] != null)
                    {
                        contentInfo.Code = Request["code"];
                        contentInfo.Response = Response;
                    }
                    return contentInfo;
                });
            }

            if (Request["state"] != null && Request["state"] == "sina")
            {
                HandlerController.Singleton.Execute(() =>
                {
                    var contentInfo = new SinaContentInfo();
                    if (Request["code"] != null)
                    {
                        contentInfo.Code = Request["code"];
                        contentInfo.Response = Response;
                    }
                    return contentInfo;
                });
            }

            if (Request["is_success"] != null)
            {
                HandlerController.Singleton.Execute(() =>
                {
                    var contentInfo = new AliContentInfo(Request);
                    return contentInfo;
                });
            }

            if (Request["state"] != null && Request["state"] == "qzone")
            {
                HandlerController.Singleton.Execute(() =>
                {
                    var contentInfo = new QzoneContentInfo();
                    if (Request["code"] != null)
                    {
                        contentInfo.Code = Request["code"];
                        contentInfo.Response = Response;
                    }
                    return contentInfo;
                });
            }
        }

        static ResponseAuthentication()
        {
            //每个交互处理器必须首先注册到处理器控制器中
            HandlerController.Singleton.RegisterHandler(new WxOAuthHandler());
            HandlerController.Singleton.RegisterHandler(new SinaOAuthHandler());
            HandlerController.Singleton.RegisterHandler(new AliOAuthHandler());
            HandlerController.Singleton.RegisterHandler(new QzoneOAuthHandler());
        }
    }
}