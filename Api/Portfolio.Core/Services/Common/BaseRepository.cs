using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Interfaces.Common;
using Portfolio.Database;
using Portfolio.Domain.Models.Common;

namespace Portfolio.Core.Services.Common
{
    public class BaseRepository<TEntity> : BaseRepository<TEntity, int>, IBaseRepository<TEntity>
        where TEntity : class, IBaseEntity<int>
    {
        public BaseRepository(PortfolioContext context)
            : base(context)
        {
        }
    }

    public class BaseRepository<TEntity, TKey> : BaseRepository<TEntity, TKey, PortfolioContext>, IBaseRepository<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>
    {
        public BaseRepository(PortfolioContext context)
            : base(context)
        {
        }
    }

    public class BaseRepository<TEntity, TKey, TDbContext> : IBaseRepository<TEntity, TKey, TDbContext>
        where TDbContext : DbContext
        where TEntity : class, IBaseEntity<TKey>
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(TDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
            Table = _dbSet;
        }

        public DbSet<TEntity> Table { get; }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (includeProperties != null)
                query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (orderBy != null)
                return orderBy(query).ToList();

            return await query.ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChanges();
        }

        public virtual async Task InsertAsync(IEnumerable<TEntity> entity)
        {
            await _dbSet.AddRangeAsync(entity);
            await SaveChanges();
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            await DeleteAsync(entity);
            await SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task DeleteAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            await SaveChanges();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            await SaveChanges();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            IQueryable<TEntity> query = _dbSet;
            return await query.AsNoTracking().ToListAsync();
        }

        protected IQueryable<TEntity> QueryableAsync()
        {
            return _dbSet.AsQueryable();
        }

        private async Task SaveChanges()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }

        }

        public int Count()
            => _dbSet.Count();
    }
}
