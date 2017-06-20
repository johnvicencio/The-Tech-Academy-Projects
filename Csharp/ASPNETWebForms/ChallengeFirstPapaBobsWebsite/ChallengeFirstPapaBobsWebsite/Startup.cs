using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChallengeFirstPapaBobsWebsite.Startup))]
namespace ChallengeFirstPapaBobsWebsite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
