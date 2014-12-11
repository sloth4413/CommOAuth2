using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OAuth2.WeiXin;

namespace OAuth2.Protocols
{
    /// <summary>
    /// 微信协议包
    /// </summary>
    public static class WxProtocol
    {
        /// <summary>
        /// 请求用户授权认证
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static string RequestUserAuthPtl(this WxRequestAuthSetting setting)
        {
            if (String.IsNullOrEmpty(setting.AppId) || String.IsNullOrEmpty(setting.RedirectUri) ||
                setting.ScopeStorage == null || !setting.ScopeStorage.Any())
            {
                throw new ArgumentException(@"传递的设置有问题");
            }
            
            //TODO 后续版本中支持从date 获取Session
            var urlEncoded = HttpUtility.UrlEncode(setting.RedirectUri);
            const string format = "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type={2}&scope={3}&state={4}#wechat_redirect";
            var url= string.Format(format, setting.AppId,urlEncoded, setting.ResponseType,
                String.Join(",",setting.ScopeStorage),"wx");
            return url;
        }

        /// <summary>
        /// 请求用户获得访问令牌
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static string RequestGetAccessTokenPtl(this WxRequestResSetting setting)
        {
            if (String.IsNullOrEmpty(setting.AppId) || String.IsNullOrEmpty(setting.AppSecret) ||
                String.IsNullOrEmpty(setting.Code))
            {
                throw new ArgumentException(@"传递的设置有问题");
            }

            const string format = "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";
            var url = string.Format(format, setting.AppId, setting.AppSecret, setting.Code);
            return url;
        }

        public static string RequestUserInfoPtl(this WxResourceSession session, string language = "zh_CN")
        {
            if (String.IsNullOrEmpty(session.AccessToken.Value) || String.IsNullOrEmpty(session.OpenId))
            {
                throw new ArgumentException(@"传递的设置有问题");
            }
            const string format = "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang={2}";
            var url = string.Format(format, session.AccessToken.Value, session.OpenId, language);
            return url;
        }
    }

    /// <summary>
    /// 微信授权作用域
    /// </summary>
    public enum WxScope
    {
        snsapi_userinfo,//弹出授权页面，可通过openid拿到昵称、性别、所在地。并且，即使在未关注的情况下，只要用户授权，也能获取其信息
        snsapi_base//不弹出授权页面，直接跳转，只能获取用户openid
    }
}
