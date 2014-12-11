using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth2.Qzone
{
    public class QzoneRequestAuthSetting:BuilderSetting
    {
        public QzoneRequestAuthSetting(string url) : base(url)
        {
        }

        /// <summary>
        /// 应用ID,在文档中又叫ClientId
        /// </summary>
        public string AppId { get; set; }

        //public string State { get; set; }

        public List<string> Scope { get; set; }
    }
}
