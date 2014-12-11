using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AliPay.Authorization
{
    internal class HtmlRender:IRenderable<AlRequestAuthSetting>
    {
        public void Render(HttpResponse writer)
        {
            if (Context != null)
            {
                writer.Write(Context);
            }
            else
            {
                if (Setting != null)
                {
                    var htmlStream = HtmlConstructor.GetHtmlText(Setting);
                    byte[]  buffer = new byte[htmlStream.Length];
                    htmlStream.Read(buffer, 0, (int)htmlStream.Length);
                    writer.Write(Encoding.Default.GetString(buffer));
                }
                else
                {
                    throw new ArgumentNullException(@"Stream 和Setting 至少有一个设置");
                }
            }
        }

        public Stream Context { get; set; }
        public AlRequestAuthSetting Setting { get; set; }
    }
}
