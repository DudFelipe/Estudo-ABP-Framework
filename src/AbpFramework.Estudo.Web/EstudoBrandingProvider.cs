using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace AbpFramework.Estudo.Web;

[Dependency(ReplaceServices = true)]
public class EstudoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Estudo";
}
