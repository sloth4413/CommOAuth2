using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2
{
    /// <summary>
    /// 会话创建者
    /// </summary>
    public abstract class SessionBuilder<TSetting,TSession>
        where TSetting:BuilderSetting
        where TSession:class,ISession
    {
        public abstract TSession Build(TSetting setting);
    }

    /// <summary>
    /// 创建者配置
    /// </summary>
    public class BuilderSetting
    {
        protected BuilderSetting(string url)
        {
            this.RedirectUri = url;
        }

        /// <summary>
        /// 重定向地址
        /// </summary>
        public string RedirectUri { get; set; }
    }
}
