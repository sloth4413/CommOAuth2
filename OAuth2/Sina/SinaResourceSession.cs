using System;
using OAuth2.Entities.Sina;
using OAuth2.Exceptions;
using OAuth2.HttpUtils;
using OAuth2.Protocols;

namespace OAuth2.Sina
{
    public class SinaResourceSession:IResourceSession,IForeverable
    {
        protected IHttpSupplier HttpSupplier;

        public string UID { get; set; }

        public long ExpiresInInternal { protected get; set; }

        public SinaResourceSession(IHttpSupplier httpSupplier,AccessToken accessToken,RefrechToken refrechToken = null,SessionLifetime lifetime=null)
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
                return HttpSupplier.Get<TRes, SinaErrorResult>(uri);
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

    public class SinaResourceSessionBuilder : SessionBuilder<SinaRequestResSetting, SinaResourceSession>
    {
        protected IHttpSupplier HttpSupplier = new HttpSuppplier();

        public override SinaResourceSession Build(SinaRequestResSetting setting)
        {
            try
            {
                var interactiveInfo = HttpSupplier.Post<SinaAccessTokenInteractive, SinaErrorResult>(new Uri(setting.RequestGetAccessTokenPtl()));
                return new SinaResourceSession(HttpSupplier, new AccessToken(interactiveInfo.access_token))
                {
                    UID = interactiveInfo.uid,ExpiresInInternal = long.Parse(interactiveInfo.expires_in)
                };
            }
            catch (JsonResultException jException)
            {
                return null;
            }
        }
    }
}
