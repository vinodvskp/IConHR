using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ICONHRPortal.Startup))]
namespace ICONHRPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
