using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MandatoryAssignment2.Startup))]
namespace MandatoryAssignment2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
