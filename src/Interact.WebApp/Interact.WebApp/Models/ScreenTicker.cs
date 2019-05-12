using Interact.Core.Entity;
using Interact.Infrastructure.Helper;
using Interact.WebApp.App_Start;
using Interact.WebApp.Hubs;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using Autofac;
using Interact.Core.IRespository;

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
        /// <summary>
        /// 测试
        /// </summary>
        public void Test(string msg)
        {
            Clients.All.hello(msg);
        }
        /// <summary>
        /// 向客户端发签到消息
        /// </summary>
        /// <param name="record"></param>
        public void SendSignInRecordToClient(SignInRecord record)
        {
            string str = JsonHelper.Set(record);
            Clients.All.sendSignInRecordToClient(str);
        }
        /// <summary>
        /// 向客户端发送签到人数
        /// </summary>
        /// <param name="activityId"></param>
        public void SendSignInCount(int activityId)
        {
            var _sigInRecordRespository = AutofacConfig._container.Resolve<ISigInRecordRespository>();
            Clients.All.SendSignInCount(_sigInRecordRespository.TotalCount(activityId));
          
        }

    }
}