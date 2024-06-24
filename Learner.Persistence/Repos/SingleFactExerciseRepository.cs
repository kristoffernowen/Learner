using Learner.Application.Contracts.Repos;
using Learner.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Learner.Persistence.Repos
{
    public class SingleFactExerciseRepository(SqlContext context) : Repository<SingleFactExercise>(context), ISingleFactExerciseRepository
    {
        public override async Task<SingleFactExercise?> GetByIdAsync(string id)
        {
            var entity = await context.SingleFactExercises
                .Include(x => x.Facts)
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }
    }
}
