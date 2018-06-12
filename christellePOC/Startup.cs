using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(christellePOC.Startup))]
namespace christellePOC
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
