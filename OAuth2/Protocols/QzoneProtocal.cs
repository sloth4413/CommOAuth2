using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using OAuth2.Qzone;

namespace OAuth2.Protocols
{
    public static class QzoneProtocal
    {
        /// <summary>
        /// 请求用户授权认证
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static string RequestUserAuthPtl(this QzoneRequestAuthSetting setting)
        {
            if (String.IsNullOrEmpty(setting.AppId) || String.IsNullOrEmpty(setting.RedirectUri) ||
                setting.Scope == null || !setting.Scope.Any())
            {
                throw new ArgumentException(@"传递的设置有问题");
            }

            //http://weixinchat.ngrok.com/Response.aspx
            //TODO 后续版本中支持从date 获取Session
            var urlEncoded = HttpUtility.UrlEncode(setting.RedirectUri);
            const string format = "https://graph.qq.com/oauth2.0/authorize?response_type=code&client_id={0}&redirect_uri={1}&scope={2}&state={3}";
            var url = string.Format(format, setting.AppId, urlEncoded,
                String.Join(",", setting.Scope), "qzone");
            return url;
        }

        /// <summary>
        /// 请求用户获得访问令牌
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static string RequestGetAccessTokenPtl(this QzoneRequestResSetting setting)
        {
            if (String.IsNullOrEmpty(setting.AppId) || String.IsNullOrEmpty(setting.AppSecret) ||
                String.IsNullOrEmpty(setting.Code) || String.IsNullOrEmpty(setting.RedirectUri))
            {
                throw new ArgumentException(@"传递的设置有问题");
            }

            const string format = "https://graph.qq.com/oauth2.0/token?grant_type={0}&client_id={1}&client_secret={2}&code={3}&redirect_uri={4}";
            var url = string.Format(format, "authorization_code", setting.AppId, setting.AppSecret, setting.Code,setting.RedirectUri);
            return url;
        }

        public static string RequestUserInfoPtl(this QzoneResourceSession session, string language = "zh_CN")
        {
            if (String.IsNullOrEmpty(session.AccessToken.Value) || String.IsNullOrEmpty(session.AppId) || String.IsNullOrEmpty(session.OpenId))
            {
                throw new ArgumentException(@"传递的设置有问题");
            }
            const string format = "https://graph.qq.com/user/get_user_info?access_token={0}&oauth_consumer_key={1}&openid={2}&format=json";
            var url = string.Format(format, session.AccessToken.Value, session.AppId,session.OpenId);
            return url;
        }

        public static string RequestOpenIdPtl(this QzoneResourceSession session)
        {
            if (String.IsNullOrEmpty(session.AccessToken.Value))
            {
                throw new ArgumentException(@"传递的设置有问题");
            }

            const string format = "https://graph.qq.com/oauth2.0/me?access_token={0}";
            var url = string.Format(format,session.AccessToken.Value);
            return url;
        }
    }

    public enum QzoneScope
    {
        get_user_info,
        list_album,
        upload_pic,
        do_like
    }
}
