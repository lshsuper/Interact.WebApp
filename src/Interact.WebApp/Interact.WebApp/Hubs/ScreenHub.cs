using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Interact.WebApp.Hubs
{
    public class ScreenHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}