using AbpFramework.Estudo.EntityFrameworkCore;
using AbpFramework.Estudo.Produtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbpFramework.Estudo.ImagemProdutos
{
    public class ImagemProdutosRepository : EfCoreRepository<EstudoDbContext, ImagemProduto>, IImagemProdutoRepository
    {
        public ImagemProdutosRepository(IDbContextProvider<EstudoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override Task DeleteAsync(Expression<Func<ImagemProduto, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(predicate, autoSave, cancellationToken);
        }
    }
}
