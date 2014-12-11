using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth2
{
    /// <summary>
    /// 表示可以拥有持久Session的链接能力
    /// </summary>
    public interface IForeverable
    {
        /// <summary>
        /// Session失去持久后,重新链接
        /// </summary>
        /// <returns></returns>
        bool Reconnect();

        /// <summary>
        /// 该Session的声明周期
        /// </summary>
        //SessionLifetime Lifetime { get; }
    }
}
