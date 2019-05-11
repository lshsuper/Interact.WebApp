using Interact.Application.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interact.WebApp.Controllers
{
    public class BaseController : Controller
    {
        private readonly AppUtil _appUtil;
        public BaseController(AppUtil appUtil)
        {
            _appUtil = appUtil;
        }
    }
}