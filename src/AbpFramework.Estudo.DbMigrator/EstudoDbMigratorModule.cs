using AbpFramework.Estudo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AbpFramework.Estudo.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EstudoEntityFrameworkCoreModule),
    typeof(EstudoApplicationContractsModule)
    )]
public class EstudoDbMigratorModule : AbpModule
{
}
