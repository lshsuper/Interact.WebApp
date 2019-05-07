using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Infrastructure.Weixin.Model
{
    public class WeixinAuthAccessTokenResult
    {
        public string access_token { get; set; }
        public string openid { get; set; }
    //     "access_token":"ACCESS_TOKEN",
    //"expires_in":7200,
    //"refresh_token":"REFRESH_TOKEN",
    //"openid":"OPENID",
    //"scope":"SCOPE" 
    }
}
