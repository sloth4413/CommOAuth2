using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth2.Entities.Qzone
{
    [Serializable]
    public class QzoneOpenIdResult
    {
        public string client_id { get; set; }

        public string openid { get; set; }
    }
}
