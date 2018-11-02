using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZW_Blog.Startup))]
namespace ZW_Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
