using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITI.Mvc.LinkedIn.Startup))]
namespace ITI.Mvc.LinkedIn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
