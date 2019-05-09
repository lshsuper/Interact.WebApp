using Interact.Core.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Interact.WebApp.Areas.Admin.Controllers
{
    /// <summary>
    /// 活动管理
    /// </summary>
    public class ActivityController : Controller
    {
        private readonly IActivityRespository _activityRespository;
        public ActivityController(IActivityRespository activityRespository)
        {
            _activityRespository = activityRespository;
        }
        #region View
        /// <summary>
        /// 活动列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Activities()
        {
            return View();
        } 
        #endregion
    }
}