using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoGreenV3.Startup))]
namespace GoGreenV3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
