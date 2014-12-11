using System;

namespace OAuth2.Entities.WeiXin
{
    [Serializable]
    public class WxAccessTokenInteractive
    {
        /// <summary>
        /// 访问令牌
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 令牌期限
        /// </summary>
        public long expires_in { get; set; }

        /// <summary>
        /// 刷新令牌
        /// </summary>
        public string refresh_token { get; set; }

        /// <summary>
        /// 用户标识
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 获得的用户授权
        /// </summary>
        public string scope { get; set; }
    }
}
