using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Services;

namespace AbpFramework.Estudo.Produtos.Servicos
{
    [ExposeServices(typeof(ValidaInserirProdutoService))]
    public class ValidaInserirProdutoService : DomainService
    {
        public async Task ValidarInsercaoProduto(Produto produto)
        {
            produto.SetPreco(produto.Preco);
            produto.SetNome(produto.Nome);
        }
    }
}
