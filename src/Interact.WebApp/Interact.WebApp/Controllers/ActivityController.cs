using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interact.WebApp.Controllers
{
    /// <summary>
    /// 活动管理控制器
    /// </summary>
    public class ActivityController : Controller
    {
        // GET: ActivityManage
        public ActionResult Index()
        {
            return View();
        }
    }
}