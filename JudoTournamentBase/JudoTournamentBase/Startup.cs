using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JudoTournamentBase.Startup))]
namespace JudoTournamentBase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
