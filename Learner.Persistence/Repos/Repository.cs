using System.Linq.Expressions;
using Learner.Application.Contracts.Repos;
using Learner.Domain.Models;

namespace Learner.Persistence.Repos
{
    public class Repository<T>(SqlContext context) : IRepository<T> where T : BaseEntity
    {
        public async Task<T> CreateAsync(T model)
        {
            var result = await context.Set<T>().AddAsync(model);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public Task<T> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> EditAsync(T model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
