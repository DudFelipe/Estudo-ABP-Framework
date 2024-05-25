using System.ComponentModel.DataAnnotations;

namespace AbpFramework.Estudo.Web.Pages.Categorias.ViewModels
{
    public class CreateEditCategoriaViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Descricao { get; set; }
    }
}
