using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Infrastructure.Wexin
{
    public class WexinApiHelper
    {
        /// <summary>
        /// 用户基本信息接口
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static string UserInfoAddr(string access_token,string openid)
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
        public static string AccessTokenAddr(string appkey,string appsecret)
        {
            //https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=APPID&secret=APPSECRET
            return $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&{appkey}=APPID&secret={appsecret}";
        }
    }
}
