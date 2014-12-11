using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OAuth2.MessageHandler;

namespace OAuth2.Example.Test.Ali
{
    public class AliOAuthHandler : IOAuthHandler<AliContentInfo>
    {
        public void Execute(AliContentInfo context)
        {
            throw new NotImplementedException();
        }

        public Func<AliContentInfo> DefContext { get; set; }
    }

    public class AliContentInfo : ContextBase
    {
        public HttpRequest HttpRequest { get; protected set; }

        public AliContentInfo(HttpRequest   request)
        {
            this.HttpRequest = request;
        }
    }
}