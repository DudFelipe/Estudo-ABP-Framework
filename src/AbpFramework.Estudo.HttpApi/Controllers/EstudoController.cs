using AbpFramework.Estudo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpFramework.Estudo.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class EstudoController : AbpControllerBase
{
    protected EstudoController()
    {
        LocalizationResource = typeof(EstudoResource);
    }
}
