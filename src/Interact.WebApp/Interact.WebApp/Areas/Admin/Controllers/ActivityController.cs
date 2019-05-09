using Interact.Core.Entity;
using Interact.Core.IRespository;
using Interact.Infrastructure.Config;
using Interact.Infrastructure.Config.Model;
using Interact.Infrastructure.Util;
using Interact.WebApp.Models;
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

        #region Operator
        /// <summary>
        /// 添加活动
        /// </summary>
        /// <returns></returns>
        public ActionResult AddActivity(Activity activity)
        {
            activity.AuthCode = Tool.UUID(5);
            activity.CreateTime = DateTime.Now;
            var model = _activityRespository.Insert(DbConfig.DbConnStr,activity);

            return Json(new DataResult() {
                   Status= activity!=null,
                   Notify=activity!=null?"操作成功":"操作失败"
            });
        }
        /// <summary>
        /// 编辑活动
        /// </summary>
        /// <returns></returns>
        public ActionResult ActivityEdit(Activity activity)
        {
            //1.判断签到数量和签到限制数量
            var currentActivity = _activityRespository.Get(DbConfig.DbConnStr,activity.Id);
            if (currentActivity.SignInNumber > activity.LimitNumber)
                return Json(new DataResult() {
                      Status=false,
                      Notify="签到数量不能大于签到限制数量"
                });
            //2.修改
            bool result=_activityRespository.EditActivity(activity);
            return Json(new DataResult()
            {
                Status = activity != null,
                Notify = activity != null ? "操作成功" : "操作失败"
            });
        }
        #endregion
    }
}