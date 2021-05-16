using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TFI_Agro_intelligent_DG.Startup))]
namespace TFI_Agro_intelligent_DG
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
