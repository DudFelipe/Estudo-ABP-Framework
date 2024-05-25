using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AbpFramework.Estudo.Fornecedores.Servicos
{
    public class FornecedorManager : BaseDomainManager<Fornecedor>, IFornecedorManager
    {
        private readonly ValidarExcluirFornecedorService _validarExcluirFornecedorService;

        public FornecedorManager(IFornecedorRepository fornecedorRepository,
                                 ValidarExcluirFornecedorService validarExcluirFornecedorService) : base(fornecedorRepository)
        {
            _validarExcluirFornecedorService = validarExcluirFornecedorService;
        }

        public override async Task Excluir(Fornecedor fornecedor, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            _validarExcluirFornecedorService.Validar(fornecedor);

            await base.Excluir(fornecedor, autoSave, cancellationToken);
        }
    }
}
