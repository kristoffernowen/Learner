using Learner.Application.Contracts.Repos;
using Learner.Domain.Models;

namespace Learner.Persistence.Repos
{
    public class ExerciseRepository(SqlContext context) : Repository<Exercise>(context), IExerciseRepository 
    {
    }
}
