using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth2.Entities.Sina
{
    [Serializable]
    public class SinaAccessTokenInteractive
    {
        /// <summary>
        /// 资源 访问令牌
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// access_token的生命周期，单位是秒数。
        /// </summary>
        public string expires_in { get; set; }

        [Obsolete("access_token的生命周期（该参数即将废弃，开发者请使用expires_in）。")]
        public string remind_in { get; set; }

        /// <summary>
        /// 用户标识
        /// </summary>
        public string uid { get; set; }
    }
}
