using AutoMapper;
using Learner.Application.Features.HandleExercises.Queries.GetExercises;
using Learner.Domain.Models;

namespace Learner.Application.AutoMapperProfiles
{
    public class GetExercises : Profile
    {
        public GetExercises()
        {
            CreateMap<Exercise, GetExercisesOutputDto>();
        }
    }
}
