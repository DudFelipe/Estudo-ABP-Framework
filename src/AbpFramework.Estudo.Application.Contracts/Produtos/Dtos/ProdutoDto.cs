using AbpFramework.Estudo.Categorias.Dtos;
using AbpFramework.Estudo.Fornecedores.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;

namespace AbpFramework.Estudo.Produtos.Dtos
{
    public class ProdutoDto : EntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public List<ImagemProdutoDto> Imagens { get; set; }

        public CategoriaDto Categoria { get; set; }
        public FornecedorDto Fornecedor { get; set; }
    }
}
