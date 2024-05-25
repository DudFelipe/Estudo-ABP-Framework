using System.ComponentModel.DataAnnotations;

namespace AbpFramework.Estudo.Web.Pages.Fornecedores.ViewModels
{
    public class UpdateFornecedorViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Descricao { get; set; }
    }
}
