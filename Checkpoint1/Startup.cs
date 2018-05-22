using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Checkpoint1.Startup))]
namespace Checkpoint1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
