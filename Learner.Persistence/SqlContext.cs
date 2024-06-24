using Learner.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Learner.Persistence
{
    public class SqlContext(DbContextOptions<SqlContext> options) : DbContext(options)
    {
        public DbSet<Exercise> Exercises { get; set; } = null!;
        public DbSet<FactObject> FactObjects { get; set; } = null!;
        public DbSet<FactInObject> Facts { get; set; } = null!;
        public DbSet<SingleFactExercise> SingleFactExercises { get; set; } = null!;
        public DbSet<SingleFact> SingleFacts { get; set; } = null!;
    }
}
