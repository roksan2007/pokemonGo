using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PokemonGo.Startup))]
namespace PokemonGo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
