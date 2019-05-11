using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Infrastructure.Config.Model
{
    /// <summary>
    /// 微信配置相关
    /// </summary>
    public class WeChatConfig
    {
        public  static string AppKey=>ConfigurationManager.AppSettings["weixin_appkey"];
        public static string AppSecuret=>ConfigurationManager.AppSettings["weixin_appsecret"];
        public static string Weixin_Token => ConfigurationManager.AppSettings["weixin_token"];

    }
}
