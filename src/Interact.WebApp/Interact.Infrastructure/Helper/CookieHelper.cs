using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Interact.Infrastructure.Helper
{
    /// <summary>
    /// cookie帮助类
    /// </summary>
   public class CookieHelper
    {
        public static void Set(string value,string name,TimeSpan expires)
        {
            HttpCookie cookie = new HttpCookie(name, value) {
                 Expires=DateTime.Now.Add(expires)
            };
           
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        public static string Get(string name)
        {
           HttpCookie cookie= HttpContext.Current.Response.Cookies.Get(name);
            if (cookie == null) return string.Empty;
            return cookie.Value;
        }
    }
}
