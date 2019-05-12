﻿using Interact.Core.Entity;
using Interact.Core.IRespository;
using Interact.Core.Option;
using Interact.Infrastructure.Config;
using Interact.Infrastructure.Config.Model;
using Interact.Infrastructure.Util;
using Interact.WebApp.Areas.Admin.Common;
using Interact.WebApp.Common;
using Interact.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Interact.WebApp.Areas.Admin.Controllers
{
    [AdminAuthorizeFilter]
    /// <summary>
    /// 活动管理
    /// </summary>
    public class ActivityController : BaseController
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
        /// <summary>
        /// 添加or编辑活动
        /// </summary>
        /// <returns></returns>
        public ActionResult OpeartorActivities()
        {
            return View();
        }
        #endregion

        #region Operator
        /// <summary>
        /// 搜索活动
        /// </summary>
        /// <returns></returns>
        public ActionResult SearchActivities(ActivityPageOption option)
        {
            var data = _activityRespository.QueryActivityByPage(option);
            return Json(new DataResult()
            {
                Data = data,
                Status = true,
                Notify = "获取成功"
            });
           // return Json(new { total=data.DataCount,rows=data.DataSource});
        }
        /// <summary>
        /// 添加活动
        /// </summary>
        /// <returns></returns>
        public ActionResult AddActivity(Activity activity, List<ActivityAward> activityAwards)
        {
            bool result = _activityRespository.AddActivity(activity,activityAwards);
            return Json(new DataResult() {
                   Status= activity!=null,
                   Notify=activity!=null?"操作成功":"操作失败"
            });
        }
        /// <summary>
        /// 编辑活动
        /// </summary>
        /// <returns></returns>
        public ActionResult ActivityEdit(Activity activity,List<ActivityAward>activityAwards)
        {
            //1.判断签到数量和签到限制数量
            var currentActivity = _activityRespository.Get(DbConfig.DbConnStr,activity.Id);
            if (currentActivity.SignInNumber > activity.LimitNumber)
                return Json(new DataResult() {
                      Status=false,
                      Notify="签到数量不能大于签到限制数量"
                });
            //2.修改
            bool result=_activityRespository.EditActivity(activity,activityAwards);
            return Json(new DataResult()
            {
                Status = activity != null,
                Notify = activity != null ? "操作成功" : "操作失败"
            });
        }
        #endregion
    }
}