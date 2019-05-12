using Interact.Infrastructure.Wexin.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Infrastructure.Wexin
{
    /// <summary>
    /// 微信接口地址构造器
    /// </summary>
    public class WexinApiUrlBuilder
    {
        #region 公众平台
        /// <summary>
        /// 用户基本信息接口
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static string InfoUrl(string access_token, string openid)
        {
            //https://api.weixin.qq.com/cgi-bin/user/info?access_token=ACCESS_TOKEN&openid=OPENID&lang=zh_CN
            return $"https://api.weixin.qq.com/cgi-bin/user/info?access_token={access_token}&openid={openid}&lang=zh_CN";
        }
        /// <summary>
        /// 构建Token接口地址
        /// </summary>
        /// <param name="appkey"></param>
        /// <param name="appsecret"></param>
        /// <returns></returns>
        public static string TokenUrl(string appkey, string appsecret)
        {
            //https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=APPID&secret=APPSECRET
            return $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={appkey}&secret={appsecret}";
        } 
        #endregion

        #region 开发平台
        /// <summary>
        /// 获取Code码接口地址
        /// </summary>
        /// <returns></returns>
        public static string OAuth2_AuthorizeUrl(string appkey, string redirect_uri, ScopeTypeEnum scope,string state ="STATE")
        {
            //https://open.weixin.qq.com/connect/oauth2/authorize?appid=APPID&redirect_uri=REDIRECT_URI&response_type=code&scope=SCOPE&state=STATE#wechat_redirect
            return $"https://open.weixin.qq.com/connect/oauth2/authorize?appid={appkey}&redirect_uri={redirect_uri}&response_type=code&scope={scope.ToString()}&state={state}#wechat_redirect";
        }
        /// <summary>
        /// 过code换取网页授权access_token接口地址
        /// </summary>
        /// <param name="appkey"></param>
        /// <param name="appsecret"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string OAuth2_AccessTokenUrl(string appkey, string appsecret, string code)
        {
            //https://api.weixin.qq.com/sns/oauth2/access_token?appid=APPID&secret=SECRET&code=CODE&grant_type=authorization_code
            return $"https://api.weixin.qq.com/sns/oauth2/access_token?appid={appkey}&secret={appsecret}&code={code}&grant_type=authorization_code";
        }
        /// <summary>
        /// 获取授权用户基本信息
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static string OAuth2_UserinfoUrl(string access_token, string openid)
        {
            //https://api.weixin.qq.com/sns/userinfo?access_token=ACCESS_TOKEN&openid=OPENID&lang=zh_CN
            return $"https://api.weixin.qq.com/sns/userinfo?access_token={access_token}&openid={openid}&lang=zh_CN";
        }
        /// <summary>
        /// 刷新token
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="refresh_token"></param>
        /// <returns></returns>
        public static string Refresh_TokenUrl(string appid,string refresh_token)
        {
            //https://api.weixin.qq.com/sns/oauth2/refresh_token?appid=APPID&grant_type=refresh_token&refresh_token=REFRESH_TOKEN
            return $"https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={appid}&grant_type=refresh_token&refresh_token={refresh_token}";
        }
        #endregion
    }
}
