using AbpFramework.Estudo.Categorias;
using AbpFramework.Estudo.Fornecedores;
using AbpFramework.Estudo.Produtos;
using AbpFramework.Estudo.Produtos.Dtos;
using AbpFramework.Estudo.Web.Pages.Produtos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpFramework.Estudo.Web.Pages.Produtos
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditProdutoViewModel ViewModel { get; set; }

        public SelectListItem[] Categorias { get; set; }
        public SelectListItem[] Fornecedores { get; set; }

        private readonly IProdutoAppService _produtoAppService;
        private readonly ICategoriaAppService _categoriaAppService;
        private readonly IFornecedorAppService _fornecedorAppService;

        public EditModalModel(IProdutoAppService produtoAppService, ICategoriaAppService categoriaAppService, IFornecedorAppService fornecedorAppService)
        {
            _produtoAppService = produtoAppService;
            _categoriaAppService = categoriaAppService;
            _fornecedorAppService = fornecedorAppService;
        }

        public virtual async Task OnGetAsync()
        {
            var categoriasItens = new List<SelectListItem>() { new SelectListItem() };
            categoriasItens.AddRange((await _categoriaAppService.GetCategoriasAsync())
                .Items.Select(x => new SelectListItem(x.Nome, x.Id.ToString())).ToList());

            Categorias = categoriasItens.ToArray();

            var fornecedoresItens = new List<SelectListItem>() { new SelectListItem() };
            fornecedoresItens.AddRange((await _fornecedorAppService.GetFornecedoresAsync())
                .Items.Select(x => new SelectListItem(x.Nome, x.Id.ToString())).ToList());

            Fornecedores = fornecedoresItens.ToArray();

            var dto = await _produtoAppService.GetAsync(Id);
            ViewModel = ObjectMapper.Map<ProdutoDto, CreateEditProdutoViewModel>(dto);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateEditProdutoViewModel, CreateUpdateProdutoDto>(ViewModel);
            await _produtoAppService.UpdateAsync(Id, dto);
            return NoContent();
        }
    }
}
