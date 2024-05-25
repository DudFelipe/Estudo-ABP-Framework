using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AbpFramework.Estudo.Categorias.Servicos
{
    public class CategoriaManager : BaseDomainManager<Categoria>, ICategoriaManager
    {
        private readonly ICategoriaRepository _repository;
        private readonly ValidarExcluirCategoriaService _validarService;

        public CategoriaManager(ICategoriaRepository repository, ValidarExcluirCategoriaService validarService) : base(repository)
        {
            _repository = repository;
            _validarService = validarService;
        }

        public override async Task Excluir(Categoria entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            await _validarService.ValidarExclusao(entity);

            await _repository.DeleteAsync(entity, autoSave, cancellationToken);
        }
    }
}
