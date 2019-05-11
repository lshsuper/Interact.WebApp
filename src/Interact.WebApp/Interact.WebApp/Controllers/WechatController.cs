using Interact.Infrastructure.Wexin.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interact.WebApp.Controllers
{
    /// <summary>
    /// 微信相关回调接口
    /// </summary>
    public class WechatController : Controller
    {
        /// <summary>
        /// 公众号回调接口
        /// </summary>
        /// <returns></returns>
        public ActionResult TokenHook()
        {
            //token测试
            string echostr = Request.QueryString.Get("echostr");
            if (!string.IsNullOrEmpty(echostr))
            return Content(echostr);

            //1.验签
            if (!WeChatMessageAgent.CheckSignature())
                return Content("error");
            //2.截获消息+对应发送
            var model = WeChatMessageAgent.ReceiveXml();
            switch (model.MsgType)
            {
                case Infrastructure.WeChat.Enum.XmlMessageTypeEnum.text:
                    return Content(WeChatMessageAgent.ResponseText(model.FromUserName, model.ToUserName, "lsh--你最帅"));

                case Infrastructure.WeChat.Enum.XmlMessageTypeEnum.image:
                    return Content("xxx");
                case Infrastructure.WeChat.Enum.XmlMessageTypeEnum.@event:
                    return Content("xxx");

            }
            return Content("error");
        }
    }
}