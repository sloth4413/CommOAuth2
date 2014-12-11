using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth2.Sina
{
    public class SinaRequestResSetting:BuilderSetting
    {
        protected SinaRequestResSetting(string url) : base(url)
        {
        }

        public SinaRequestResSetting(string url,string code):this(url)
        {
            this.Code = code;
        }

        public string Code { get; protected set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string GrantType { get { return "authorization_code"; } }
    }
}
