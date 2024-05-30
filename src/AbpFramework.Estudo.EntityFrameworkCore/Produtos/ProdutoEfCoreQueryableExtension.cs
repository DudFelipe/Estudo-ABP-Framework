using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpFramework.Estudo.Produtos
{
    public static class ProdutoEfCoreQueryableExtension
    {
        public static IQueryable<Produto> IncludeDetails(this IQueryable<Produto> query, bool include = true)
        {
            if (!include)
                return query;

            return query.Include(c => c.Categoria).Include(p => p.Fornecedor);
        }

        public static IQueryable<Produto> IncludeImages(this IQueryable<Produto> query)
        {
            return query.Include(i => i.Imagens);
        }
    }
}
