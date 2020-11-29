using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SampleWebAPISignalR.Startup))]

namespace SampleWebAPISignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            //app.MapSignalR("/signalr", new HubConfiguration());
            app.Map("/signalr", map =>
             {
                 map.UseCors(CorsOptions.AllowAll);
                 var hubConfig = new HubConfiguration();
                 map.RunSignalR(hubConfig);
             });
        }
    }
}
