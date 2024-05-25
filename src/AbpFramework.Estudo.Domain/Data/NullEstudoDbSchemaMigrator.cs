using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpFramework.Estudo.Data;

/* This is used if database provider does't define
 * IEstudoDbSchemaMigrator implementation.
 */
public class NullEstudoDbSchemaMigrator : IEstudoDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
