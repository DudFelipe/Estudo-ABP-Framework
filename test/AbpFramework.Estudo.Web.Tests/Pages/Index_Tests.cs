using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace AbpFramework.Estudo.Pages;

public class Index_Tests : EstudoWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
