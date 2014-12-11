using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth2.Qzone
{
    public class QzoneRequestResSetting:BuilderSetting
    {
        public QzoneRequestResSetting(string url) : base(url)
        {

        }

        public string GrantType { get; set; }

        public string AppId { get; set; }

        public string AppSecret { get; set; }

        public string Code { get; set; }
    }
}
