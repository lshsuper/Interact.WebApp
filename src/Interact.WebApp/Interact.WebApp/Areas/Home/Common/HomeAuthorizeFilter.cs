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

namespace Interact.WebApp.Areas.Admin.Common
{
    public class HomeAuthorizeFilter : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                base.OnAuthorization(filterContext);
                return;
            }
            var currentUser = AppUtil.GetCurrentUser<ScreenAuthDto>(Application.Enum.TokenTypeEnum.Screen_Auth);
            if (currentUser == null)
            {
                string activityId = filterContext.RequestContext.HttpContext.Request.QueryString.Get("activityId");
                //跳转
                filterContext.Result = new RedirectResult($"/Home/home/Index?activityId={activityId}");

            }

        }
    }
}