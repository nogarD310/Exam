using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoolEvents.Startup))]
namespace CoolEvents
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
