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
        public static T Get<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}
