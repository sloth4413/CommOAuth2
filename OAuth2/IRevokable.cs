using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth2
{
    /// <summary>
    /// 有些OAUTH2 提供商是有实现撤销功能的,有些没有，但是都可以通过Token
    /// 的过期时间来控制
    /// </summary>
    public interface IRevokable
    {
        void Revoke();
    }
}
