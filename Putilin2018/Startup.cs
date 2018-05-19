using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Putilin2018.Startup))]
namespace Putilin2018
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
