using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AbpFramework.Estudo.Produtos.Dtos
{
    public class ProdutoGetListInput : PagedAndSortedResultRequestDto
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        //public string? Imagem { get; set; }

        public Guid? CategoriaId { get; set; }
        public Guid? FornecedorId { get; set; }
    }
}
