//令牌是用来换取资源信息的凭证,基本上所有快捷登录服务商有令牌的自己实现
//而拥有令牌者就拥有对该资源的完全访问权
namespace OAuth2
{
    /// <summary>
    /// 令牌类型 按照OAUTH的定义可以分为
    /// </summary>
    public enum TokenType
    {
        AuthenticatedAccess,//用户认证后额凭证
        Refrech//刷新凭证,用来再次获取用户认证凭证
    }

    /// <summary>
    /// 用户令牌
    /// </summary>
    public interface IToken
    {
        TokenType Type { get; }

        string Value { get; }
    }

    /// <summary>
    /// 访问令牌
    /// </summary>
    public class AccessToken:IToken
    {
        public AccessToken(string value)
        {
            Value = value;
        }

        public TokenType Type { get{return TokenType.AuthenticatedAccess;}}
        public string Value { get; private set; }

        public override string ToString()
        {
            return Value;
        }
    }

    /// <summary>
    /// 刷新令牌
    /// </summary>
    public class RefrechToken:IToken
    {
        public RefrechToken(string value)
        {
            Value = value;
        }

        public TokenType Type { get{return TokenType.Refrech;}}
        public string Value { get; private set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
