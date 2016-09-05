using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Iskatel.Web.Startup))]
namespace Iskatel.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
