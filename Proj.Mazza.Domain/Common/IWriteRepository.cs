using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proj.Mazza.Domain.Common
{
    public interface IWriteRepository<TId, TEntity> where TEntity : Entity<TId>
    {
        IUnitOfWork UnitOfWork { get; }
        Task CreateAsync(TEntity entity);
        Task CreateManyAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task UpdateManyAsync(IEnumerable<TEntity> entities);
        Task DeleteAsync(TId id);
        Task DeleteManyAsync(Expression<Func<TEntity, bool>> predicate);
    }
}