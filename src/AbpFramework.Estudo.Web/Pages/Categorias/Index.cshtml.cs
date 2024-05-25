using AbpFramework.Estudo.Categorias;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpFramework.Estudo.Web.Pages.Categorias
{
    public class IndexModel : AbpPageModel
    {
        public CategoriaFilterInput CategoriaFilter { get; set; } = new();

        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }

    public class CategoriaFilterInput
    {

        [FormControlSize(AbpFormControlSize.Medium)]
        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [FormControlSize(AbpFormControlSize.Medium)]
        [Display(Name = "Descricao")]
        public string? Descricao { get; set; }
    }
}
