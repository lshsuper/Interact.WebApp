using Interact.WebApp.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interact.WebApp.Controllers
{
    public class FileController:BaseController
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        public ActionResult Upload()
        {
            try
            {
                List<string> videoExts = new List<string> { ".mp4", ".flv" };
                HttpPostedFileBase file = HttpContext.Request.Files["file"];
                using (BinaryReader br = new BinaryReader(file.InputStream))
                {
                    byte[] fileBuffer = br.ReadBytes(file.ContentLength);
                    string resp = UploadHelper.UploadFile(fileBuffer, file.FileName);
                    if (!string.IsNullOrWhiteSpace(resp) && videoExts.Contains(Path.GetExtension(file.FileName)))
                    {
                        System.IO.File.WriteAllBytes(Server.MapPath($"~/UploadFile/Video/{Path.GetFileName(resp)}"), fileBuffer);
                    }
                    return Json(new { status = !string.IsNullOrWhiteSpace(resp), url = resp });
                }
            }
            catch (Exception ex)
            {
                return Json(new { status = false, msg = ex.Message });
            }
        }
    }
}