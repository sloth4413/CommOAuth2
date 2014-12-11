using System;
using System.Web.Script.Serialization;

namespace OAuth2.Entities.WeiXin
{
    [Serializable]
    public class WxErrorResult:BaseError<WxErrorResult>
    {
       public ErrorCode errcode { get; set; }

       public string errmsg { get; set; }
        public override bool IsSuccess()
        {
            return errcode == ErrorCode.请求成功;
        }

        public override bool Has(string jsonTxt)
        {
            return jsonTxt.Contains("errcode");
        }

        public override WxErrorResult ToJson(string jsonTxt)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Deserialize<WxErrorResult>(jsonTxt);
        }

        public override string ToString()
        {
            return errmsg;
        }
    }
}
