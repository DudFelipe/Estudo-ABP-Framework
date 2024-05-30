using AbpFramework.Estudo.Categorias;
using AbpFramework.Estudo.Fornecedores;
using AsyncKeyedLock;
using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Guids;

namespace AbpFramework.Estudo.Produtos
{
    public class Produto : AggregateRoot<Guid>
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public string Descricao { get; private set; }

        public IList<ImagemProduto> Imagens { get; private set; }

        public Fornecedor Fornecedor { get; private set; }
        public Guid FornecedorId { get; private set; }

        public virtual Categoria Categoria { get; private set; }
        public Guid CategoriaId { get; private set; }

        protected Produto() { }

        public Produto(string nome, decimal preco, IList<ImagemProduto> imagens)
        {
            SetNome(nome);
            SetPreco(preco);
            SetImagens(imagens);
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

        public void SetImagens(IList<ImagemProduto> imagens)
        {
            Imagens = imagens;
        }

        public void SetDescricao(string descricao)
        {
            Descricao = Check.NotNullOrEmpty(descricao, nameof(descricao));
        }
    }
}
