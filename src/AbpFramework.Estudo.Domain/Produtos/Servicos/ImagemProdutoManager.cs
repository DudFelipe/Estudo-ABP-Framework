using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpFramework.Estudo.Produtos.Servicos
{
    public class ImagemProdutoManager : BaseDomainManager<ImagemProduto>, IImagemProdutoManager
    {
        public ImagemProdutoManager(IRepository<ImagemProduto> repository) : base(repository)
        {
        }

        public override Task Excluir(Expression<Func<ImagemProduto, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return base.Excluir(predicate, autoSave, cancellationToken);
        }
    }
}
