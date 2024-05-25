using AbpFramework.Estudo.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpFramework.Estudo.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class EstudoPageModel : AbpPageModel
{
    protected EstudoPageModel()
    {
        LocalizationResourceType = typeof(EstudoResource);
    }
}
