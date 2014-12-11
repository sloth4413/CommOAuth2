using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2
{
    /// <summary>
    /// 会话生命期,该会话生命期为逻辑周期，为了方便管理会话的时间
    /// </summary>
    public class SessionLifetime
    {
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan Value { get; protected set; }

        /// <summary>
        /// 生命周期是否结束
        /// </summary>
        public bool IsDeath { get; set; }
    }
}
