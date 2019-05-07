using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Infrastructure.Http
{
    /// <summary>
    /// http请求工具
    /// </summary>
    public class HttpClientHelper
    {
        /// <summary>
        /// get
        /// </summary>
        /// <param name="url"></param>
        /// <param name="result"></param>
        /// <param name="notify"></param>
        /// <returns></returns>
        public static bool Get(string url, out string result, out string notify)
        {

            using (var client = new HttpClient())
            {
                var res = client.GetAsync(url).Result;
                if (res == null || !res.IsSuccessStatusCode)
                {
                    result = string.Empty;
                    notify = "请求失败";
                    return false;
                }
                result = res.Content.ReadAsStringAsync().Result;
                notify = "请求成功";
                return true;

            }
        }
        /// <summary>
        /// post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <param name="encoding"></param>
        /// <param name="result"></param>
        /// <param name="notify"></param>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        public static bool Post(string url, string content, Encoding encoding, out string result, out string notify, string mediaType = "application/json")
        {

            using (var client = new HttpClient())
            {
                HttpContent httpContent = new StringContent(content, encoding, mediaType);
                var res = client.PostAsync(url, httpContent).Result;
                if (res == null || !res.IsSuccessStatusCode)
                {
                    result = string.Empty;
                    notify = "请求失败";
                    return false;
                }
                result = res.Content.ReadAsStringAsync().Result;
                notify = "请求成功";
                return true;

            }
        }
    }
}
