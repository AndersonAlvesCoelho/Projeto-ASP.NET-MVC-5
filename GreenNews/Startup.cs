using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GreenNews.Startup))]
namespace GreenNews
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
