using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth2
{
    /// <summary>
    /// 该接口表示从任意其他数据格式转换到JSON数据格式
    /// </summary>
    public interface IJsonConverter
    {
        string Convert(string rawFormat);
    }
}
