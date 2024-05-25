using AbpFramework.Estudo.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbpFramework.Estudo.Fornecedores
{
    public class FornecedorRepository : EfCoreRepository<EstudoDbContext, Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(IDbContextProvider<EstudoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<Fornecedor>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }
    }
}
