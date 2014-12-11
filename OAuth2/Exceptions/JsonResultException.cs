using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAuth2.Entities;
using OAuth2.Entities.WeiXin;

namespace OAuth2.Exceptions
{
    public class JsonResultException:ApplicationException
    {
        public JsonResultException(string message ) : base(message)
        {
            
        }
    }
}
