using Interact.Core.IRespository;
using Interact.Infrastructure.Config;
using Interact.Infrastructure.Helper;
using Interact.WebApp.Areas.Admin.Common;
using Interact.WebApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interact.WebApp.Areas.Home.Controllers
{
    [HomeAuthorizeFilter]
    public class ScreenController : Controller
    {
        private ISigInRecordRespository _sigInRecordRespository;
        public ScreenController(ISigInRecordRespository sigInRecordRespository)
        {
            _sigInRecordRespository = sigInRecordRespository;
        }
        #region View
        /// <summary>
        /// 抽奖大屏幕
        /// </summary>
        /// <returns></returns>
        public ActionResult LuckyDrawScreen(int activityId)
        {
            ViewBag.activityId = activityId;
            return View();
        }
        /// <summary>
        /// 签到大屏幕
        /// </summary>
        /// <returns></returns>
        public ActionResult SignInScreen(int activityId)
        {
            var record = _sigInRecordRespository.GetSignInRecordsByActivityId(activityId);
            ViewBag.data =JsonHelper.Set(new {
                activityId,
                record
            });
            return View();
        }
        /// <summary>
        /// 3d抽奖
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public ActionResult CoolLuckyDrawScreen(int activityId)
        {
            ViewBag.activityId = activityId;
            return View();
        }
        #endregion

        #region Operator

        #endregion
    }
}