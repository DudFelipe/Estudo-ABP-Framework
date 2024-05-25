using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpFramework.Estudo.Fornecedores
{
    public static class FornecedorEfCoreQueryableExtension
    {
        public static IQueryable<Fornecedor> IncludeDetails(this IQueryable<Fornecedor> query, bool include = true) 
        {
            if (!include)
                return query;

            return query.Include(f => f.Produtos);
        }
    }
}
