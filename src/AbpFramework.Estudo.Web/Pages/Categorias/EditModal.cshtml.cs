using AbpFramework.Estudo.Categorias;
using AbpFramework.Estudo.Categorias.Dtos;
using AbpFramework.Estudo.Web.Pages.Categorias.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpFramework.Estudo.Web.Categorias
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditCategoriaViewModel ViewModel { get; set; }

        private readonly ICategoriaAppService _categoriaAppService;

        public EditModalModel(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _categoriaAppService.GetAsync(Id);
            ViewModel = ObjectMapper.Map<CategoriaDto, CreateEditCategoriaViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditCategoriaViewModel, CreateUpdateCategoriaDto>(ViewModel);
            await _categoriaAppService.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}
