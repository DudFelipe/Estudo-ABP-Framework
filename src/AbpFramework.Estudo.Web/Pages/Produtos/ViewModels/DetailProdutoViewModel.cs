using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AbpFramework.Estudo.Web.Pages.Produtos.ViewModels
{
    public class DetailProdutoViewModel
    {
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Imagem")]
        public List<ImagemProdutoViewModel> Imagens { get; set; }

        [Display(Name = "Categoria")]
        public string Categoria { get; set; }

        [Display(Name = "Fornecedor")]
        public string Fornecedor { get; set; }
    }
}
