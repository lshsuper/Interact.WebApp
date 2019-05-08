using Interact.Core.IRespository;
using Interact.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Application.Utils
{
    /// <summary>
    /// 应用上下文工具
    /// </summary>
    public class AppUtil
    {
        /// <summary>
        /// token名称
        /// </summary>
        private const string tokenName = "interact.auth";
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="payload"></param>
        public static void SignIn(Dictionary<string, object> payload)
        {
            string token = JWTHelper.Set(payload);
            CookieHelper.Set(token, tokenName, TimeSpan.FromHours(1.0));
        }
        /// <summary>
        /// 登出
        /// </summary>
        public static void SignOut()
        {
            CookieHelper.Remove(tokenName);
        }
        /// <summary>
        /// 当前用户信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CurrentUser<T>()
        {
            string token = CookieHelper.Get(tokenName);
            return JWTHelper.Get<T>(tokenName);
        }
        /// <summary>
        /// 刷新登录
        /// </summary>
        /// <param name="payload"></param>
        public static void RefreshSignIn(Dictionary<string, object> payload)
        {
            CookieHelper.Remove(tokenName);
            SignIn(payload);
        }
    }
}
