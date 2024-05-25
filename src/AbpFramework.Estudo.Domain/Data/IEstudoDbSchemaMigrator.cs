using System.Threading.Tasks;

namespace AbpFramework.Estudo.Data;

public interface IEstudoDbSchemaMigrator
{
    Task MigrateAsync();
}
