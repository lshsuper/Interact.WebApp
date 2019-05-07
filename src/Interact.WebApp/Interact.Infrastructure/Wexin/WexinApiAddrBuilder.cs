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
    public class WexinApiAddrBuilder
    {
        #region basic support
        /// <summary>
        /// 用户基本信息接口
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static string UserInfoAddr(string access_token, string openid)
        {
            //https://api.weixin.qq.com/cgi-bin/user/info?access_token=ACCESS_TOKEN&openid=OPENID&lang=zh_CN
            return $"https://api.weixin.qq.com/cgi-bin/user/info?access_token={access_token}&openid={openid}&lang=zh_CN";
        }
        /// <summary>
        /// 构建AccessToken接口地址
        /// </summary>
        /// <param name="appkey"></param>
        /// <param name="appsecret"></param>
        /// <returns></returns>
        public static string AccessTokenAddr(string appkey, string appsecret)
        {
            //https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=APPID&secret=APPSECRET
            return $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={appkey}&secret={appsecret}";
        } 
        #endregion

        #region about authorization
        /// <summary>
        /// 获取Code码接口地址
        /// </summary>
        /// <returns></returns>
        public static string AuthCodeAddr(string appkey, string redirect_uri, AuditScopeTypeEnum scope)
        {
            //https://open.weixin.qq.com/connect/oauth2/authorize?appid=APPID&redirect_uri=REDIRECT_URI&response_type=code&scope=SCOPE&state=STATE#wechat_redirect
            return $"https://open.weixin.qq.com/connect/oauth2/authorize?appid={appkey}&redirect_uri={redirect_uri}&response_type=code&scope={scope.ToString()}&state=STATE#wechat_redirect";
        }
        /// <summary>
        /// 过code换取网页授权access_token接口地址
        /// </summary>
        /// <param name="appkey"></param>
        /// <param name="appsecret"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string AuthAccessTokenAddr(string appkey, string appsecret, string code)
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
        public static string AuthUserInfoAddr(string access_token, string openid)
        {
            //https://api.weixin.qq.com/sns/userinfo?access_token=ACCESS_TOKEN&openid=OPENID&lang=zh_CN
            return $"https://api.weixin.qq.com/sns/userinfo?access_token={access_token}&openid={openid}&lang=zh_CN";
        } 
        #endregion

    }
}
