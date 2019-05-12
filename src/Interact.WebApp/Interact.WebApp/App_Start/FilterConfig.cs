using Interact.WebApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interact.WebApp.App_Start
{
    public class FilterConfig
    {
        public static void RegisterFilter(GlobalFilterCollection filters) { 
            filters.Add(new GlobalExceptionFilter("/Notice/Error"));
        }
    }
}