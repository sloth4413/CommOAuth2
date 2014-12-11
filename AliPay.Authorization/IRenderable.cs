using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AliPay.Authorization
{
    /// <summary>
    /// 渲染到页面能力接口
    /// </summary>
    public interface IRenderable<TSetting>
    {
        /// <summary>
        /// 在输出器中渲染内容
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="setting"></param>
        void Render(HttpResponse    writer);

        /// <summary>
        /// 渲染内容流
        /// </summary>
        Stream Context { get; set; }

        /// <summary>
        /// 渲染内容设置
        /// </summary>
        TSetting Setting { get; set; }
    }
}
