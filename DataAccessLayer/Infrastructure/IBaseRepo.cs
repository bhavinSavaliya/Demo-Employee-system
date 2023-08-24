using Entity.DTOs;
using System.Linq.Expressions;

namespace DataAccessLayer.Infrastructure
{
    public interface IBaseRepo<T> where T : class
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>>[]? includes = null, string[]? thenIncludes = null, Expression<Func<T, T>>? selects = null, CancellationToken cancellationToken = default);

        Task<PageListResponseDTO<T>> GetAllAsync(PageListRequestEntity<T> pageListRequest, CancellationToken cancellationToken = default);

        Task AddAsync(T entity, CancellationToken cancellationToken = default);

        void Add(T entity);
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);

        Task<T?> GetByIdAsync(long id);

        Task<bool> IsEntityExist(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate);

        IEnumerable<T> GetAll();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate, IEnumerable<Expression<Func<T, object>>> includes, string? sortColumn = null, string? sortOrder = null);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate, Expression<Func<T, object>>[]? includes = null);
        T GetbyId(long id);

        bool IsEnityExist(Expression<Func<T, bool>>? predicate);
    }
}
