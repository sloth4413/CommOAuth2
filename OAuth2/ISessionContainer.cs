using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2
{
    /// <summary>
    /// 会话容器
    /// </summary>
    public interface ISessionContainer
    {
        /// <summary>
        /// 注册会话
        /// </summary>
        /// <typeparam name="TSession"></typeparam>
        /// <param name="session"></param>
        void RegisterSession<TSession>(TSession session) where TSession:ISession;

        /// <summary>
        /// 从容器中获取会话
        /// </summary>
        /// <typeparam name="TSession"></typeparam>
        /// <param name="identify"></param>
        /// <returns></returns>

        TSession Resolve<TSession>(Guid identify) where TSession : ISession;
    }
}
