using Interact.Infrastructure.Config.Model;
using Interact.Infrastructure.Wexin;
using Interact.Core.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Interact.Infrastructure.Util;
using Interact.Application.Service;
using Interact.Core.Entity;
using Interact.WebApp.Models;
using Interact.Infrastructure.Config;
using Interact.Infrastructure.Helper;
using Interact.Application.Utils;
using Interact.Core.Dto;
using Interact.Application.Enum;
using Interact.Infrastructure.Weixin.Model;
using Interact.WebApp.Areas.Admin.Common;

namespace Interact.WebApp.Areas.Home.Controllers
{
    [SignInAuthorizeFilter]
    /// <summary>
    /// 微信签到整体控制栏目
    /// </summary>
    public class SigninController : Controller
    {
        #region Service
        private IWeixinRespository _weixinRespository;
        private ISigInRecordRespository _sigInRecordRespository;
        private IActivityRespository _activityRespository;
        private SignInService _signInService;
        public SigninController(IWeixinRespository weixinRespository,
                                ISigInRecordRespository sigInRecordRespository,
                                SignInService signInService,
                                IActivityRespository activityRespository)
        {
            _weixinRespository = weixinRespository;
            _sigInRecordRespository = sigInRecordRespository;
            _signInService = signInService;
            _activityRespository = activityRespository;
        }
        #endregion

        #region View
        /// <summary>
        /// 统一微信授权入口
        /// </summary>
        /// <param name="code"></param>
        /// <param name="redirectUrl"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult AuthWeChat(string code,string redirectUrl)
        {

            //做一下多余的处理(以后有主页可以去掉)
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(redirectUrl))
                return Content("页面走丢啦~");

            var currentSignInAuth = AppUtil.GetCurrentUser<SignInAuthDto>(TokenTypeEnum.SignIn_Auth);
            if (currentSignInAuth != null)
                return Redirect(redirectUrl);

            //记录登录信息
            WeixinAuthAccessTokenResult weixinAuthAccessTokenResult = _weixinRespository.GetAuthAccessTokenResult(code);
            AppUtil.ToSigin(TokenTypeEnum.SignIn_Auth, new SignInAuthDto()
            {
                RefrashToken = weixinAuthAccessTokenResult.refresh_token,
                Access_Token=weixinAuthAccessTokenResult.access_token,
                OpenId=weixinAuthAccessTokenResult.openid
            });
            return Redirect(redirectUrl);
        }
        /// <summary>
        /// 签到视图
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public ActionResult Signin(int activityId)
        {
            var currentSignInAuth = AppUtil.GetCurrentUser<SignInAuthDto>(TokenTypeEnum.SignIn_Auth);
            var weixinAuthUserInfoResult = _weixinRespository.GetUserInfoByOpennIdAndAccessToken(currentSignInAuth.Access_Token,currentSignInAuth.OpenId);
            var record = _signInService.SignInRecord(activityId, weixinAuthUserInfoResult);
            //获取当前活动数据
            var currentActivity = _activityRespository.Get(DbConfig.DbConnStr,activityId);
            ViewBag.data =JsonHelper.Set(new
            {
                record,
                weixinAuthUserInfoResult,
                activity=currentActivity
            });
            return View();
        }

        #endregion

        #region Operator
        

        /// <summary>
        ///  进行签到
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public ActionResult ToSignin(SignInRecord record)
        {
            //签到
            string notify;
            bool result = _signInService.SignIn(record, out notify);
            if (result)
            {
                //签到上墙
                var model=_sigInRecordRespository.Get(DbConfig.DbConnStr,record.Id);
                ScreenTicker.Instance.SendSignInRecordToClient(model); 
            }
            return Json(new DataResult() {
                Status=result,
                Notify=notify
            });
        }
        /// <summary>
        /// 参与二维码
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult QrCodeForSigin(int activityId)
        {
            ////1.定义签到页面地址
            string siginUrl = $"{WebConfig.Web_Host}/Home/SignIn/Signin?activityId={activityId}";
            //2.生成二维码
            return File(QrCodeHelper.BuildQrCode(siginUrl), "image/jpeg");
        }
        
        #endregion

    }
}