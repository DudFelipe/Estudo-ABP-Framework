using Volo.Abp.Modularity;

namespace AbpFramework.Estudo;

[DependsOn(
    typeof(EstudoApplicationModule),
    typeof(EstudoDomainTestModule)
)]
public class EstudoApplicationTestModule : AbpModule
{

}
