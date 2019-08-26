using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IslamTraders_Accounts.Startup))]
namespace IslamTraders_Accounts
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
