using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAuth2.Sina;

namespace OAuth2.Protocols
{
    public static class SinaProtocal
    {
        public static string RequestUserAuthPtl(this SinaRequestAuthSetting setting)
        {
            if (String.IsNullOrEmpty(setting.ClientId) || String.IsNullOrEmpty(setting.RedirectUri) ||
                setting.ScopeStorage == null)
            {
                throw new ArgumentException(@"传递的设置有问题");
            }

            var scope = String.Join(",", setting.ScopeStorage);
            const string format = "https://api.weibo.com/oauth2/authorize?client_id={0}&response_type=code&redirect_uri={1}&scope={2}&state=sina";
            var url = string.Format(format, setting.ClientId, setting.RedirectUri, scope);
            return url;
        }

        /// <summary>
        /// 请求用户获得访问令牌
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static string RequestGetAccessTokenPtl(this SinaRequestResSetting setting)
        {
            if (String.IsNullOrEmpty(setting.ClientId) || String.IsNullOrEmpty(setting.ClientSecret) ||
                String.IsNullOrEmpty(setting.Code) || String.IsNullOrEmpty(setting.RedirectUri))
            {
                throw new ArgumentException(@"传递的设置有问题");
            }

            const string format = "https://api.weibo.com/oauth2/access_token?client_id={0}&client_secret={1}&grant_type=authorization_code&redirect_uri={2}&code={3}";
            var url = string.Format(format, setting.ClientId, setting.ClientSecret, setting.RedirectUri,setting.Code);
            return url;
        }

        public static string RequestUserInfoPtl(this SinaResourceSession session, string language = "zh_CN")
        {
            if (String.IsNullOrEmpty(session.AccessToken.Value) || String.IsNullOrEmpty(session.UID))
            {
                throw new ArgumentException(@"传递的设置有问题");
            }
            const string format = "https://api.weibo.com/2/users/show.json?access_token={0}&uid={1}";
            var url = string.Format(format, session.AccessToken.Value, session.UID);
            return url;
        }
    }

    public enum SinaScope
    {
        all,
        email,
        direct_messages_write,
        direct_messages_read,
        invitation_write,
        friendships_groups_read,
        friendships_groups_write,
        statuses_to_me_read,
        follow_app_official_microblog
    }
}
