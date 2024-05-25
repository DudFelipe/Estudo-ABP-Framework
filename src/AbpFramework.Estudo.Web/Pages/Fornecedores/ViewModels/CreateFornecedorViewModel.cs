using System.ComponentModel.DataAnnotations;

namespace AbpFramework.Estudo.Web.Pages.Fornecedores.ViewModels
{
    public class CreateFornecedorViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve possuir exatamente 14 caracteres!")]
        public string Cnpj { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Descricao { get; set; }
    }
}
