using Interact.Core.IRespository;
using Interact.Core.Option;
using Interact.WebApp.Common;
using Interact.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interact.WebApp.Areas.Admin.Controllers
{
    public class SignInRecordController : BaseController
    {

        private readonly ISigInRecordRespository _sigInRecordRespository;
        public SignInRecordController(ISigInRecordRespository sigInRecordRespository)
        {
            _sigInRecordRespository = sigInRecordRespository;
        }
        #region View
        // GET: Admin/SignInRecord
        public ActionResult SignInRecords()
        {
            return View();
        }
        #endregion

        #region Operator
        /// <summary>
        /// 获取签到数据列表
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public ActionResult SearchSignInRecords(SignInRecordPageOption option)
        {
            var data = _sigInRecordRespository.QuerySignInRecordByPage(option);
            return Json(new DataResult()
            {
                Data = data.Rows,
                Status = true,
                Notify = ""
            });
        }
        #endregion
    }
}