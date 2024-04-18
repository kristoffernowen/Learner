using Learner.Domain.Models;
using System.Linq.Expressions;

namespace Learner.Application.Contracts.Repos
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> CreateAsync(T model);
        Task<T?> GetByIdAsync(string id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> EditAsync(T model);
        Task DeleteAsync(string id);
    }
}
