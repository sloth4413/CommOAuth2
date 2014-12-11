using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth2.JsonConverter
{
    public class CallbackConverter:IJsonConverter
    {
        /// <summary>
        /// 转换形如 callback( {"client_id":"YOUR_APPID","openid":"YOUR_OPENID"} ); 到JSON字串
        /// </summary>
        /// <param name="rawFormat"></param>
        /// <returns></returns>
        public string Convert(string rawFormat)
        {
            return SubString(rawFormat, "{", "}");
        }

        private static string SubString(string raw,string startTag,string endTag)
        {
            int startIndex = raw.IndexOf(startTag, System.StringComparison.Ordinal);
            int endIndex = raw.LastIndexOf(endTag, System.StringComparison.Ordinal);
            if (startIndex != -1 && endIndex != -1)
            {
                return raw.Substring(startIndex, endIndex - startIndex+1);
            }
            return raw;
        }
    }
}
