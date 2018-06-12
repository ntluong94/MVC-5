using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopQuanAoLite.Startup))]
namespace ShopQuanAoLite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
