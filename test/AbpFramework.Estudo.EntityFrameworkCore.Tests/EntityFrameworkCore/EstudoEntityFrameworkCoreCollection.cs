using Xunit;

namespace AbpFramework.Estudo.EntityFrameworkCore;

[CollectionDefinition(EstudoTestConsts.CollectionDefinitionName)]
public class EstudoEntityFrameworkCoreCollection : ICollectionFixture<EstudoEntityFrameworkCoreFixture>
{

}
