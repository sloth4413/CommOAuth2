using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OAuth2.Sina
{
    /// <summary>
    /// 新浪微博请求验证设定
    /// </summary>
    public class SinaRequestAuthSetting:BuilderSetting
    {
        protected SinaRequestAuthSetting(string url) : base(url)
        {
        }

        public SinaRequestAuthSetting(string url,string clientId,List<string> scopeStorage):this(url)
        {
            this.ClientId = clientId;
            this.ScopeStorage = scopeStorage;
        }

        /// <summary>
        /// 设备编号
        /// </summary>
        public string ClientId { get; protected set; }

        /// <summary>
        /// 作用域
        /// </summary>
        public List<string> ScopeStorage { get; protected set; }

        /// <summary>
        /// 传递的参数
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 终端类型 默认Default，即网站
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Display { get; set; }

        /// <summary>
        /// 是否强制登录
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ForceLogin { get; set; }

        /// <summary>
        /// 使用的语言 默认为中文
        /// </summary>
        public string Language { get; set; }
    }
}
