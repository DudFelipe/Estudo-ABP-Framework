using System;
using System.Collections.Generic;
using System.Text;
using AbpFramework.Estudo.Localization;
using Volo.Abp.Application.Services;

namespace AbpFramework.Estudo;

/* Inherit your application services from this class.
 */
public abstract class EstudoAppService : ApplicationService
{
    protected EstudoAppService()
    {
        LocalizationResource = typeof(EstudoResource);
    }
}
