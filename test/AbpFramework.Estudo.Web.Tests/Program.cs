using Microsoft.AspNetCore.Builder;
using AbpFramework.Estudo;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<EstudoWebTestModule>();

public partial class Program
{
}
