using System;
using System.Web;
using OAuth2.Client;
using OAuth2.HttpUtils;
using OAuth2.Protocols;

namespace OAuth2.WeiXin
{
    public class WxAuthenticationSession:IAuthenticationSession,IUrlDirect
    {
        protected IHttpSupplier HttpSupplier;

        public WxAuthenticationSession(IHttpSupplier httpSupplier)
        {
            HttpSupplier = httpSupplier;
        }

        public TRes Request<TRes>(Uri uri) where TRes : IResource
        {
            throw new NotImplementedException();
        }

        public SessionLifetime Lifetime { get; private set; }
        public Guid Identify { get; private set; }

        public string AuthenticationUrl { get; private set; }

        public WxAuthenticationSession(string url)
        {
            this.AuthenticationUrl = url;
        }

        public void Direct(HttpResponse response)
        {
            response.Redirect(Url);
        }

        public string Url { get { return AuthenticationUrl; } set { this.AuthenticationUrl = value; }}
    }

    public class WxAuthenticationSessionBuilder : SessionBuilder<WxRequestAuthSetting, WxAuthenticationSession>
    {
        /// <summary>
        /// 因为对于微信认证服务器而言,Web Server默认是Redirect到一个新的地址,所以这里直接
        /// 返回一个会话,而这种认证服务会话的生命周期都是immediately的
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public override WxAuthenticationSession Build(WxRequestAuthSetting setting)
        {
            return new WxAuthenticationSession(setting.RequestUserAuthPtl());
        }
    }
}
