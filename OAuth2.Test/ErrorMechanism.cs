using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OAuth2.Entities.Qzone;
using OAuth2.Entities.Sina;
using OAuth2.Entities.WeiXin;
using OAuth2.HttpUtils;
using OAuth2.Protocols;
using OAuth2.Qzone;
using OAuth2.Sina;
using OAuth2.WeiXin;

namespace OAuth2.Test
{
    [TestClass]
    public class ErrorMechanism
    {
        [TestMethod]
        public void HandleError()
        {
            #region 触发WeiXin错误包
            //WxResourceSession   wxSession = new WxResourceSession(new HttpSuppplier(),new AccessToken("test")){OpenId = "test"};
            //wxSession.Request<WxUserInfoResult>(new Uri(wxSession.RequestUserInfoPtl()));
            #endregion

            #region 触发WeiBo错误包
            //var sinaSession = new SinaResourceSession(new HttpSuppplier(), new AccessToken("2.00YnCkXDrMOAED8c572cd15bunbBRC")) { UID = "1404376560" };
            //sinaSession.Request<SinaUserInfoResult>(new Uri(sinaSession.RequestUserInfoPtl()));
            #endregion

            #region 触发Qzone错误包

            var qzoneSession = new QzoneResourceSession(new HttpSuppplier(), new AccessToken("12345")){AppId = "12345",OpenId = "12345"};
            var userInfo = qzoneSession.Request<QzoneUserInfoResult>(new Uri(qzoneSession.RequestUserInfoPtl()));
            #endregion
        }
    }
}
