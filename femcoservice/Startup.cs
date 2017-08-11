using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(femcoservice.Startup))]
namespace femcoservice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
