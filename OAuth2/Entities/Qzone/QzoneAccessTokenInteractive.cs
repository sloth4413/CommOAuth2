using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth2.Entities.Qzone
{
    [Serializable]
    public class QzoneAccessTokenInteractive
    {
        public string access_token { get; set; }

        public string expires_in { get; set; }
    }
}
