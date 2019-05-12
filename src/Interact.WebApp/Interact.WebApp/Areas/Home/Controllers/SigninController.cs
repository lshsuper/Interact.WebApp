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

namespace Interact.WebApp.Areas.Home.Controllers
{
    /// <summary>
    /// 微信签到整体控制栏目
    /// </summary>
    public class SigninController : Controller
    {
        #region Weixin-Service
        private IWeixinRespository _weixinRespository;
        private ISigInRecordRespository _sigInRecordRespository;
        private SignInService _signInService;
        public SigninController(IWeixinRespository weixinRespository,
                                ISigInRecordRespository sigInRecordRespository,
                                SignInService signInService)
        {
            _weixinRespository = weixinRespository;
            _sigInRecordRespository = sigInRecordRespository;
            _signInService = signInService;
        }
        #endregion

        #region View

        /// <summary>
        /// 签到视图
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public ActionResult Signin(int activityId, string code,string refrashToken)
        {
            //1.从二维码扫码跳转过来
            if (string.IsNullOrEmpty(code))
            {
                string redirectUrl = $"{WebConfig.Web_Host}/Home/SignIn/Signin?activityId={activityId}";
                var authCodeUrl = _weixinRespository.GetAuthCodeUrl(HttpUtility.UrlEncode(redirectUrl));
                return Content("<script>location.href='" + authCodeUrl + "'</script>");
            }
            //2.从微信重定向到该页面
            WeixinAuthAccessTokenResult weixinAuthAccessTokenResult;
            var currentSignInAuth = AppUtil.GetCurrentUser<SignInAuthDto>(TokenTypeEnum.SignIn_Auth);
            if (currentSignInAuth!= null)
            {
                weixinAuthAccessTokenResult = _weixinRespository.RefrashAuthAccessTokenResult(currentSignInAuth.RefrashToken);
            }
            else
            {
                weixinAuthAccessTokenResult = _weixinRespository.GetAuthAccessTokenResult(code);

            }
            var weixinAuthUserInfoResult = _weixinRespository.GetUserInfoByOpennIdAndAccessToken(weixinAuthAccessTokenResult.access_token, weixinAuthAccessTokenResult.openid);

            if (weixinAuthUserInfoResult == null)
            {
                return Content("页面失效");
            }

            var record = _signInService.SignInRecord(activityId, weixinAuthUserInfoResult);
           
            
            if (currentSignInAuth == null)
            {
                AppUtil.ToSigin(TokenTypeEnum.SignIn_Auth,new  SignInAuthDto(){
                    RefrashToken = weixinAuthAccessTokenResult.refresh_token
                });
            }
           
            ViewBag.data =JsonHelper.Set(new
            {
                record,
                weixinAuthUserInfoResult,
                activityId
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
        public ActionResult QrCodeForSigin(int activityId)
        {
            ////1.定义签到页面地址
            string siginUrl = $"{WebConfig.Web_Host}/Home/SignIn/Signin?activityId={activityId}";
            //2.生成二维码
            return File(QrCodeHelper.BuildQrCode(siginUrl), "image/jpeg");
        }
        /// <summary>
        /// 获取签到数据的头像列表
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public ActionResult GetHeadImages(int activityId)
        {
            var model = _sigInRecordRespository.GetSignInHeadImages(activityId);
            return Json(new DataResult() {
                Status=true,Data=model,
                Notify="获取成功"
            });
        }
        #endregion

    }
}