using Interact.Core.Entity;
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
        private readonly IActivityAwardRespository _activityAwardRespository;
        public ActivityController(IActivityRespository activityRespository,
                                  IActivityAwardRespository activityAwardRespository)
        {
            _activityRespository = activityRespository;
            _activityAwardRespository = activityAwardRespository;
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
        public ActionResult AddActivityOperator(Activity activity, List<ActivityAward> activityAwards)
        {
            bool result;
            if (activity.Id <= 0)
            {
                result = _activityRespository.AddActivity(activity, activityAwards);
                return Json(new DataResult()
                {
                    Status = result,
                    Notify = result ? "操作成功" : "操作失败"
                });
            }
            //1.判断签到数量和签到限制数量
            var currentActivity = _activityRespository.Get(DbConfig.DbConnStr, activity.Id);
            if (currentActivity.SignInNumber > activity.LimitNumber)
                return Json(new DataResult()
                {
                    Status = false,
                    Notify = "签到数量不能大于签到限制数量"
                });
            //2.修改
            result = _activityRespository.EditActivity(activity, activityAwards);
            return Json(new DataResult()
            {
                Status = activity != null,
                Notify = activity != null ? "操作成功" : "操作失败"
            });
        }
        /// <summary>
        /// 查询活动基本信息
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public ActionResult GetActivityDetail(int activityId)
        {
            var activity = _activityRespository.Get(DbConfig.DbConnStr,activityId);
            var awards = _activityAwardRespository.GetActivityAwardsByActivityId(activityId);
            return Json(new DataResult() {

                Status=true,
                Data =new {
                    activity,
                    awards
                },

            });
        }
        #endregion
    }
}