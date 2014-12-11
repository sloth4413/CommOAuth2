using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using OAuth2.Entities;
using OAuth2.Entities.WeiXin;
using OAuth2.Exceptions;

namespace OAuth2.HttpUtils
{
    public static class Get
    {
        public static TResponse GetJson<TResponse,TError>(string url, Encoding encoding = null,IJsonConverter converter=null) 
            where TError:BaseError<TError>,new()
        {
            string returnText = RequestUtility.HttpGet(url, encoding);

            JavaScriptSerializer js = new JavaScriptSerializer();
            TError  errorEng = new TError();
            if (errorEng.Has(returnText))
            {
                //可能发生错误
                TError errorResult = errorEng.ToJson(returnText);//js.Deserialize<TError>(returnText);
                if (!errorResult.IsSuccess())
                {
                    //发生错误
                    throw new JsonResultException(
                        string.Format("请求发生错误！错误代码信息:{0}",errorResult));
                }
            }

            if (null != converter) returnText = converter.Convert(returnText);

            TResponse result = js.Deserialize<TResponse>(returnText);

            return result;
        }

        public static void Download(string url, Stream stream)
        {
            WebClient wc = new WebClient();
            var data = wc.DownloadData(url);
            foreach (var b in data)
            {
                stream.WriteByte(b);
            }
        }
    }
}
