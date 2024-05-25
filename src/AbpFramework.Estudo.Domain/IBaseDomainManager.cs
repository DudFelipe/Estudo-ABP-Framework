using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Services;

namespace AbpFramework.Estudo
{
    public interface IBaseDomainManager<TEntity> : IDomainService where TEntity : class, IEntity
    {
        Task<TEntity> Inserir(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);
        Task<TEntity> Alterar(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);
        Task Excluir(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);
        Task Excluir(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = default);

    }
}
