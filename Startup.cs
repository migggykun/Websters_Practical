using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Websters.Startup))]
namespace Websters
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
