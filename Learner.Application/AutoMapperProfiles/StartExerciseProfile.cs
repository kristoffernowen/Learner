using AutoMapper;
using Learner.Application.Features.DoFreeTextExercise.Queries.StartExercise.Dtos;
using Learner.Domain.Models;

namespace Learner.Application.AutoMapperProfiles
{
    public class StartExerciseProfile : Profile
    {
        public StartExerciseProfile()
        {
            CreateMap<Exercise, GetExerciseWithoutAnswersOutputDto>();
            CreateMap<FactObject, GetExerciseWithoutAnswersFactObjectOutputDto>();
            CreateMap<Fact, GetExerciseWithoutAnswersFactOutputDto>();
        }
    }
}
