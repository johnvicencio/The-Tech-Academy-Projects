using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AgencyAddressBook.Startup))]
namespace AgencyAddressBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
