using AbpFramework.Estudo.Categorias;
using AbpFramework.Estudo.Fornecedores;
using AbpFramework.Estudo.Produtos;
using AbpFramework.Estudo.Produtos.Dtos;
using AbpFramework.Estudo.Web.Pages.Loja.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpFramework.Estudo.Web.Pages.Loja
{
    public class IndexModel : AbpPageModel
    {
        [BindProperty]
        public List<ProdutoViewModel> ViewModels { get; set; }

        private readonly IProdutoAppService _produtoAppService;

        public IndexModel(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        public virtual async Task OnGetAsync()
        {
            var produtoComImagem = await _produtoAppService.GetWithImages();
            ViewModels = ObjectMapper.Map<List<ProdutoDto>, List<ProdutoViewModel>>(await _produtoAppService.GetWithImages());
        }
    }
}
