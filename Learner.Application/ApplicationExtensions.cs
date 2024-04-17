using System.Reflection;
using FluentValidation;
using Learner.Application.Features.HandleExercises.Commands.Create;
using Learner.Application.Features.HandleExercises.Commands.Create.FluentValidators;
using Microsoft.Extensions.DependencyInjection;

namespace Learner.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationExtensions(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IValidator<CreateExerciseCommand>, CreateExerciseCommandValidator>();

            return services;
        }
    }
}
