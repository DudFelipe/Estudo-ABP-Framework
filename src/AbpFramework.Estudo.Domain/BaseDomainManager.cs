using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace AbpFramework.Estudo
{
    public class BaseDomainManager<TEntity> : DomainService, IBaseDomainManager<TEntity> where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> _repository;

        public BaseDomainManager(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task<TEntity> Inserir(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return await _repository.InsertAsync(entity, autoSave, cancellationToken);
        }

        public virtual async Task<TEntity> Alterar(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return await _repository.UpdateAsync(entity, autoSave, cancellationToken);
        }

        public virtual async Task Excluir(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            await _repository.DeleteAsync(entity, autoSave, cancellationToken);
        }

        public virtual async Task Excluir(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            await _repository.DeleteAsync(predicate, autoSave, cancellationToken);
        }
    }
}
