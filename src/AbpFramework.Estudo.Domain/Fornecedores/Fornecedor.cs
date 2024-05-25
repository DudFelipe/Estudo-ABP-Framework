using AbpFramework.Estudo.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace AbpFramework.Estudo.Fornecedores
{
    public class Fornecedor : AggregateRoot<Guid>
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Cnpj { get; private set; }
        public virtual IList<Produto> Produtos { get; private set; }

        protected Fornecedor() { }

        public Fornecedor(string nome, string descricao, string cnpj, IList<Produto> produtos)
        {
            SetNome(nome);
            SetDescricao(descricao);
            SetCnpj(cnpj);
            Produtos = produtos;
        }

        public void SetNome(string nome)
        {
            Nome = Check.NotNullOrEmpty(nome, nameof(nome), FornecedorConsts.For_NomeMaxLength, FornecedorConsts.For_NomeMinLength);
        }

        public void SetDescricao(string descricao)
        {
            Descricao = Check.NotNullOrEmpty(descricao, nameof(descricao));
        }

        public void SetCnpj(string cnpj)
        {
            Cnpj = Check.NotNullOrEmpty(cnpj, nameof(cnpj));
        }

        public int QtdProdutosAssociados
        {
            get
            {
                return Produtos.Count;
            }
        }
    }
}
