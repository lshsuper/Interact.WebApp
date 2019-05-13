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

namespace Interact.WebApp.Areas.Admin.Common
{
    public class SignInAuthorizeFilter : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                base.OnAuthorization(filterContext);
                return;
            }
            var currentUser = AppUtil.GetCurrentUser<SignInAuthDto>(Application.Enum.TokenTypeEnum.SignIn_Auth);
            if (currentUser == null)
            {
                //跳转
                filterContext.Result = new ContentResult() { Content= "当前页面已失效", ContentEncoding=Encoding.UTF8};

            }

        }
    }
}