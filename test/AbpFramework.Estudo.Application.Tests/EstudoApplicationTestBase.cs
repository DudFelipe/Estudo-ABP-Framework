using Volo.Abp.Modularity;

namespace AbpFramework.Estudo;

public abstract class EstudoApplicationTestBase<TStartupModule> : EstudoTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
