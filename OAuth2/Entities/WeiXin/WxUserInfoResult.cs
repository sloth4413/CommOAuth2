using System;

namespace OAuth2.Entities.WeiXin
{
    /// <summary>
    /// 用户基本信息
    /// </summary>
    [Serializable]
    public class WxUserInfoResult:IResource
    {
        /// <summary>
        /// 用开放唯一身份标识
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string nickname { get; set; }

        /// <summary>
        /// 用户性别
        /// </summary>
        public byte sex { get; set; }

        /// <summary>
        /// 用户省份
        /// </summary>
        public string province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public string country { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string headimgurl { get; set; }

        /// <summary>
        /// 用户特权信息，json 数组，如微信沃卡用户为（chinaunicom）
        /// </summary>
        public string[] privilege { get; set; }
    }
}
