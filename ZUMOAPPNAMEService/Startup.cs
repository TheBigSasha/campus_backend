using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ZUMOAPPNAMEService.Startup))]

namespace ZUMOAPPNAMEService
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            //app.UseAppServiceAuthentication(config);          //TODO: Bad?
            ConfigureMobileApp(app);
        }
    }
}