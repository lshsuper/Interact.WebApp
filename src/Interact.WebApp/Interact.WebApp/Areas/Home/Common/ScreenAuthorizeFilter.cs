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
using Interact.WebApp.Models;

namespace Interact.WebApp.Areas.Admin.Common
{
    /// <summary>
    /// 大屏幕授权拦截器
    /// </summary>
    public class ScreenAuthorizeFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                base.OnAuthorization(filterContext);
                return;
            }
            //校验授权的信息及授权的活动id
            string activityId = filterContext.RequestContext.HttpContext.Request["activityId"];
            if (string.IsNullOrEmpty(activityId))
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult() {Data=new DataResult() {Status=false,Notify="activityId不能为空" } };
                    return;
                }
                else
                {
                    //跳转
                    filterContext.Result = new RedirectResult($"/Home/home/Index?activityId={activityId}");
                    return;
                }
            }
            //activityId不为空时
            var currentUser = AppUtil.GetCurrentUser<ScreenAuthDto>(Application.Enum.TokenTypeEnum.Screen_Auth);
            int currentActivityId;
            int.TryParse(activityId, out currentActivityId);
            if (currentUser == null || currentActivityId != currentUser.ActivityId)
            {
                //跳转
                filterContext.Result = new RedirectResult($"/Home/home/Index?activityId={activityId}");
            }
            
        }
    }
}