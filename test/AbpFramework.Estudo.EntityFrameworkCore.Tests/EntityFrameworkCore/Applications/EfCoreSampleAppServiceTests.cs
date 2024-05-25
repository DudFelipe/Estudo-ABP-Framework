using AbpFramework.Estudo.Samples;
using Xunit;

namespace AbpFramework.Estudo.EntityFrameworkCore.Applications;

[Collection(EstudoTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<EstudoEntityFrameworkCoreTestModule>
{

}
