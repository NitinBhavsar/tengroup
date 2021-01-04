using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TenTech.Startup))]
namespace TenTech
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
