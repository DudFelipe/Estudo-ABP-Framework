using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AbpFramework.Estudo.Produtos.Dtos
{
    public class ImagemProdutoDto : EntityDto<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Path { get; set; }
    }
}
