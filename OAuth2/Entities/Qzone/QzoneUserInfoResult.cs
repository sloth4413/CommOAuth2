using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth2.Entities.Qzone
{
    [Serializable]
    public class QzoneUserInfoResult:IResource
    {
        public string ret { get; set; }

        public string msg { get; set; }

        public string nickname { get; set; }

        public string figureurl { get; set; }

        public string figureurl_1 { get; set; }

        public string figureurl_2 { get; set; }

        public string figureurl_qq_1 { get; set; }

        public string figureurl_qq_2 { get; set; }

        public string gender { get; set; }

        public byte is_yellow_vip { get; set; }

        public byte vip { get; set; }

        public int yellow_vip_level { get; set; }

        public int level { get; set; }

        public byte is_yellow_year_vip { get; set; }
    }
}
