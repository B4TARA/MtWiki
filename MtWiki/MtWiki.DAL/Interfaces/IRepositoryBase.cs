using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MtWiki.DAL.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);

        Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default, params string[] includeProperties);

        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default, params string[] includeProperties);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default, params string[] includeProperties);

        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    }
}
