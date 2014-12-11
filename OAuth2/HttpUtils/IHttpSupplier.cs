using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAuth2.Entities;

namespace OAuth2.HttpUtils
{
    public interface IHttpSupplier
    {
        TResponse Get<TResponse,TError>(Uri uri,IJsonConverter converter=null) where TError:BaseError;

        TResponse Post<TResponse,TError>(Uri uri,IJsonConverter converter=null) where  TError:BaseError;
    }

    public class HttpSuppplier:IHttpSupplier
    {
        TResponse IHttpSupplier.Get<TResponse, TError>(Uri uri, IJsonConverter converter=null)
        {
            return Get.GetJson<TResponse,TError>(uri.AbsoluteUri,null,converter);
        }

        TResponse IHttpSupplier.Post<TResponse, TError>(Uri uri, IJsonConverter converter=null)
        {
            return Post.PostGetJson<TResponse,TError>(uri.AbsoluteUri, null, null, null,converter);
        }
    }
}
