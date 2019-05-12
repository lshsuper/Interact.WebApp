
using Interact.Application.Service;
using Interact.Application.Utils;
using Interact.Core.Dto;
using Interact.Core.IRespository;
using Interact.WebApp.Areas.Admin.Common;
using Interact.WebApp.Common;
using Interact.WebApp.Controllers;
using Interact.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interact.WebApp.Areas.Admin.Controllers
{
    [AdminAuthorizeFilter]
    public class HomeController : BaseController
    {
        private readonly AdminService _adminService;
        public HomeController(AdminService adminService)
        {
            _adminService = adminService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            var currentUser = AppUtil.GetCurrentUser<AdminDto>(Application.Enum.TokenTypeEnum.Admin_Login);
            if (currentUser != null)
                return RedirectToAction("Index","Home");
            return View();
        }
        [AllowAnonymous]
        public ActionResult ToLogin(string login,string pwd)
        {
            string notify;
            AdminDto result = _adminService.Login(login,pwd,out notify);
            if (result!=null)
            {
                AppUtil.ToSigin(Application.Enum.TokenTypeEnum.Admin_Login,result);
            }
            return Json(new DataResult() {
                Status= result!=null,
                Notify=notify
            });
        }
        [AllowAnonymous]
        public ActionResult ToLogOut()
        {
            AppUtil.ToSignOut(Application.Enum.TokenTypeEnum.Admin_Login);
            return RedirectToAction("Login", "Home");
        }
    }
}
