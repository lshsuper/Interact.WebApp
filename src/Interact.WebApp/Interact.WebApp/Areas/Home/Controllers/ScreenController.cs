using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interact.WebApp.Areas.Home.Controllers
{
    public class ScreenController : Controller
    {
        #region View
        /// <summary>
        /// 抽奖大屏幕
        /// </summary>
        /// <returns></returns>
        public ActionResult LuckyDrawScreen()
        {
            return View();
        }
        /// <summary>
        /// 签到大屏幕
        /// </summary>
        /// <returns></returns>
        public ActionResult SignInScreen()
        {
            return View();
        }
        #endregion

    }
}