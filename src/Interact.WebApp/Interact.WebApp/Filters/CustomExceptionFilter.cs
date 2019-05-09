using Interact.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
namespace Interact.WebApp.Filters
{
    /// <summary>
    /// 全局异常捕捉器
    /// </summary>
    public class CustomExceptionFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            filterContext.ExceptionHandled = true;
            //接口异常处理
            if (filterContext.HttpContext.Request.IsAjaxRequest())
                filterContext.Result = new JsonResult() {
                    Data=new DataResult() {
                         Notify="服务端异常",
                         Status=false,
                    },
                    ContentEncoding=Encoding.UTF8,
                    ContentType= "application/json"
                };
            //页面异常处理
            filterContext.Result = new ViewResult() { ViewName = "~/Views/Notice/error.cshtml" };
        }
    }
}
