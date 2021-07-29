using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Proj.Mazza.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Cyrela.Onboarding.Infrastructure.Data.EF.Repositories.Common
{
    public class WriteRepository<TId, TEntity> : IWriteRepository<TId, TEntity>, IReadRepository<TId, TEntity> where TEntity : Entity<TId>
    {
        protected readonly OnboardingContext _context;

        public WriteRepository(OnboardingContext context)
            => _context = context ?? throw new ArgumentNullException(nameof(context));

        public IUnitOfWork UnitOfWork => _context;

        public async Task CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task CreateManyAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task DeleteAsync(TId id)
        {
            var finded = await _context.Set<TEntity>().FindAsync(id);

            _context.Set<TEntity>().Remove(finded);
        }

        public async Task DeleteManyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var finded = await _context.Set<TEntity>().Where(predicate).ToListAsync();

            _context.Set<TEntity>().RemoveRange(finded);
        }

        public async Task<TEntity> FindAsync(TId id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = includes?.Aggregate(_context.Set<TEntity>().AsQueryable(), (current, include)
                    => current.Include(include));

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();

        }

        public async Task UpdateAsync(TEntity entity)
        {
            entity.Update();
            _context.Set<TEntity>().Update(entity);

            await Task.CompletedTask;
        }

        public async Task UpdateManyAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);

            await Task.CompletedTask;
        }
    }
}