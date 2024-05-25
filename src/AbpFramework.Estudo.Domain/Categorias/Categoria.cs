using AbpFramework.Estudo.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace AbpFramework.Estudo.Categorias
{
    public class Categoria : Entity<Guid>
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public virtual IList<Produto> Produtos { get; private set; }

        protected Categoria() { }

        public Categoria(string nome, string descricao)
        {
            SetNome(nome);
            SetDescricao(descricao);
        }

        public void SetNome(string nome)
        {
            Nome = Check.NotNullOrEmpty(nome, nameof(nome), CategoriaConsts.Cat_NomeMaxLength, CategoriaConsts.Cat_NomeMinLength);
        }

        public void SetDescricao(string descricao)
        {
            Descricao = Check.NotNullOrEmpty(descricao, nameof(descricao), CategoriaConsts.Cat_DescriMaxLength, CategoriaConsts.Cat_DescriMinLength);
        }
    }
}
