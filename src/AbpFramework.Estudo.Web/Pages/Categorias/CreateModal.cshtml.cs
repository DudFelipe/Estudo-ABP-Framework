using AbpFramework.Estudo.Categorias;
using AbpFramework.Estudo.Categorias.Dtos;
using AbpFramework.Estudo.Web.Pages.Categorias.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpFramework.Estudo.Web.Categorias
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateEditCategoriaViewModel ViewModel { get; set; }

        private readonly ICategoriaAppService _categoriaAppService;

        public CreateModalModel(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditCategoriaViewModel, CreateUpdateCategoriaDto>(ViewModel);

            await _categoriaAppService.CreateAsync(dto);

            return NoContent();
        }
    }
}
