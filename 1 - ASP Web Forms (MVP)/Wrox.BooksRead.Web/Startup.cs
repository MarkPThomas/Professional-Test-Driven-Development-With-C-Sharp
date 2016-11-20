using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wrox.BooksRead.Web.Startup))]
namespace Wrox.BooksRead.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
