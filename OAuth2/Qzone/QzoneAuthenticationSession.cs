using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using OAuth2.Client;
using OAuth2.HttpUtils;
using OAuth2.Protocols;

namespace OAuth2.Qzone
{
    public class QzoneAuthenticationSession : IAuthenticationSession, IUrlDirect
    {
        protected IHttpSupplier HttpSupplier;

        public QzoneAuthenticationSession(IHttpSupplier httpSupplier)
        {
            this.HttpSupplier = httpSupplier;
        }

        public QzoneAuthenticationSession(string url)
        {
            this.AuthenticationUrl = url;
        }

        public TRes Request<TRes>(Uri uri) where TRes : IResource
        {
            throw new NotImplementedException();
        }

        public SessionLifetime Lifetime { get; private set; }
        public Guid Identify { get; private set; }
        public string AuthenticationUrl { get; private set; }
        public void Direct(HttpResponse response)
        {
            response.Redirect(Url);
        }

        public string Url { get { return AuthenticationUrl; } set { this.AuthenticationUrl = value; } }
    }

    public class QzoneAuthenticationSessionBuilder : SessionBuilder<QzoneRequestAuthSetting, QzoneAuthenticationSession>
    {
        public override QzoneAuthenticationSession Build(QzoneRequestAuthSetting setting)
        {
            var session = new QzoneAuthenticationSession(setting.RequestUserAuthPtl());
            return session;
        }
    }
}
