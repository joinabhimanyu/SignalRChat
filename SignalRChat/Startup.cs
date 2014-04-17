using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(SignalRChat.Startup))]
namespace SignalRChat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here

            var config = new Microsoft.AspNet.SignalR.HubConfiguration();
            config.EnableCrossDomain = false;
            config.EnableDetailedErrors = true;
            config.EnableJavaScriptProxies = true;

            app.MapHubs("/signalr", config);
            
        }
    }
}