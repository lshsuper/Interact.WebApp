using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Infrastructure.Config.Model
{
  public  class WebConfig
    {
        public  static string Web_Host=> ConfigurationManager.AppSettings["web_host"];
    }
}
