using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portfolio.Database;

namespace Portfolio.Core.Interfaces.Common
{
    public interface IBaseRepository<TEntity, TEntityDto> : IBaseRepository<TEntity, TEntityDto, int>
        where TEntity : class
    {

    }

    public interface IBaseRepository<TEntity, TEntityDto, TKey> : IBaseRepository<TEntity, TEntityDto, TKey, PortfolioContext>
        where TEntity : class
    {

    }

    public interface IBaseRepository<TEntity, TEntityDto, TKey, TDbContext>
        where TEntity : class
    {
        public DbSet<TEntity> Table { get; }

        Task<IEnumerable<TEntityDto>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        Task<IEnumerable<TEntityDto>> GetAllAsync();

        Task<TEntityDto> InsertAsync(TEntityDto dtoEntity);

        Task InsertAsync(IEnumerable<TEntityDto> entity);

        Task<TEntityDto> UpdateAsync(TEntityDto entity);

        Task<TEntityDto> UpdateAsync(TEntity entity);

        Task UpdateRangeAsync(IEnumerable<TEntityDto> entities);

        Task DeleteAsync(TEntityDto entity);

        Task DeleteAsync(IEnumerable<TEntityDto> entities);

        Task DeleteAsync(TKey id);

        Task<TEntityDto> GetByIdAsync(TKey id);

        int Count();

        Task<TEntityDto> FirstOrDefaultAsync();
    }
}
