using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PiecesDeRechange.Startup))]
namespace PiecesDeRechange
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
