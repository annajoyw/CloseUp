using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CloseUp.Startup))]
namespace CloseUp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
