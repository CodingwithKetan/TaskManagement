using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Contracts;
using System.Linq.Expressions;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _repositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext)
            => _repositoryContext = repositoryContext;

        public async Task CreateAsync(T entity)
        {
            await _repositoryContext.Set<T>().AddAsync(entity);
            await _repositoryContext.SaveChangesAsync();

        }

        public async Task UpdateAsync(T entity)
        {
            _repositoryContext.Set<T>().Update(entity);
            _repositoryContext.Entry(entity).State = EntityState.Modified;
            await _repositoryContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _repositoryContext.Set<T>().Remove(entity);
            await _repositoryContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _repositoryContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            var query = _repositoryContext.Set<T>();
            if (predicate == null)
            {
                return await query
                    .AsNoTracking()
                    .ToListAsync();
            }
            return await _repositoryContext.Set<T>()
                .Where(predicate)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
