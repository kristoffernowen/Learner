using Learner.Application.Contracts.Repos;
using Learner.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Learner.Persistence.Repos
{
    public class ExerciseRepository : Repository<Exercise>, IExerciseRepository 
    {
        private readonly SqlContext _context;

        public ExerciseRepository(SqlContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Exercise?> GetByIdAsync(string id)
        {
            var result = await _context.Exercises
                .Include(x => x.FactObjects)
                .ThenInclude(x => x.Facts)
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
