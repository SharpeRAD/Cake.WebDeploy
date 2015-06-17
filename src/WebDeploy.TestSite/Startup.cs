using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cake.WebDeploy.TestSite.Startup))]
namespace Cake.WebDeploy.TestSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
