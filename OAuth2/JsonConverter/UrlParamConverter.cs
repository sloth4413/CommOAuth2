using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth2.JsonConverter
{
    public class UrlParamConverter:IJsonConverter
    {
        /// <summary>
        /// 转换形如(client_id=100222222&openid=1704************************878C)到JSON数据
        /// {"client_id":"YOUR_APPID","openid":"YOUR_OPENID"}
        /// </summary>
        /// <param name="rawFormat"></param>
        /// <returns></returns>
        public string Convert(string rawFormat)
        {
            JsonFormatConverter converter = new JsonFormatConverter();

            string[] pairArray = rawFormat.Split(new[] {'&'}, StringSplitOptions.RemoveEmptyEntries);
            if (pairArray.Any())
            {
                foreach (var cell in pairArray)
                {
                    var temporary = cell.Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries);
                    if (temporary.Length==2)
                    {
                        converter.Add(temporary[0],temporary[1]);
                    }
                }
            }
            return converter.ToString();
        }

        class JsonFormatConverter
        {
            private static string Quotes(string raw)
            {
                return "'" + raw + "'";
            }

            private Dictionary<string,string> _keyValuePair = new Dictionary<string, string>();

            public void Add(string key,string value)
            {
                if (!_keyValuePair.ContainsKey(key))
                {
                    _keyValuePair.Add(key,value);
                }
            }

            public override string ToString()
            {
                var format = "{";
                List<string> temporary = new List<string>();
                foreach (var pair in _keyValuePair)
                {
                    temporary.Add(Quotes(pair.Key) + ":" + Quotes(pair.Value));
                }
                return format+ String.Join(",",temporary) + "}";
            }
        }
    }
}
