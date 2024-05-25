using Volo.Abp.Modularity;

namespace AbpFramework.Estudo;

[DependsOn(
    typeof(EstudoDomainModule),
    typeof(EstudoTestBaseModule)
)]
public class EstudoDomainTestModule : AbpModule
{

}
