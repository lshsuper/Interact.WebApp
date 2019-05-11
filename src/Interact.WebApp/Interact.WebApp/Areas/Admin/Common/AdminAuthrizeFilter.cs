using Interact.Application.Utils;
using Interact.WebApp.App_Start;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Interact.Application.Dto;

namespace Interact.WebApp.Areas.Admin.Common
{
    public class AdminAuthrizeFilter : IAuthorizationFilter
    {
        private AppUtil _appUtil;
        public AdminAuthrizeFilter()
        {
            _appUtil = AutofacConfig._container.Resolve<AppUtil>();
        }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var _context = filterContext.RequestContext;
            var currentUser = _appUtil.GetCurrentUser<AdminDto>(Application.Enum.TokenTypeEnum.Admin_Login);
            if (currentUser == null)
            {
                //跳转
            }

        }
    }
}