using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuraltaClothing.Startup))]
namespace AuraltaClothing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
