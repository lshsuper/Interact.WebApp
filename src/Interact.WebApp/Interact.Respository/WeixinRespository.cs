﻿using Interact.Infrastructure.Config.Model;
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

namespace Interact.Respository
{
    public class WeixinRespository : IWeixinRespository
    {
        public WeixinAuthAccessTokenResult GetAuthAccessTokenResult(string code)
        {
            var url = WexinApiUrlBuilder.OAuth2_AccessTokenUrl(WeixinConfig.AppKey, WeixinConfig.AppSecuret, code);
            string notify, result;
            bool succ = HttpClientHelper.Get(url, out result, out notify);
            if (!succ)
                return null;
            return new WeixinAuthAccessTokenResult()
            {
                access_token = Tool.GetJosnValue(result, "access_token"),
                openid = Tool.GetJosnValue(result, "openid")
            };
        }

        public string GetAuthCodeUrl(string redirectUrl)
        {
            return WexinApiUrlBuilder.OAuth2_AuthorizeUrl(WeixinConfig.AppKey, redirectUrl, ScopeTypeEnum.snsapi_userinfo);
        }

        public WeixinUserInfoResult GetUserInfoByOpennIdAndAccessToken(string access_token, string openId)
        {

            var url = WexinApiUrlBuilder.OAuth2_UserinfoUrl(access_token, openId);
            string notify, result;
            bool succ = HttpClientHelper.Get(url, out result, out notify);
            if (!succ)
                return null;
            return new WeixinUserInfoResult()
            {
                openid = Tool.GetJosnValue(result, "openid"),
                unionid = Tool.GetJosnValue(result, "unionid"),
                nickname = Tool.GetJosnValue(result, "nickname"),
                sex = Tool.GetJosnValue(result, "sex"),
                province = Tool.GetJosnValue(result, "province"),
                city = Tool.GetJosnValue(result, "city"),
                country = Tool.GetJosnValue(result, "country"),
                headimgurl = Tool.GetJosnValue(result, "headimgurl"),

            };
        }
    }
}
