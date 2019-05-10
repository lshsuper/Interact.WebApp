using Interact.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interact.WebApp.Controllers
{
    public class TestSignalRController : Controller
    {
        public ActionResult Msg(string msg)
        {
            ScreenTicker.Instance.Test(msg);
            return Json("ok");
        }
        // GET: TestSignalR
        public ActionResult Index()
        {
            return View();
        }
    }
}