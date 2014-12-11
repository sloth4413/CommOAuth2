using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth2.Entities.Qzone
{
    [Serializable]
    public class QzoneErrorResult:BaseError
    {
        public override bool IsSuccess()
        {
            return ret == ErrorCode.请求成功;
        }

        public ErrorCode ret { get; set; }

        public string msg { get; set; }
    }
}
