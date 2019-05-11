using Interact.Application.Enum;
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
        /// token名称(后台登录)
        /// </summary>
        private const string adminTokenName = "interact.admin.auth";
        /// <summary>
        /// token名称(大屏幕授权展示)
        /// </summary>
        private const string homeScreenTokenName = "interact.home.auth";
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="tokenType"></param>
        public   void ToSigin<T>(TokenTypeEnum tokenType,T payload)
        {
            switch (tokenType)
            {
                case TokenTypeEnum.Admin_Login:
                    AppHelper.SignIn(payload,adminTokenName);
                    break;
                case TokenTypeEnum.Screen_Auth:
                    AppHelper.SignIn(payload, homeScreenTokenName);
                    break;
                default:
                    throw new ApplicationException("不存在此类型的token");
                  
            }

        }
        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="tokenType"></param>
        public  void ToSignOut<T>(TokenTypeEnum tokenType)
        {
            switch (tokenType)
            {
                case TokenTypeEnum.Admin_Login:
                    AppHelper.SignOut(adminTokenName);
                    break;
                case TokenTypeEnum.Screen_Auth:
                    AppHelper.SignOut(homeScreenTokenName);
                    break;
                default:
                    throw new ApplicationException("不存在此类型的token");

            }

        }
        public  T GetCurrentUser<T>(TokenTypeEnum tokenType)
        {
            switch (tokenType)
            {
                case TokenTypeEnum.Admin_Login:
                   return  AppHelper.CurrentUser<T>(adminTokenName);
                case TokenTypeEnum.Screen_Auth:
                   return AppHelper.CurrentUser<T>(homeScreenTokenName);
                default:
                    throw new ApplicationException("不存在此类型的token");

            }
        }
    }
}
