using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpFramework.Estudo.Web.Pages.Fornecedores
{
    public class IndexModel : AbpPageModel
    {
        public FornecedorFilterInput FornecedorFilter { get; set; } = new();

        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }

    public class FornecedorFilterInput
    {

        [FormControlSize(AbpFormControlSize.Medium)]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [FormControlSize(AbpFormControlSize.Medium)]
        [Display(Name = "Descricao")]
        public string? Descricao { get; set; }

        [FormControlSize(AbpFormControlSize.Medium)]
        [Display(Name = "CNPJ")]
        public string? Cnpj { get; set; }
    }
}
