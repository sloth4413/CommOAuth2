using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OAuth2.Protocols;
using OAuth2.WeiXin;

namespace OAuth2.Example.Test
{
    /// <summary>
    /// 该处理器用于当用户点击登录后向认证服务器发起请求
    /// 
    /// </summary>
    public partial class RequestAuthentication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //创建一个会话生成器,该生成器用来生成和认证服务器的会话
            WxAuthenticationSessionBuilder  sessionBuilder = new WxAuthenticationSessionBuilder();

            //传递给认证服务器的协议参数,具体http://mp.weixin.qq.com/wiki/index.php?title=网页授权获取用户基本信息
            var setting = new WxRequestAuthSetting("http://weixinchat.ngrok.com/Response.aspx", new List<string>() { WxScope.snsapi_userinfo.ToString() }) { AppId = "AppId" };

            //因为该事例采用server-side方式来认证,所以直接引导用户到提供商认证服务器的页面处理器上去
            var wxAuthenticationSession = sessionBuilder.Build(setting);
            if (wxAuthenticationSession != null)
                wxAuthenticationSession.Direct(Response);
        }
    }
}