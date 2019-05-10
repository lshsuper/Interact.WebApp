using Interact.WebApp.Hubs;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;

namespace Interact.WebApp.Models
{
    /// <summary>
    /// 消息收发机
    /// </summary>
    public class ScreenTicker
    {
        // Singleton instance
        private readonly static Lazy<ScreenTicker> _instance = new Lazy<ScreenTicker>(() => new ScreenTicker(GlobalHost.ConnectionManager.GetHubContext<ScreenHub>().Clients));
        private ScreenTicker(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
        
        }
        public static ScreenTicker Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        /// <summary>
        /// 所有客户端
        /// </summary>
        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }

        public void Test()
        {
            Clients.All.hello();
        }
       
    }
}