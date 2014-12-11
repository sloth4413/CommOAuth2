using System;
using OAuth2.Entities.Qzone;
using OAuth2.Exceptions;
using OAuth2.HttpUtils;
using OAuth2.JsonConverter;
using OAuth2.Protocols;

namespace OAuth2.Qzone
{
    public class QzoneResourceSession : IResourceSession, IForeverable
    {
        protected IHttpSupplier HttpSupplier;

        public long ExpiresIn { get; set; }

        public string AppId { get; set; }

        public string OpenId { get; set; }

        public QzoneResourceSession(IHttpSupplier httpSupplier,AccessToken accessToken,RefrechToken refrechToken = null,SessionLifetime lifetime=null)
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
                return HttpSupplier.Get<TRes, QzoneErrorResult>(uri);
            }
            catch (Exception)
            {
                return default(TRes);
            }
        }

        public bool Reconnect()
        {
            throw new NotImplementedException();
        }

        public SessionLifetime Lifetime { get; private set; }
        public Guid Identify { get; private set; }
        public IToken AccessToken { get; private set; }
        public IToken RefrechToken { get; private set; }
    }

    public class QzoneResourceSessionBuilder : SessionBuilder<QzoneRequestResSetting, QzoneResourceSession>
    {
        protected IHttpSupplier HttpSupplier = new HttpSuppplier();

        public override QzoneResourceSession Build(QzoneRequestResSetting setting)
        {
            try
            {
                var interactiveInfo = HttpSupplier.Get<QzoneAccessTokenInteractive, QzoneErrorResult>(new Uri(setting.RequestGetAccessTokenPtl()),new UrlParamConverter());
                var qzoneSession = new QzoneResourceSession(HttpSupplier, new AccessToken(interactiveInfo.access_token))
                {
                    ExpiresIn = long.Parse(interactiveInfo.expires_in)
                    ,AppId = setting.AppId
                };
                var openIdInfo = HttpSupplier.Get<QzoneOpenIdResult, QzoneErrorResult>(new Uri(qzoneSession.RequestOpenIdPtl()),new CallbackConverter());
                qzoneSession.OpenId = openIdInfo.openid;
                return qzoneSession;
            }
            catch (JsonResultException jException)
            {
                return null;
            }
        }
    }
}
