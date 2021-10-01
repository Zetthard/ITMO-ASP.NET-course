using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCCreditApp.Startup))]
namespace MVCCreditApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
