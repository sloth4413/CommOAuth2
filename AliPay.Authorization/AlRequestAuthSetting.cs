using OAuth2;

namespace AliPay.Authorization
{
    /// <summary>
    /// 支付包快捷登录平台认证设置(该平台接口不是采用OAuth2)
    /// </summary>
    public class AlRequestAuthSetting:BuilderSetting
    {
        public AlRequestAuthSetting(string url) : base(url)
        {

        }

        #region 必填字段
        /// <summary>
        /// 合作者身份 必填
        /// </summary>
        public string Partner { get; set; }

        /// <summary>
        /// 商户密钥 必填
        /// </summary>
        public string Key { get; set; }
        #endregion

        /// <summary>
        /// 参数编码字符集 默认
        /// </summary>
        public string InputCharset { get { return "utf-8"; } }

        /// <summary>
        /// 签名方式 MD5 默认
        /// </summary>
        public string SignType { get { return "MD5"; }}

        /// <summary>
        /// 客户端IP 可选
        /// </summary>
        public string ExternInvokeIp { get; set; }

        /// <summary>
        /// 防钓鱼时间戳 可选
        /// </summary>
        public string AntiPhishingKey { get; set; }

        /// <summary>
        /// 页面类型 可选
        /// </summary>
        public string Frame { get; set; }

        /// <summary>
        /// 客户端IP 可选
        /// </summary>
        public string ClientIp { get; set; }
    }
}
