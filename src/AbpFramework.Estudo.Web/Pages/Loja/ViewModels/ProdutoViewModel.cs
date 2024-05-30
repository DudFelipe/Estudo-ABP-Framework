using AbpFramework.Estudo.Web.Pages.Produtos.ViewModels;
using System.Collections.Generic;

namespace AbpFramework.Estudo.Web.Pages.Loja.ViewModels
{
    public class ProdutoViewModel
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public List<ImagemProdutoViewModel> Imagens { get; set; }
    }
}
