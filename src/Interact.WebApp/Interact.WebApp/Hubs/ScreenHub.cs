using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

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
    }
}