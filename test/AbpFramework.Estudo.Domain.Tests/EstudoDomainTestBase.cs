using Volo.Abp.Modularity;

namespace AbpFramework.Estudo;

/* Inherit from this class for your domain layer tests. */
public abstract class EstudoDomainTestBase<TStartupModule> : EstudoTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
