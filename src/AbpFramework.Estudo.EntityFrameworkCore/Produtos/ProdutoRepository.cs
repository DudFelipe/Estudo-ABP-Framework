using AbpFramework.Estudo.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Linq;

namespace AbpFramework.Estudo.Produtos
{
    public class ProdutoRepository : EfCoreRepository<EstudoDbContext, Produto>, IProdutoRepository
    {
        public ProdutoRepository(IDbContextProvider<EstudoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<Produto>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }

        public async Task<IQueryable<Produto>> WithDetailsAndImagesAsync(Guid id)
        {
            return (await GetQueryableAsync()).IncludeDetails().IncludeImages().Where(x => x.Id == id);
        }

        public async Task<List<Produto>> WithDetailsAndImagesAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails().IncludeImagesList();
        }
    }
}
