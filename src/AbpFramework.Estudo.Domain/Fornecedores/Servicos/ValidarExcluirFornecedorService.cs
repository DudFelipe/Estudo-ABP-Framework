using AbpFramework.Estudo.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Services;

namespace AbpFramework.Estudo.Fornecedores.Servicos
{
    [ExposeServices(typeof(ValidarExcluirFornecedorService))]
    public class ValidarExcluirFornecedorService : DomainService
    {
        public void Validar(Fornecedor fornecedor)
        {
            if(fornecedor.QtdProdutosAssociados > 0)
                throw new UserFriendlyException("Não é possível excluir este Fornecedor. Ele possui produtos associados.");
        }
    }
}
