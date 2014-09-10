using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth2.Docking
{
    /// <summary>
    /// 用户登录授权
    /// </summary>
    public interface IUserAuth
    {
        /// <summary>
        /// 以用户名和密码登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns>返回true表示登录成功,返回false表示不成功</returns>
        bool Login(string userName, string userPassword);
    }
}
