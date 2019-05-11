using Interact.Infrastructure.Config.Model;
using Interact.Infrastructure.Helper.Model;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Infrastructure.Helper
{

    /// <summary>
    /// JWT帮助类
    /// </summary>
    public class JWTHelper
    {
        /// <summary>
        /// 生成JwtToken
        /// </summary>
        /// <param name="payload">不敏感的用户数据</param>
        /// <returns></returns>
        public static string Set(JwtPaylod payload,TimeSpan timeSpan)
        {

            //格式如下
            //var payload = new Dictionary<string, object>
            //{
            //    { "username","admin" },
            //    { "pwd", "claim2-value" }
            //};
            payload.exp = Expires(timeSpan);
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(payload, WebConfig.JWT_Secret);
            return token;
        }
        private static double Expires(TimeSpan timeSpan)
        {
            IDateTimeProvider provider = new UtcDateTimeProvider();
            var now = provider.GetNow();

            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // or use JwtValidator.UnixEpoch
            var secondsSinceEpoch = Math.Round((now.Add(timeSpan)-unixEpoch).TotalSeconds);
            return secondsSinceEpoch;
        }
        /// <summary>
        /// 根据jwtToken  获取实体
        /// </summary>
        /// <param name="token">jwtToken</param>
        /// <returns></returns>
        public static T Get<T>(string token)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
                var userInfo = decoder.DecodeToObject<T>(token, WebConfig.JWT_Secret, verify: true);//token为之前生成的字符串
                return userInfo;
            }
            catch (Exception ex)
            {
                return default(T);
                
            }
            
        }
    }
}
