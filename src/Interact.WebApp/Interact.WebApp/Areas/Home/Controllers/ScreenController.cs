﻿using Interact.Application.Service;
using Interact.Core.Entity;
using Interact.Core.Enum;
using Interact.Core.IRespository;
using Interact.Infrastructure.Config;
using Interact.Infrastructure.Helper;
using Interact.WebApp.Areas.Admin.Common;
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
    /// 大屏幕主控制器
    /// </summary>
    [ScreenAuthorizeFilter]
    public class ScreenController : Controller
    {
        private ISigInRecordRespository _sigInRecordRespository;
        private LotteryDrawService _lotteryDrawService;
        private IWinnerMenuRespository _winnerMenuRespository;
        public ScreenController(ISigInRecordRespository sigInRecordRespository,
                                LotteryDrawService lotteryDrawService,
                                IWinnerMenuRespository winnerMenuRespository)
        {
            _sigInRecordRespository = sigInRecordRespository;
            _lotteryDrawService = lotteryDrawService;
            _winnerMenuRespository = winnerMenuRespository;
        }

        #region View
        /// <summary>
        /// 抽奖大屏幕
        /// </summary>
        /// <returns></returns>
        public ActionResult LuckyDrawScreen(int activityId)
        {
            //这里是随机获取100条签到数据进行抽奖，可根据具体业务场景进行设置
            var record = _sigInRecordRespository.GetSignInRecordsWithoutAwards(100,activityId);
            ViewBag.data = JsonHelper.Set(new {
                activityId,
                record
            });
            return View();
        }
        /// <summary>
        /// 签到大屏幕
        /// </summary>
        /// <returns></returns>
        public ActionResult SignInScreen(int activityId)
        {
            var record = _sigInRecordRespository.GetSignInRecordsByActivityId(activityId);
            ViewBag.data = JsonHelper.Set(new
            {
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
        /// <summary>
        /// 随机抽奖
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="number"></param>
        /// <param name="winnerLevel"></param>
        /// <returns></returns>
        public ActionResult LotteryDraw(int activityId, int number, WinnerLevelEnum winnerLevel)
        {
            string notofy;
            List<SignInRecord> signInRecords;
            bool result = _lotteryDrawService.LotteryDraw(activityId, number, winnerLevel, out notofy, out signInRecords);
            return Json(new DataResult()
            {
                Status = result,
                Data = signInRecords,
                Notify = notofy
            });
        }
        public ActionResult RefrashWinnerMenu(int activityId) {
            bool result = _winnerMenuRespository.RemoveAllByActivity(activityId);

            return Json(new DataResult() {
                Status =result,
                Notify =result?"移除成功":"移除失败"
            });
        }
        #endregion
    }
}