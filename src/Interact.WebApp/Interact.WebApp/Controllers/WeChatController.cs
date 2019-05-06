using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interact.WebApp.Controllers
{
    public class WeChatController : Controller
    {
        // GET: WeChat
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Token()
        {

            string echoStr = Request.QueryString["echoStr"].ToString();
            return Content(echoStr);
        }
    }
}