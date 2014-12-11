using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth2.WeiXin
{
    /// <summary>
    /// 使用该包换取资源访问令牌，进而得到资源服务器的会话
    /// </summary>
    public class WxRequestResSetting:BuilderSetting
    {
        protected WxRequestResSetting(string url) : base(url)
        {
        }

        public WxRequestResSetting(string url,string code):this(url)
        {
            this.Code = code;
        }

        /// <summary>
        /// 应用编号
        /// </summary>
        public string AppId { get; set; }

        public string AppSecret { get; set; }

        /// <summary>
        /// OAUTH2授权码
        /// </summary>
        public string Code { get; set; }

        public string GrantType { get { return "authorization_code"; } }
    }
}
