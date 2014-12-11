using System;
using System.Collections.Generic;
using OAuth2.Extension;

namespace OAuth2.MessageHandler
{
    /// <summary>
    /// 消息处理器控制器 对处理器进行控制
    /// </summary>
    public class HandlerController
    {
        private static HandlerController _Singleton = new HandlerController();

        public static HandlerController Singleton
        {
            get { return _Singleton; }
        }

        protected IDictionary<Type,object>    _Controllers = new Dictionary<Type, object>();

        public IDictionary<Type, object> Controller
        {
            get { return _Controllers; }
        }

        public void Execute<TContext>(Func<TContext> contextFunc) where TContext:ContextBase
        {
            var handler = Singleton.ResolveHandler<TContext>();//IOAuthHandler<WxContext> ->IOAuthHandler<ContextBase>
            if (null != handler)
            {
                handler.DefContext = contextFunc;
                if (handler.DefContext != null)
                {
                    handler.Execute(handler.DefContext());
                }
                else
                {
                    throw new ApplicationException("设置上下文委托");
                }
            }
        }
    }
}
