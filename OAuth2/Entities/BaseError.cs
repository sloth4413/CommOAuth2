using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth2.Entities
{
    public abstract class BaseError<TError> where TError:BaseError<TError>,new()
    {
        /// <summary>
        /// 是否没有错误
        /// </summary>
        /// <returns></returns>
        public abstract bool IsSuccess();

        /// <summary>
        /// 是否可以用该错误器处理
        /// </summary>
        /// <param name="jsonTxt"></param>
        /// <returns></returns>
        public abstract bool Has(string jsonTxt);

        public abstract TError ToJson(string jsonTxt);
    }
}
