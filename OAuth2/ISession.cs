using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OAuth2.HttpUtils;

namespace OAuth2
{
    /// <summary>
    /// 和服务器的会话 所有的资源请求或者认证请求都从该会话开始获取
    /// 获取会话之后可以方便对会话的管理,比如用Lifetime工具来管理,
    /// 一旦会话过期,程序引导用户从服务器重新获得会话
    /// 
    /// </summary>
    /// <typeparam name="TRes"></typeparam>
    public interface ISession
    {
        /// <summary>
        /// 从该会话中去请求资源
        /// </summary>
        /// <typeparam name="TRes">资源类型</typeparam>
        /// <param name="uri">资源地址</param>
        /// <returns></returns>
        TRes Request<TRes>(Uri uri) where TRes : IResource;

        SessionLifetime Lifetime { get; }

        /// <summary>
        /// 会话标识
        /// </summary>
        Guid Identify { get; }
    }

    /// <summary>
    /// 请求获得的资源接口
    /// </summary>
    public interface IResource
    {
         
    }

    /// <summary>
    /// 认证服务器会话 和认证服务器之间的会话,此种会话只是为了完成
    /// 对认证的管理，最终导向资源会话。所以默认不具有生命周期(或是很短的)。
    /// 
    /// </summary>
    /// <typeparam name="TRes"></typeparam>
    public interface IAuthenticationSession:ISession
    {
        /// <summary>
        /// 认证服务器地址
        /// </summary>
        string AuthenticationUrl { get; }
    }

    /// <summary>
    /// 资源服务器会话 和资源服务器之间的会话,后续的所有获得资源接口
    /// 都从该会话中开始，也能够对资源会话进行时间控制管理和再获取
    /// 
    /// </summary>
    /// <typeparam name="TRes"></typeparam>
    public interface IResourceSession:ISession,IForeverable
    {
        /// <summary>
        /// 资源访问令牌
        /// </summary>
        IToken AccessToken { get; }

        /// <summary>
        /// 刷新令牌,用来在资源访问令牌过期后重新获得该令牌使用
        /// </summary>
        IToken RefrechToken { get; }
    }


}
