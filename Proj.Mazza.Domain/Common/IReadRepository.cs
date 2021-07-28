using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proj.Mazza.Domain.Common
{
    public interface IReadRepository<TId, TEntity> where TEntity : Entity<TId>
    {
        Task<TEntity> FindAsync(TId id);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
    }
}