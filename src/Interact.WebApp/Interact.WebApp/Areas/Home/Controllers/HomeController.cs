
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
            ViewBag.activityId = activityId;

            return View();
        }

        public ActionResult ToAuth(string authCode,int activityId)
        {
            var model = _activityRespository.GetActivityByAuthCodeAndActivityId(authCode,activityId);
            if (model != null)
            {
                AppUtil.ToSigin(Application.Enum.TokenTypeEnum.Screen_Auth,new ScreenAuthDto() { ActivityId=activityId });
            }
                return Json(new DataResult() {
                    Status = model!=null,
                    Notify=model!=null?"操作成功":"活动与授权码不匹配"
                });
        }
        
    }
}