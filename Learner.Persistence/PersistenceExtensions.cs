using Learner.Application.Contracts.Repos;
using Learner.Persistence.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Learner.Persistence
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistenceExtensions(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<SqlContext>(x => x.UseSqlServer(configuration.GetConnectionString("Sql")));
            services.AddScoped<IExerciseRepository, ExerciseRepository>();
            services.AddScoped<IFactObjectRepository, FactObjectRepository>();
            services.AddScoped<IFactRepository, FactRepository>();
            services.AddScoped<ISingleFactExerciseRepository, SingleFactExerciseRepository>();

            return services;
        }
    }
}
