using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpFramework.Estudo.Categorias
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<List<Categoria>> GetListAsync(int skipCount, int maxResultCount, string sorting, string? filter = null);
    }
}
