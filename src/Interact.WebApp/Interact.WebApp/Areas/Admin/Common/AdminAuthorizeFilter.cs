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
    public class AdminAuthorizeFilter : AuthorizeAttribute
    {
       
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute),true) || 
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute),true))
            {
                base.OnAuthorization(filterContext);
                return;
            }
            var currentUser = AppUtil.GetCurrentUser<AdminDto>(Application.Enum.TokenTypeEnum.Admin_Login);
            if (currentUser == null)
            {
                //跳转
                filterContext.Result = new RedirectResult("/admin/home/login");
               
            }

        }
    }
}