using AbpFramework.Estudo.Categorias;
using AbpFramework.Estudo.Fornecedores;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace AbpFramework.Estudo.Produtos
{
    public class Produto : AggregateRoot<Guid>
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public Fornecedor Fornecedor { get; private set; }
        public Guid FornecedorId { get; private set; }
        public virtual Categoria Categoria { get; private set; }
        public Guid CategoriaId { get; private set; }

        protected Produto() { }
        public Produto(string nome, decimal preco)
        {
            SetNome(nome);
            SetPreco(preco);
        }

        public void SetNome(string nome)
        {
            Nome = Check.NotNullOrEmpty(nome, nameof(nome), ProdutoConsts.Pro_NomeMaxLength, ProdutoConsts.Pro_NomeMinLength);
        }

        public void SetPreco(decimal preco)
        {
            if(preco <= 0)
                throw new UserFriendlyException(message: "O preço do produto deve ser maior que zero!");

            Preco = preco;
        }

        public void SetCategoria(Guid idCategoria)
        {
            CategoriaId = idCategoria;
        }
    }
}
