using System;
using Volo.Abp.Domain.Entities;

namespace AbpFramework.Estudo.Produtos
{
    public class ImagemProduto : Entity<Guid>
    {
        protected ImagemProduto() { }

        public ImagemProduto(string nome, string path, Guid produtoId)
        {
            Nome = nome;
            Path = path;
            ProdutoId = produtoId;
        }

        public string Nome { get; private set; }
        public string Path { get; private set; }
        public Guid ProdutoId { get; private set; }
        public Produto Produto { get; private set; }

        public string GetCompletePath()
        {
            return String.Concat(Path, Nome);
        }
    }
}
