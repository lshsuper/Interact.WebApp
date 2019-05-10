using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Interact.WebApp.Startup))]

namespace Interact.WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //应用signalr通信
            app.MapSignalR();
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
