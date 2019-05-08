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

namespace Interact.WebApp.Controllers
{
    /// <summary>
    /// 微信签到整体控制栏目
    /// </summary>
    public class SigninController : Controller
    {
        #region Weixin-Service
        private IWeixinRespository _weixinRespository;
        public SigninController(IWeixinRespository weixinRespository)
        {
            _weixinRespository = weixinRespository;
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
            ////1.从微信地址跳转过来
            //if (!string.IsNullOrEmpty(code))
            //{
            //    string redirectUrl = $"{WebConfig.Web_Host}/Weixin/Sigin?activityId={activityId}";
            //    var authCodeUrl = _weixinRespository.GetAuthCodeUrl(redirectUrl);
            //    return Content("<script>location.href='" + authCodeUrl + "'</script>");
            //}
            ////2.首次访问
            ////2.1.根据code获取access_token+openid
            //var weixinAuthAccessTokenResult = _weixinRespository.GetAuthAccessTokenResult(code);
            ////2.1.1根据openid+activityId查询参与活动的情况
            //var weixinAuthUserInfoResult = _weixinRespository.GetUserInfoByOpennIdAndAccessToken(weixinAuthAccessTokenResult.access_token,weixinAuthAccessTokenResult.openid);
            ////2.1.2根据openid获取当前用户信息
            ////2.2.对签到页面做数据展示规划
            
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
        /// 进行签到
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="openId"></param>
        /// <returns></returns>
        public ActionResult ToSigin(int activityId, string openId)
        {
            //1.根据openid+activityid判断当前用户的签到情况（控制不可重复签到）
            return Json("ok");
        }
        /// <summary>
        /// 参与二维码
        /// </summary>
        /// <returns></returns>
        public ActionResult QrCodeForSigin(int activityId)
        {
            ////1.定义签到页面地址
            string siginUrl = $"{WebConfig.Web_Host}/Weixin/Sigin?activityId={activityId}";
            //2.生成二维码
            return File(QrCodeHelper.BuildQrCode(siginUrl), "image/jpeg");
        }

        #endregion

    }
}