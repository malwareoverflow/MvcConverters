using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcConverters.Startup))]
namespace MvcConverters
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
