using Interact.Infrastructure.Config.Model;
using Interact.Infrastructure.Wexin;
using Interact.Core.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Interact.WebApp.Filters;
using Interact.Infrastructure.Util;
using Interact.Application.Service;
using Interact.Core.Entity;
using Interact.WebApp.Models;
using Interact.Infrastructure.Config;

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

        #region Weixin-View

        /// <summary>
        /// 签到视图
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public ActionResult Signin(int activityId, string code)
        {
            //1.从本站地址跳转过来
            if (string.IsNullOrEmpty(code))
            {
                string redirectUrl = $"{WebConfig.Web_Host}/Home/SignIn/Signin?activityId={activityId}";
                var authCodeUrl = _weixinRespository.GetAuthCodeUrl(HttpUtility.UrlEncode(redirectUrl));
                return Content("<script>location.href='" + authCodeUrl + "'</script>");
            }
            //2.首次访问
            //2.1.根据code获取access_token+openid
            var weixinAuthAccessTokenResult = _weixinRespository.GetAuthAccessTokenResult(code);
            //2.1.1根据openid+activityId查询参与活动的情况
            var weixinAuthUserInfoResult = _weixinRespository.GetUserInfoByOpennIdAndAccessToken(weixinAuthAccessTokenResult.access_token, weixinAuthAccessTokenResult.openid);
            //2.1.2根据openid获取当前用户签到信息
            var record = _signInService.SignInRecord(activityId, weixinAuthUserInfoResult);
            //2.2.对签到页面做数据展示规划
            ViewBag.DataResult = new
            {
                SignInRecord = record
            };
            return View();
        }

        #endregion

        #region Weixin-Operator

        /// <summary>
        /// token测试
        /// </summary>
        /// <returns></returns>
        public ActionResult Token()
        {

            string echoStr = Request.QueryString["echoStr"].ToString();
            return Content(echoStr);
        }

        /// <summary>
        ///  进行签到
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public ActionResult ToSigin(SignInRecord record)
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

        #endregion

    }
}