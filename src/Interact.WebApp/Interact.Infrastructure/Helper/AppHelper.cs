using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Infrastructure.Helper
{
   public class AppHelper
    {
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="payload"></param>
        public static void SignIn<T>(T payload, string tokenName)
        {
            string token = JWTHelper.Set(payload);
            CookieHelper.Set(token, tokenName, TimeSpan.FromHours(1.0));
        }
        /// <summary>
        /// 登出
        /// </summary>
        public static void SignOut(string tokenName)
        {
            CookieHelper.Remove(tokenName);
        }
        /// <summary>
        /// 当前用户信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CurrentUser<T>(string tokenName)
        {
            string token = CookieHelper.Get(tokenName);
            if (string.IsNullOrEmpty(token)) return default(T);
            return JWTHelper.Get<T>(tokenName);
        }
    }
}
