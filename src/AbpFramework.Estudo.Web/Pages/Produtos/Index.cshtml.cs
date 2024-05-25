using AbpFramework.Estudo.Categorias;
using AbpFramework.Estudo.Fornecedores;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpFramework.Estudo.Web.Pages.Produtos
{
    public class IndexModel : AbpPageModel
    {
        public ProdutoFilterInput ProdutoFilter { get; set; } = new();
        private readonly ICategoriaAppService _categoriaAppService;
        private readonly IFornecedorAppService _fornecedorAppService;
        public SelectListItem[] Categorias { get; set; }
        public SelectListItem[] Fornecedores { get; set; }

        public IndexModel(ICategoriaAppService categoriaAppService, IFornecedorAppService fornecedorAppService)
        {
            _categoriaAppService = categoriaAppService;
            _fornecedorAppService = fornecedorAppService;
        }

        public virtual async Task OnGetAsync()
        {
            var categoriasItens = new List<SelectListItem>() { new SelectListItem() };
            categoriasItens.AddRange((await _categoriaAppService.GetCategoriasAsync()).Items.Select(x => new SelectListItem(x.Nome, x.Id.ToString())).ToList());
            Categorias = categoriasItens.ToArray();
            await Task.CompletedTask;

            var fornecedoresItens = new List<SelectListItem>() { new SelectListItem() };
            fornecedoresItens.AddRange((await _fornecedorAppService.GetFornecedoresAsync()).Items.Select(x => new SelectListItem(x.Nome, x.Id.ToString())).ToList());
            Fornecedores = fornecedoresItens.ToArray();
            await Task.CompletedTask;
        }
    }

    public class ProdutoFilterInput
    {

        [FormControlSize(AbpFormControlSize.Medium)]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [FormControlSize(AbpFormControlSize.Medium)]
        [Display(Name = "Preço")]
        public decimal? Preco { get; set; }

        [FormControlSize(AbpFormControlSize.Medium)]
        [SelectItems("Categorias")]
        [Display(Name = "Categoria")]
        public Guid? CategoriaId { get; set; }

        [FormControlSize(AbpFormControlSize.Medium)]
        [SelectItems("Fornecedores")]
        [Display(Name = "Fornecedor")]
        public Guid? FornecedorId { get; set; }

    }
}
