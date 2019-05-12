using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Infrastructure.Helper
{
   public class JsonHelper
    {
        public static string Set(object obj)
        {
            return JsonConvert.SerializeObject(obj); 
        }
        public static string Set(object obj,string dateFormat= "yyyy-MM-dd HH:mm:ss")
        {
            JsonSerializerSettings setting = new JsonSerializerSettings();
            // 设置日期序列化的格式
            setting.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            return JsonConvert.SerializeObject(obj,setting);
        }
        public static T Get<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}
