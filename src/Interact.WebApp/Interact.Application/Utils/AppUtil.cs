using Interact.Application.Enum;
using Interact.Application.Service;
using Interact.Core.IRespository;
using Interact.Infrastructure.Helper;
using Interact.Infrastructure.Helper.Model;
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
        #region Token-Name
        /// <summary>
        /// token名称(后台登录)
        /// </summary>
        private const string adminTokenName = "interact.admin.auth";
        /// <summary>
        /// token名称(大屏幕授权展示)
        /// </summary>
        private const string homeScreenTokenName = "interact.home.auth";
        /// <summary>
        /// 签到授权token
        /// </summary>
        private const string homeSignInTokenName = "interact.home.signin.auth"; 
        #endregion

        #region Token-TimeSpan
        /// <summary>
        /// 过期时间-admin
        /// </summary>
        private readonly static TimeSpan tokenTimeSpanForAdmin = TimeSpan.FromDays(1);
        /// <summary>
        /// 过期时间-homescreen
        /// </summary>
        private readonly static TimeSpan tokenTimeSpanForHomeScreen = TimeSpan.FromDays(1);
        // <summary>
        /// 过期时间-homesignin
        /// </summary>
        private readonly static TimeSpan tokenTimeSpanForHomeSignIn = TimeSpan.FromDays(1.5);
        #endregion

        #region Token-Service

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="tokenType"></param>
        public static void ToSigin(TokenTypeEnum tokenType, JwtPaylod payload)
        {
            switch (tokenType)
            {
                case TokenTypeEnum.Admin_Login:
                    AppHelper.SignIn(payload, adminTokenName, tokenTimeSpanForAdmin);
                    break;
                case TokenTypeEnum.Screen_Auth:
                    AppHelper.SignIn(payload, homeScreenTokenName, tokenTimeSpanForHomeScreen);
                    break;
                case TokenTypeEnum.SignIn_Auth:
                    AppHelper.SignIn(payload, homeSignInTokenName, tokenTimeSpanForHomeSignIn);
                    break;
                default:
                    throw new ApplicationException("不存在此类型的token");

            }

        }
        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="tokenType"></param>
        public static void ToSignOut(TokenTypeEnum tokenType)
        {
            switch (tokenType)
            {
                case TokenTypeEnum.Admin_Login:
                    AppHelper.SignOut(adminTokenName);
                    break;
                case TokenTypeEnum.Screen_Auth:
                    AppHelper.SignOut(homeScreenTokenName);
                    break;
                case TokenTypeEnum.SignIn_Auth:
                    AppHelper.SignOut(homeSignInTokenName);
                    break;
                default:
                    throw new ApplicationException("不存在此类型的token");

            }

        }
        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tokenType"></param>
        /// <returns></returns>
        public static T GetCurrentUser<T>(TokenTypeEnum tokenType)
        {
            switch (tokenType)
            {
                case TokenTypeEnum.Admin_Login:
                    return AppHelper.CurrentUser<T>(adminTokenName);
                case TokenTypeEnum.Screen_Auth:
                    return AppHelper.CurrentUser<T>(homeScreenTokenName);
                case TokenTypeEnum.SignIn_Auth:
                    return AppHelper.CurrentUser<T>(homeSignInTokenName);
                default:
                    throw new ApplicationException("不存在此类型的token");

            }
        } 
        #endregion
    }
}
