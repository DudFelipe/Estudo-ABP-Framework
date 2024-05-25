using AbpFramework.Estudo.Samples;
using Xunit;

namespace AbpFramework.Estudo.EntityFrameworkCore.Domains;

[Collection(EstudoTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<EstudoEntityFrameworkCoreTestModule>
{

}
