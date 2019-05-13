using Interact.Infrastructure.Config.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Infrastructure.Helper
{
   public class UploadHelper
    {
        
        /// <summary>
        /// 传入时间，转换为时间戳(精确到毫秒)
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ParseDatetime(DateTime time)
        {
            return (long)(time.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="b">文件流</param>
        /// <returns></returns>
        public static string UploadFile(byte[] b, string fileName)
        {
            try
            {
                var url =WebConfig.Static_Web_Host+"/upload/UploadFile?pathPrefix=" + DateTime.Now.ToString("yyyy-MM-dd");
                var result = "";

                string timestamp = ParseDatetime(DateTime.Now).ToString();
                string nonce = new Random().Next(000000, 999999).ToString().PadLeft('0').Trim();
                string sign =(WebConfig.Api_Sign_Secret+timestamp + WebConfig.Api_Sign_Secret).Md5();

                //获取后缀名
                string extension = fileName.Substring(fileName.LastIndexOf(".") + 1, (fileName.Length - fileName.LastIndexOf(".") - 1)); //扩展名
                //新文件名称
                string newFileName = System.Guid.NewGuid().ToString("N") + "." + extension;

                using (HttpClient httpClient = new HttpClient())
                {
                    using (var multipartFormDataContent = new MultipartFormDataContent())
                    {

                        multipartFormDataContent.Add(new ByteArrayContent(b, 0, b.Length), newFileName, newFileName);
                        multipartFormDataContent.Add(new StringContent(timestamp, Encoding.UTF8, "application/x-www-form-urlencoded"), "timestamp");
                        multipartFormDataContent.Add(new StringContent(nonce, Encoding.UTF8, "application/x-www-form-urlencoded"), "nonce");
                        multipartFormDataContent.Add(new StringContent(sign, Encoding.UTF8, "application/x-www-form-urlencoded"), "sign");

                        var response = httpClient.PostAsync(url, multipartFormDataContent).Result;
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            result = response.Content.ReadAsStringAsync().Result;

                            var obj = Newtonsoft.Json.Linq.JObject.Parse(result);
                            var data = obj["data"];
                            //var src = data["src"];
                            return data.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            return "";
        }
    }
}
