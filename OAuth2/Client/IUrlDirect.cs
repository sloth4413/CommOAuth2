using System.Web;

namespace OAuth2.Client
{
    /// <summary>
    /// 引导客户端重定向 
    /// 该接口适合不采用模拟的方式,而是引导用户
    /// </summary>
    public interface IUrlDirect
    {
        void Direct(HttpResponse response);

        string Url { get;set; }
    }
}
