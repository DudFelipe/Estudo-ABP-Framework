using AbpFramework.Estudo.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Services;

namespace AbpFramework.Estudo.Categorias.Servicos
{
    [ExposeServices(typeof(ValidarExcluirCategoriaService))]
    public class ValidarExcluirCategoriaService : DomainService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ValidarExcluirCategoriaService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task ValidarExclusao(Categoria categoria)
        {
            int contProdutos = (await _produtoRepository.WithDetailsAsync()).Where(p => p.CategoriaId == categoria.Id).Count();

            if(contProdutos > 0)
                throw new UserFriendlyException("Não é possível excluir essa categoria! Ela possui produtos associados.");
        }
    }
}
