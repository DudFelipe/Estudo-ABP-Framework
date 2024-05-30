using AbpFramework.Estudo.Produtos;
using AbpFramework.Estudo.Produtos.Dtos;
using AbpFramework.Estudo.Web.Pages.Produtos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpFramework.Estudo.Web.Pages.Produtos
{
    public class DetailsModalModel : AbpPageModel
    {
        [BindProperty]
        public DetailProdutoViewModel ViewModel { get; set; }

        IProdutoAppService _produtoAppService { get; set; }

        public DetailsModalModel(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        public virtual async Task OnGetAsync(Guid id)
        {
            var produto = await _produtoAppService.GetWithImages(id);

            ViewModel = ObjectMapper.Map<ProdutoDto, DetailProdutoViewModel>(produto);
        }
    }
}
