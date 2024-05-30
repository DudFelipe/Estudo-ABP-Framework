using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpFramework.Estudo.Produtos
{
    public static class ProdutoEfCoreListExtension
    {
        public static List<Produto> IncludeImagesList(this IQueryable<Produto> query)
        {
            return query.Include(i => i.Imagens).ToList();
        }
    }
}
