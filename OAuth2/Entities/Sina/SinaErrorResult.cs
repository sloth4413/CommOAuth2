using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth2.Entities.Sina
{
    [Serializable]
    public class SinaErrorResult:BaseError
    {
        public override bool IsSuccess()
        {
            return error_code == ErrorCode.请求成功;
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
