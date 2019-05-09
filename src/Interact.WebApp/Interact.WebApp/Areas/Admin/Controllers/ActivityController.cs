using Interact.Core.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interact.WebApp.Areas.Admin.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityRespository _activityRespository;
        public ActivityController(IActivityRespository activityRespository)
        {
            _activityRespository = activityRespository;
        }
        // GET: Admin/Activity
        public ActionResult Index()
        {

            return View();
        }
    }
}