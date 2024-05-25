using System;
using Volo.Abp.Application.Dtos;

namespace AbpFramework.Estudo.Fornecedores.Dtos
{
    public class FornecedorGetListInput : PagedAndSortedResultRequestDto
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Cnpj { get; set; }
        public string? Descricao { get; set; }
        public Guid? ProdutoId { get; set; }
    }
}
