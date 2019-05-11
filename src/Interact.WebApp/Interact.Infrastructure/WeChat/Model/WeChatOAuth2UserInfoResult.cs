using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interact.Infrastructure.Wexin.Model
{

    /// <summary>
    /// 微信用户信息结果
    /// </summary>
    public class WeixinOAuth2UserInfoResult
    {
       
        public string openid { get; set; }
        public string nickname { get; set; }
        public string sex { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string headimgurl { get; set; }
        public string unionid { get; set; }   //需要在开放平台绑定公众号才可以获取(绑定需花三百大洋)
        
    }
}
