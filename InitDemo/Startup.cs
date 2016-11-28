using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InitDemo.Startup))]
namespace InitDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
