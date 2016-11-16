using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OSIM.WebClient.Startup))]
namespace OSIM.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
