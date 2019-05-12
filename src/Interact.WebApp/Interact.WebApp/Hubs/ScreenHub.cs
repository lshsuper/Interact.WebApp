using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Interact.Core.IRespository;
using Interact.WebApp.App_Start;
using Microsoft.AspNet.SignalR;
using Autofac;
using Interact.WebApp.Models;

namespace Interact.WebApp.Hubs
{
    /// <summary>
    /// 大屏幕事件总线
    /// </summary>
    public class ScreenHub : Hub
    {
        /// <summary>
        /// 断开连接触发的事件
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }
        /// <summary>
        /// 连接上时触发的事件
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            return base.OnConnected();  
        }
        /// <summary>
        /// 向客户端发送签到人数
        /// </summary>
        /// <param name="activityId"></param>
        public void SendSignInCount(int activityId)
        {
            ScreenTicker.Instance.SendSignInCount(activityId);
        }
    }
}