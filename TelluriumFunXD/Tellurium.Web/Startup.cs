using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tellurium.Web.Startup))]
namespace Tellurium.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
