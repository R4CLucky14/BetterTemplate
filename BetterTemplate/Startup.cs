using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BetterTemplate.Startup))]
namespace BetterTemplate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
