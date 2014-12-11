using System;
using System.IO;
using System.Web;
using OAuth2;
using OAuth2.HttpUtils;

namespace AliPay.Authorization
{
    public class AlAuthenticationSession : IAuthenticationSession
    {
        protected IHttpSupplier HttpSupplier;
        protected IRenderable<AlRequestAuthSetting> Render;

        public AlAuthenticationSession(IHttpSupplier httpSupplier, IRenderable<AlRequestAuthSetting> render)
        {
            this.HttpSupplier = httpSupplier;
            this.Render = render;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpSupplier">Http请求服务</param>
        /// <param name="context">渲染源内容</param>
        /// <param name="render">渲染器</param>
        public AlAuthenticationSession(IHttpSupplier httpSupplier, Stream context, IRenderable<AlRequestAuthSetting> render)
            : this(httpSupplier,render)
        {
            this.Render.Context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpSupplier"></param>
        /// <param name="setting">渲染内容配置</param>
        /// <param name="render"></param>
        public AlAuthenticationSession(IHttpSupplier httpSupplier, AlRequestAuthSetting setting, IRenderable<AlRequestAuthSetting> render)
            : this(httpSupplier,render)
        {
            this.Render.Setting = setting;
        }

        public AlAuthenticationSession(string returnUrl)
        {
            this.AuthenticationUrl = returnUrl;
        }

        public TRes Request<TRes>(Uri uri) where TRes : IResource
        {
            throw new NotImplementedException();
        }

        public SessionLifetime Lifetime { get; private set; }
        public Guid Identify { get; private set; }

        public string AuthenticationUrl { get; private set; }

        public string Url { get { return AuthenticationUrl; } set { this.AuthenticationUrl = value; } }

        public IRenderable<AlRequestAuthSetting> HtmlRender
        {
            get { return Render; }
        }
    }

    public class AlAuthenticationSessionBuilder : SessionBuilder<AlRequestAuthSetting, AlAuthenticationSession>
    {
        public override AlAuthenticationSession Build(AlRequestAuthSetting setting)
        {
            return new AlAuthenticationSession(new HttpSuppplier(),setting,new HtmlRender());
        }
    }
}
