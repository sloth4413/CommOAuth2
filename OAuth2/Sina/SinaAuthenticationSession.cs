using System;
using System.Web;
using OAuth2.Client;
using OAuth2.HttpUtils;
using OAuth2.Protocols;

namespace OAuth2.Sina
{
    public class SinaAuthenticationSession : IAuthenticationSession, IUrlDirect
    {
        protected IHttpSupplier HttpSupplier;

        public SinaAuthenticationSession(IHttpSupplier  httpSupplier)
        {
            this.HttpSupplier = httpSupplier;
        }

        public TRes Request<TRes>(Uri uri) where TRes : IResource
        {
            throw new NotImplementedException();
        }

        public SessionLifetime Lifetime { get; private set; }
        public Guid Identify { get; private set; }

        public string AuthenticationUrl { get; private set; }

        public SinaAuthenticationSession(string url)
        {
            this.AuthenticationUrl = url;
        }

        public void Direct(HttpResponse response)
        {
            response.Redirect(Url);
        }

        public string Url { get { return AuthenticationUrl; } set { this.AuthenticationUrl = value; } }
    }

    public class SinaAuthenticationSessionBuilder : SessionBuilder<SinaRequestAuthSetting, SinaAuthenticationSession>
    {
        public override SinaAuthenticationSession Build(SinaRequestAuthSetting setting)
        {
            var session = new SinaAuthenticationSession(setting.RequestUserAuthPtl());
            return session;
        }
    }
}
