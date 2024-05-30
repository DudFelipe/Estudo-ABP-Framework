using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.Threading;

namespace AbpFramework.Estudo.Web.Pages.Produtos.ViewModels
{
    public class CreateEditProdutoViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public decimal Preco { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Descricao { get; set; }

        [Display(Name = "Imagem do Produto")]
        public List<IFormFile> ImagensUpload { get; set; }

        public List<ImagemProdutoViewModel> Imagens { get; set; }

        [SelectItems("Categoria")]
        [DisplayName("Categoria")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public Guid CategoriaId { get; set; }

        [SelectItems("Fornecedor")]
        [DisplayName("Fornecedor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public Guid FornecedorId { get; set; }

        public CreateEditProdutoViewModel()
        {
            Imagens = new List<ImagemProdutoViewModel>();
            ImagensUpload = new List<IFormFile>();
        }
    }
}
