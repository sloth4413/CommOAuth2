using System;

namespace OAuth2.MessageHandler
{

    /// <summary>
    /// 认证交互处理器 和认证服务器的交互信息处理都可以
    /// 实现在Execute方法里,各种交互处理器(比如微信交互处理)
    /// 只需要实现该Handler即可。
    /// </summary>
    public interface IOAuthHandler<TContext> where TContext:ContextBase
    {
        void Execute(TContext context);

        Func<TContext> DefContext { get; set; }
    }

    public abstract class ContextBase
    {
    }
}
