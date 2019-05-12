using Interact.Infrastructure.Config.Model;
using Interact.Infrastructure.Http;
using Interact.Infrastructure.Util;
using Interact.Infrastructure.Weixin.Model;
using Interact.Infrastructure.Wexin;
using Interact.Infrastructure.Wexin.Enum;
using Interact.Infrastructure.Wexin.Model;
using Interact.Core.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interact.Infrastructure.Helper;

namespace Interact.Respository
{
    public class WeixinRespository : IWeixinRespository
    {
        public WeixinAuthAccessTokenResult GetAuthAccessTokenResult(string code)
        {
            var url = WexinApiUrlBuilder.OAuth2_AccessTokenUrl(WeChatConfig.AppKey, WeChatConfig.AppSecuret, code);
            string notify, result;
            bool succ = HttpClientHelper.Get(url, out result, out notify);
            if (!succ)
                return null;
            return new WeixinAuthAccessTokenResult()
            {
                access_token = Tool.GetJosnValue(result, "access_token"),
                openid = Tool.GetJosnValue(result, "openid"),
                refresh_token= Tool.GetJosnValue(result, "refresh_token"),
            };
        }

        public string GetAuthCodeUrl(string redirectUrl)
        {
            return WexinApiUrlBuilder.OAuth2_AuthorizeUrl(WeChatConfig.AppKey, redirectUrl, ScopeTypeEnum.snsapi_userinfo);
        }

        public WeixinOAuth2UserInfoResult GetUserInfoByOpennIdAndAccessToken(string access_token, string openId)
        {

            var url = WexinApiUrlBuilder.OAuth2_UserinfoUrl(access_token, openId);
            string notify, result;
            bool succ = HttpClientHelper.Get(url, out result, out notify);
            if (!succ)
                return null;
            string errorCode = Tool.GetJosnValue(result,"errcode");
            if (!string.IsNullOrEmpty(errorCode))
                return null;
            return JsonHelper.Get<WeixinOAuth2UserInfoResult>(result);
        }

        public WeixinAuthAccessTokenResult RefrashAuthAccessTokenResult(string refrash_token)
        {
            var url = WexinApiUrlBuilder.Refresh_TokenUrl(WeChatConfig.AppKey,refrash_token);
            string notify, result;
            bool succ = HttpClientHelper.Get(url, out result, out notify);
            if (!succ)
                return null;
            string errorCode = Tool.GetJosnValue(result, "errcode");
            if (!string.IsNullOrEmpty(errorCode))
                return null;
            return JsonHelper.Get<WeixinAuthAccessTokenResult>(result);
        }
    }
}
