using System;

namespace OAuth2.Entities.WeiXin
{
    [Serializable]
    public class WxErrorResult:BaseError
    {
       public ErrorCode errcode { get; set; }

       public string errmsg { get; set; }
        public override bool IsSuccess()
        {
            return errcode == ErrorCode.请求成功;
        }

        public override string ToString()
        {
            return errmsg;
        }
    }
}
