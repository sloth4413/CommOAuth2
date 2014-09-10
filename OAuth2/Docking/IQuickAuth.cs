using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth2.Docking
{
    /// <summary>
    /// 快捷授权登录
    /// </summary>
    public interface IQuickAuth
    {
        IUserAuth UserAuth { get; }

        /// <summary>
        /// 以唯一标识快捷登录
        /// </summary>
        /// <param name="openId">用户在第三方网站上的唯一标识</param>
        /// <returns>返回true表示快捷登录成功,否则不成功/没有绑定</returns>
        bool Login(string openId);
    }
}
