using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2.WeiXin
{
    /// <summary>
    /// 微信请求认证配置
    /// 具体参数见 
    /// http://mp.weixin.qq.com/wiki/index.php?title=网页授权获取用户基本信息
    /// </summary>
    public class WxRequestAuthSetting:BuilderSetting
    {
        public const string FingerPrint = "#wechat_redirect";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">和认证服务器交互地址</param>
        public WxRequestAuthSetting(string url) : base(url)
        {
        }

        public WxRequestAuthSetting(string url,List<string> scope):this(url)
        {
            this.ScopeStorage = scope;
        }

        /// <summary>
        /// 公众号的唯一标识
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 返回类型,该域始终为code
        /// </summary>
        public string ResponseType { get { return "code"; } }

        /// <summary>
        /// 用户权限作用域
        /// </summary>
        public List<string> ScopeStorage { get; protected set; }
    }
}
