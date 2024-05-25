using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpFramework.Estudo.Data;
using Volo.Abp.DependencyInjection;

namespace AbpFramework.Estudo.EntityFrameworkCore;

public class EntityFrameworkCoreEstudoDbSchemaMigrator
    : IEstudoDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreEstudoDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the EstudoDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<EstudoDbContext>()
            .Database
            .MigrateAsync();
    }
}
