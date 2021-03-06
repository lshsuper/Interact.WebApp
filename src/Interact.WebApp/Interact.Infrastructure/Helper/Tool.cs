﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Interact.Infrastructure.Util
{
    /// <summary>
    /// 工具类
    /// </summary>
    public class Tool
    {
        /// <summary>
        /// 截取参数,取不到值时返回""
        /// </summary>
        /// <param name="s">不带?号的url参数</param>
        /// <param name="para">要取的参数</param>
        public static string QueryString(string s, string para)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            s = s.Trim('?').Replace("%26", "&").Replace('?', '&');
            int num = s.Length;
            for (int i = 0; i < num; i++)
            {
                int startIndex = i;
                int num4 = -1;
                while (i < num)
                {
                    char ch = s[i];
                    if (ch == '=')
                    {
                        if (num4 < 0)
                        {
                            num4 = i;
                        }
                    }
                    else if (ch == '&')
                    {
                        break;
                    }
                    i++;
                }
                string str = null;
                string str2 = null;
                if (num4 >= 0)
                {
                    str = s.Substring(startIndex, num4 - startIndex);
                    str2 = s.Substring(num4 + 1, (i - num4) - 1);
                    if (str == para)
                    {
                        return System.Web.HttpUtility.UrlDecode(str2);
                    }
                }
            }
            return "";
        }
        /// <summary>
        /// 获取Json string某节点的值。
        /// </summary>
        /// <param name="json"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetJosnValue(string json, string key)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(json))
            {
                key = "\"" + key.Trim('"') + "\"";
                int index = json.IndexOf(key) + key.Length + 1;
                if (index > key.Length + 1)
                {
                    //先截逗号，若是最后一个，截“｝”号，取最小值

                    int end = json.IndexOf(',', index);
                    if (end == -1)
                    {
                        end = json.IndexOf('}', index);
                    }
                    //index = json.IndexOf('"', index + key.Length + 1) + 1;
                    result = json.Substring(index, end - index);
                    //过滤引号或空格
                    result = result.Trim(new char[] { '"', ' ', '\'' });
                }
            }
            return result;
        }
        /// <summary>
        /// 是否通过微信浏览器打开链接
        /// </summary>
        /// <returns></returns>
        public static bool IsCheckByWeixin()
        {
            string userAgent = HttpContext.Current.Request.UserAgent;
            return userAgent.ToLower().Contains("micromessenger");
        }
        /// <summary>
        /// 是否通过手机端打开链接
        /// </summary>
        /// <returns></returns>
        public static bool IsCheckByMobile()
        {
            bool flag = false;

            string agent = HttpContext.Current.Request.UserAgent;
            string[] keywords = { "Android", "iPhone", "iPod", "iPad", "Windows Phone", "MQQBrowser" };
            //排除 Windows 桌面系统
            if (!agent.Contains("Windows NT") || (agent.Contains("Windows NT") && agent.Contains("compatible; MSIE 9.0;")))
            {
                //排除 苹果桌面系统
                if (!agent.Contains("Windows NT") && !agent.Contains("Macintosh"))
                {
                    foreach (string item in keywords)
                    {
                        if (agent.Contains(item))
                        {
                            flag = true;
                            break;
                        }
                    }
                }
            }

            return flag;
        }
        /// <summary>
        /// 获取自定义长度随机码
        /// </summary>
        /// <param name="length"></param>
        /// <param name="useNum"></param>
        /// <param name="useLow"></param>
        /// <param name="useUpp"></param>
        /// <param name="useSpe"></param>
        /// <param name="custom"></param>
        /// <returns></returns>
        public static string UUID(int length, 
                                  bool useNum=true, 
                                  bool useLow=false,
                                  bool useUpp=true,
                                  bool useSpe=false,
                                  string custom="")
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = custom;
            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }
    }
}
