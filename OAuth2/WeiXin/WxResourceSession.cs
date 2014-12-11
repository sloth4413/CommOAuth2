using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAuth2.Entities.WeiXin;
using OAuth2.Exceptions;
using OAuth2.HttpUtils;
using OAuth2.Protocols;

namespace OAuth2.WeiXin
{
    /// <summary>
    /// 微信资源会话,通过该会话可以发送请求
    /// 注意: 只有和认证服务器进行认证会话并且通过了该服务器的认证后才有资源会话
    /// </summary>
    public class WxResourceSession:IResourceSession,IForeverable
    {
        protected IHttpSupplier HttpSupplier;

        public string OpenId { get; set; }

        public WxResourceSession(IHttpSupplier httpSupplier,AccessToken accessToken,RefrechToken refrechToken = null,SessionLifetime lifetime=null)
        {
            HttpSupplier = httpSupplier;
            AccessToken = accessToken;
            RefrechToken = refrechToken;
            Lifetime = lifetime;
        }

        public TRes Request<TRes>(Uri uri) where TRes : IResource
        {
            try
            {
                return HttpSupplier.Get<TRes, WxErrorResult>(uri);
            }
            catch (Exception)
            {
                return default(TRes);
            }
        }

        public SessionLifetime Lifetime { get; private set; }
        public Guid Identify { get; private set; }
        public IToken AccessToken { get; private set; }
        public IToken RefrechToken { get; private set; }
        public bool Reconnect()
        {
            //实现该接口以支持持久化Session
            throw new NotImplementedException();
        }
    }

    public class WxResourceSessionBuilder : SessionBuilder<WxRequestResSetting, WxResourceSession>
    {
        protected IHttpSupplier HttpSupplier = new HttpSuppplier();  

        /// <summary>
        /// 在认证服务器上完成和认证服务器的交互，并且拿到AccessToken
        /// 根据文档，该Token可以在后续的访问资源中调用API使用,不过
        /// 该Token可能过期,但也可以实现<seealso cref="IForeverable"/>来实现新获取Session机制
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public override WxResourceSession Build(WxRequestResSetting setting)
        {
            try
            {
                var interactiveInfo = HttpSupplier.Get<WxAccessTokenInteractive, WxErrorResult>(new Uri(setting.RequestGetAccessTokenPtl()));
                return new WxResourceSession(HttpSupplier, new AccessToken(interactiveInfo.access_token), new RefrechToken(interactiveInfo.refresh_token)){OpenId = interactiveInfo.openid};
            }
            catch (JsonResultException jException)
            {
                return null;
            }
        }
    }
}
