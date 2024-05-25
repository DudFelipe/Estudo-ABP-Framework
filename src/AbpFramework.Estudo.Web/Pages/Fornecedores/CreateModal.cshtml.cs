using AbpFramework.Estudo.Fornecedores;
using AbpFramework.Estudo.Fornecedores.Dtos;
using AbpFramework.Estudo.Web.Pages.Fornecedores.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpFramework.Estudo.Web.Pages.Fornecedores
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateFornecedorViewModel ViewModel { get; set; }

        private readonly IFornecedorAppService _fornecedorAppService;

        public CreateModalModel(IFornecedorAppService fornecedorAppService)
        {
            _fornecedorAppService = fornecedorAppService;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateFornecedorViewModel, CreateFornecedorDto>(ViewModel);

            await _fornecedorAppService.CreateAsync(dto);

            return NoContent();
        }
    }
}
