using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using OAuth2.Entities.Sina;

namespace OAuth2.Entities.Qzone
{
    [Serializable]
    public class QzoneErrorResult:BaseError<QzoneErrorResult>
    {
        public override bool IsSuccess()
        {
            return ret == ErrorCode.请求成功;
        }

        public override bool Has(string jsonTxt)
        {
            //腾讯接口设计的多糟糕雅~
            return jsonTxt.Contains("ret") && jsonTxt.Contains("msg") && !jsonTxt.Contains("\"ret\":0");
        }

        public override QzoneErrorResult ToJson(string jsonTxt)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Deserialize<QzoneErrorResult>(jsonTxt);
        }

        public ErrorCode ret { get; set; }

        public string msg { get; set; }
    }
}
