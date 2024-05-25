using AbpFramework.Estudo.Fornecedores;
using AbpFramework.Estudo.Fornecedores.Dtos;
using AbpFramework.Estudo.Web.Pages.Fornecedores.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpFramework.Estudo.Web.Pages.Fornecedores
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public UpdateFornecedorViewModel ViewModel { get; set; }

        private readonly IFornecedorAppService _fornecedorAppService;

        public EditModalModel(IFornecedorAppService fornecedorAppService)
        {
            _fornecedorAppService = fornecedorAppService;
        }

        public virtual async Task OnGetAsync()
        {
            var dto = await _fornecedorAppService.GetAsync(Id);
            ViewModel = ObjectMapper.Map<FornecedorDto, UpdateFornecedorViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<UpdateFornecedorViewModel, UpdateFornecedorDto>(ViewModel);
            await _fornecedorAppService.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}
