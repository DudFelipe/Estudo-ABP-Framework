﻿using AbpFramework.Estudo.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbpFramework.Estudo.Categorias
{
    public class CategoriaRepository : EfCoreRepository<EstudoDbContext, Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(IDbContextProvider<EstudoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Categoria>> GetListAsync(int skipCount, int maxResultCount, string sorting, string? filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(!filter.IsNullOrWhiteSpace(), c => c.Nome.Contains(filter))
                .Skip(skipCount)
                .Take(maxResultCount)
                .OrderBy(sorting)
                .ToListAsync();
        }
    }
}
