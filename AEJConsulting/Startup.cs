using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AEJConsulting.Startup))]
namespace AEJConsulting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
