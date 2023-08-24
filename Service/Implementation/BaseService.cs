using DataAccessLayer.Infrastructure;
using Service.Infrastructure;
using System.Linq.Expressions;

namespace Service.Implementation
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepo<T> _baseRepo;
        private readonly IUnitOfWork _unitOfWork;

        public BaseService(IBaseRepo<T> baseRepo, IUnitOfWork unitOfWork)
        {
            _baseRepo = baseRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _baseRepo.GetAllAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Expression<Func<T, object>>[]? includes = null)
        {
            return await _baseRepo.GetAllAsync(predicate, includes);
        }

        public async Task<T> GetByIdAsync(long Id)
        {
            return await _baseRepo.GetByIdAsync(Id);
        }
    }
}
