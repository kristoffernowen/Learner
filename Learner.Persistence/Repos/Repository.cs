using System.Linq.Expressions;
using Learner.Application.Contracts.Repos;
using Learner.Domain.Models;
using Microsoft.EntityFrameworkCore;

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

        public virtual async Task<T?> GetByIdAsync(string id)
        {
            var result = await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var result = await context.Set<T>().ToListAsync();

            return result;
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
