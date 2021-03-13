using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Interfaces.Common;
using Portfolio.Database;
using Portfolio.Domain.Models.Common;

namespace Portfolio.Core.Services.Common
{
    public class BaseRepository<TEntity, TDtoEntity> : BaseRepository<TEntity, TDtoEntity, int>, IBaseRepository<TEntity, TDtoEntity>
        where TEntity : class, IBaseEntity<int>
    {
        public BaseRepository(PortfolioContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }

    public class BaseRepository<TEntity, TDtoEntity, TKey> : BaseRepository<TEntity, TDtoEntity, TKey, PortfolioContext>, IBaseRepository<TEntity, TDtoEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>
    {
        public BaseRepository(PortfolioContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }

    public class BaseRepository<TEntity, TDtoEntity, TKey, TDbContext> : IBaseRepository<TEntity, TDtoEntity, TKey, TDbContext>
        where TDbContext : DbContext
        where TEntity : class, IBaseEntity<TKey>
    {
        #region Fields

        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private readonly IMapper _mapper;
        
        #endregion

        #region Constructor

        public BaseRepository(TDbContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
            _mapper = mapper;
            Table = _dbSet;
        }

        #endregion

        #region Methods

        #region Get

        public DbSet<TEntity> Table { get; }

        public virtual async Task<TDtoEntity> GetByIdAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);

            return entity == null ? default : _mapper.Map<TDtoEntity>(entity);
        }

        public virtual async Task<IEnumerable<TDtoEntity>> GetAsync(
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
            {
                var orderByResult = orderBy(query).ToList();

                return orderByResult == null ? default : _mapper.Map<IEnumerable<TDtoEntity>>(orderByResult);
            }

            var result = await query.ToListAsync().ConfigureAwait(false);
            return result == null ? default : _mapper.Map<IEnumerable<TDtoEntity>>(result);
        }

        public virtual Task<IEnumerable<TDtoEntity>> GetAllAsync()
        {
            IQueryable<TEntity> query = _dbSet;
            var result = query.AsNoTracking().ToListAsync();

            return _mapper.Map<Task<IEnumerable<TDtoEntity>>>(result);
        }

        #endregion

        #region Create

        public async Task InsertAsync(TDtoEntity dtoEntity)
        {
            var entity = _mapper.Map<TEntity>(dtoEntity);
            await _dbSet.AddAsync(entity);
            await SaveChanges();
        }

        public virtual async Task InsertAsync(IEnumerable<TDtoEntity> dtoEntities)
        {
            var entities = _mapper.Map<IEnumerable<TEntity>>(dtoEntities);
            await _dbSet.AddRangeAsync(entities);
            await SaveChanges();
        }

        #endregion

        #region Delete

        public virtual async Task DeleteAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            await DeleteAsync(entity);
            await SaveChanges();
        }

        public async Task DeleteAsync(TDtoEntity dtoEntity)
        {
            var entity = _mapper.Map<TEntity>(dtoEntity);
            _dbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task DeleteAsync(IEnumerable<TDtoEntity> dtoEntities)
        {
            var entities = _mapper.Map<IEnumerable<TEntity>>(dtoEntities);
            _dbSet.RemoveRange(entities);
            await SaveChanges();
        }

        private async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await SaveChanges();
        }

        #endregion

        #region Update

        public async Task UpdateAsync(TDtoEntity dtoEntity)
        {
            var entity = _mapper.Map<TEntity>(dtoEntity);
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public async Task UpdateRangeAsync(IEnumerable<TDtoEntity> dtoEntities)
        {
            var entities = _mapper.Map<IEnumerable<TEntity>>(dtoEntities);
            _dbSet.UpdateRange(entities);
            await SaveChanges();
        }

        #endregion

        #region Utils

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

        #endregion

        #endregion
    }
}
