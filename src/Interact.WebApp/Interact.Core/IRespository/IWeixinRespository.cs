using Interact.Infrastructure.Weixin.Model;
using Interact.Infrastructure.Wexin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Core.IRespository
{
   public interface IWeixinRespository
    {
        /// <summary>
        /// 获取授权AccessToken
        /// </summary>
        /// <returns></returns>
        WeixinAuthAccessTokenResult GetAuthAccessTokenResult(string code);
        /// <summary>
        /// 获取授权码请求地址
        /// </summary>
        /// <param name="redirectUrl"></param>
        /// <returns></returns>
        string GetAuthCodeUrl(string redirectUrl);
        /// <summary>
        /// 根据openId获取微信用户信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        WeixinUserInfoResult GetUserInfoByOpennIdAndAccessToken(string access_token,string openId);
    }
}
