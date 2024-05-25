using AbpFramework.Estudo.Produtos.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AbpFramework.Estudo.Fornecedores.Dtos
{
    public class FornecedorDto : EntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Descricao { get; set; }
    }
}
