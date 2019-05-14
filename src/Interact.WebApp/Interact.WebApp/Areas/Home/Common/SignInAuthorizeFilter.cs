using Interact.Application.Utils;
using Interact.WebApp.App_Start;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Interact.Core.Dto;
using System.Text;
using Interact.Core.IRespository;
using Autofac;
using Interact.WebApp.Areas.Home;
using Interact.Infrastructure.Config.Model;
using Interact.WebApp.Models;

namespace Interact.WebApp.Areas.Admin.Common
{
    /// <summary>
    /// 签到授权拦截器
    /// </summary>
    public class SignInAuthorizeFilter : AuthorizeAttribute
    {

        private readonly IWeixinRespository _weixinRespository;
        public SignInAuthorizeFilter()
        {
            _weixinRespository = AutofacConfig._container.Resolve<IWeixinRespository>();
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                base.OnAuthorization(filterContext);
                return;
            }
            //这里我想限制一下只能手机端微信登录(暂时不想实现)

            var currentUser = AppUtil.GetCurrentUser<SignInAuthDto>(Application.Enum.TokenTypeEnum.SignIn_Auth);
            if (currentUser == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult() { Data=new DataResult() {Status=false,Notify="登录失效,请尝试刷新页面" } };
                    return;
                }
                else
                {
                    //当前请求的地址
                    string requestUrl = filterContext.HttpContext.Request.RawUrl;
                    //微信登录
                    string redirectUrl = HttpUtility.UrlEncode($"{WebConfig.Web_Host}/Home/Signin/AuthWeChat?redirectUrl={requestUrl}");
                    string authCodeUrl = _weixinRespository.GetAuthCodeUrl(redirectUrl);
                    filterContext.Result = new ContentResult() { Content = "<script>location.href='" + authCodeUrl + "'</script>" };
                    return;
                }
                

            }

        }
    }
}