using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using OAuth2.Entities.WeiXin;

namespace OAuth2.Entities.Sina
{
    [Serializable]
    public class SinaErrorResult:BaseError<SinaErrorResult>
    {
        public override bool IsSuccess()
        {
            return error_code == ErrorCode.请求成功;
        }

        public override bool Has(string jsonTxt)
        {
            return jsonTxt.Contains("error_code");
        }

        public override SinaErrorResult ToJson(string jsonTxt)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Deserialize<SinaErrorResult>(jsonTxt);
        }

        public ErrorCode error_code { get; set; }

        public string error { get; set; }

        public string error_description { get; set; }

        /// <summary>
        /// 在客户端中开启 
        /// </summary>
        [NonSerialized] public string error_url;
    }
}
