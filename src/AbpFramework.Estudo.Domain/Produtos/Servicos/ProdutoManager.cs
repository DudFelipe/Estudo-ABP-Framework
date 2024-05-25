using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AbpFramework.Estudo.Produtos.Servicos
{
    public class ProdutoManager : BaseDomainManager<Produto>, IProdutoManager
    {
        public ProdutoManager(IProdutoRepository produtoRepository) : base(produtoRepository)
        {
        }

        public override async Task<Produto> Inserir(Produto produto, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return await base.Inserir(produto, autoSave, cancellationToken);
        }
    }
}
