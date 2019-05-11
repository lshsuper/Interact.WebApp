using Interact.Infrastructure.Config.Model;
using Interact.Infrastructure.Helper;
using Interact.Infrastructure.WeChat.Enum;
using Interact.Infrastructure.Wexin.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Interact.Infrastructure.Wexin.Helper
{
    public class WeChatMessageAgent
    {



        public static bool CheckSignature()
        {
            var request = HttpContext.Current.Request;
            string signature = request.QueryString["signature"],
                    timestamp = request.QueryString["timestamp"],
                    nonce = request.QueryString["nonce"],
                    token = WeChatConfig.Weixin_Token;

            string[] tmpArr = { token, timestamp, nonce };

            Array.Sort(tmpArr);
            string tmpStr = string.Join("", tmpArr);
            tmpStr = tmpStr.Sha1();



            if (tmpStr.ToLower() == signature.ToLower())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 接收微信发送的XML消息并且解析
        /// </summary>
        public static WeChatXmlModel ReceiveXml()
        {
            Stream requestStream = System.Web.HttpContext.Current.Request.InputStream;
            byte[] requestByte = new byte[requestStream.Length];
            requestStream.Read(requestByte, 0, (int)requestStream.Length);
            string requestStr = Encoding.UTF8.GetString(requestByte);

            if (!string.IsNullOrEmpty(requestStr))
            {
                //封装请求类
                XmlDocument requestDocXml = new XmlDocument();
                requestDocXml.LoadXml(requestStr);
                XmlElement rootElement = requestDocXml.DocumentElement;
                WeChatXmlModel WxXmlModel = new WeChatXmlModel();
                WxXmlModel.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;
                WxXmlModel.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
                WxXmlModel.CreateTime = rootElement.SelectSingleNode("CreateTime").InnerText;
                WxXmlModel.MsgType = (XmlMessageTypeEnum)System.Enum.Parse(typeof(XmlMessageTypeEnum), rootElement.SelectSingleNode("MsgType").InnerText);
                switch (WxXmlModel.MsgType)
                {
                    case XmlMessageTypeEnum.text://文本
                        WxXmlModel.Content = rootElement.SelectSingleNode("Content").InnerText;

                        break;
                    case XmlMessageTypeEnum.image://图片
                        WxXmlModel.PicUrl = rootElement.SelectSingleNode("PicUrl").InnerText;
                        break;
                    case XmlMessageTypeEnum.@event://事件
                        WxXmlModel.Event = rootElement.SelectSingleNode("Event").InnerText;
                        if (WxXmlModel.Event == "subscribe")//关注类型
                        {
                            WxXmlModel.EventKey = rootElement.SelectSingleNode("EventKey").InnerText;
                        }
                        break;
                    default:
                        break;
                }
                return WxXmlModel;
            }
            return new WeChatXmlModel() { MsgType=XmlMessageTypeEnum.text,Content="未知指令"};
        }
        /// <summary>
        /// 回复文本
        /// </summary>
        /// <param name="FromUserName">发送给谁(openid)</param>
        /// <param name="ToUserName">来自谁(公众账号ID)</param>
        /// <param name="Content">回复类型文本</param>
        /// <returns>拼凑的XML</returns>
        public static string ResponseText(string FromUserName, string ToUserName, string Content)
        {

            string xml = $@"<xml>
                                <ToUserName><![CDATA[{FromUserName}]]></ToUserName>
                                <FromUserName><![CDATA[{ToUserName}]]></FromUserName>
                                <CreateTime>{DateTime.Now.Ticks}</CreateTime>
                                <MsgType><![CDATA[text]]></MsgType>
                                <Content><![CDATA[{Content}]]></Content>
                                <FuncFlag>0</FuncFlag>
                            </xml>";
            return xml;
        }
        
    }
}
