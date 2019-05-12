using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interact.WebApp.Controllers
{
    public class NoticeController : Controller
    {
       
        #region Notice-View
        /// <summary>
        /// 错误捕捉页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Error()
        {
            return View();
        }
     
        #endregion
    }
}