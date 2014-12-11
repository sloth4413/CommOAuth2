using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using OAuth2.Entities;
using OAuth2.Entities.WeiXin;
using OAuth2.Exceptions;

namespace OAuth2.HttpUtils
{
    public static class Post
    {
        /// <summary>
        /// 获取Post结果
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <typeparam name="TError"></typeparam>
        /// <param name="returnText"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        public static TResponse GetResult<TResponse,TError>(string returnText,IJsonConverter converter=null)
            where TError:BaseError
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            if (returnText.Contains("errcode"))
            {
                //if (converter != null) returnText = converter.Convert(returnText);
                //可能发生错误
                TError errorResult = js.Deserialize<TError>(returnText);
                if (!errorResult.IsSuccess())
                {
                    //发生错误
                    throw new JsonResultException(
                        string.Format("Post请求发生错误！错误信息:{0}",errorResult));
                }
            }
            if (converter != null) returnText = converter.Convert(returnText);
            TResponse result = js.Deserialize<TResponse>(returnText);
            return result;
        }

        /// <summary>
        /// 发起Post请求
        /// </summary>
        /// <typeparam name="TResponse,TError">返回数据类型（Json对应的实体）</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="cookieContainer">CookieContainer，如果不需要则设为null</param>
        /// <returns></returns>
        public static TResponse PostFileGetJson<TResponse, TError>(string url, CookieContainer cookieContainer = null, Dictionary<string, string> fileDictionary = null, Encoding encoding = null, IJsonConverter converter = null)
        where TError:BaseError
        {
            string returnText = RequestUtility.HttpPost(url, cookieContainer, null, fileDictionary, null, encoding);
            var result = GetResult<TResponse,TError>(returnText,converter);
            return result;
        }

        /// <summary>
        /// 发起Post请求
        /// </summary>
        /// <typeparam name="TResponse">返回数据类型（Json对应的实体）</typeparam>
        /// <param name="absoluteUri"></param>
        /// <param name="url">请求Url</param>
        /// <param name="cookieContainer">CookieContainer，如果不需要则设为null</param>
        /// <param name="fileStream">文件流</param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static TResponse PostGetJson<TResponse, TError>(string absoluteUri, string url, CookieContainer cookieContainer = null, Stream fileStream = null, Encoding encoding = null, IJsonConverter converter = null)
        where TError:BaseError
        {
            string returnText = RequestUtility.HttpPost(url, cookieContainer, fileStream, null, null, encoding);
            var result = GetResult<TResponse,TError>(returnText,converter);
            return result;
        }

        public static TResponse PostGetJson<TResponse,TError>(string url, CookieContainer cookieContainer = null, Dictionary<string, string> formData = null, Encoding encoding = null,IJsonConverter converter= null)
        where TError:BaseError
        {
            string returnText = RequestUtility.HttpPost(url, cookieContainer, formData, encoding);
            var result = GetResult<TResponse,TError>(returnText,converter);
            return result;
        }
    }
}
