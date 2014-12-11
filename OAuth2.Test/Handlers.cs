using System;
using System.Runtime.Remoting.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OAuth2.Example.Test.WeiXin;
using OAuth2.Extension;
using OAuth2.MessageHandler;
using OAuth2.WeiXin;

namespace OAuth2.Test
{
    /// <summary>
    /// 已经通过测试
    /// </summary>
    [TestClass]
    public class Handlers
    {
        [TestMethod]
        public void WxOAuthHandler()
        {
            //每个交互处理器必须首先注册到处理器控制器中
            HandlerController.Singleton.RegisterHandler(new WxOAuthHandler());

            //开始执行
            HandlerController.Singleton.Execute(() =>
            {
                var context = new WxContentInfo();
                return context;
            });
        }

    }
}
