
using Interact.Application.Utils;
using Interact.Core.Dto;
using Interact.Core.IRespository;
using Interact.WebApp.Common;
using Interact.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interact.WebApp.Areas.Home.Controllers
{
    /// <summary>
    /// 大屏幕主页控制器（控制每个浏览器只能管理一个活动）
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IActivityRespository _activityRespository;
        public HomeController(IActivityRespository activityRespository)
        {
            _activityRespository = activityRespository;
        }
        // GET: Home/Home
        public ActionResult Index(int activityId)
        {
            var model = AppUtil.GetCurrentUser<ScreenAuthDto>(Application.Enum.TokenTypeEnum.Screen_Auth);
            if (model != null&&model.ActivityId==activityId)
            {
               return RedirectToAction($"/Screen/SigninScreen?activityId={activityId}");
            }
            ViewBag.activityId = activityId;
            
            return View();
        }
        /// <summary>
        /// 授权大屏幕
        /// </summary>
        /// <param name="authCode"></param>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public ActionResult ToAuth(string authCode, int activityId)
        {
            var model = _activityRespository.GetActivityByAuthCodeAndActivityId(authCode, activityId);
            if (model != null)
            {
                AppUtil.ToSigin(Application.Enum.TokenTypeEnum.Screen_Auth, new ScreenAuthDto() { ActivityId = activityId });
            }
            return Json(new DataResult()
            {
                Status = model != null,
                Notify = model != null ? "操作成功" : "活动与授权码不匹配"
            });
        }

    }
}