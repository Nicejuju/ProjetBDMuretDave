using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetBDMuretDave.Startup))]
namespace ProjetBDMuretDave
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
