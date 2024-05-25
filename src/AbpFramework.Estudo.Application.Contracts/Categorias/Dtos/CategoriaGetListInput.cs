using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AbpFramework.Estudo.Categorias.Dtos
{
    public class CategoriaGetListInput : PagedAndSortedResultRequestDto
    {
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Display(Name = "Nome")]
        public string? Nome { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }
    }
}
