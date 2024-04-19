using AutoMapper;
using Learner.Application.Features.HandleExercises.Queries.GetExerciseById.Dtos;
using Learner.Domain.Models;

namespace Learner.Application.AutoMapperProfiles
{
    public class GetExerciseByIdProfile : Profile
    {
        public GetExerciseByIdProfile()
        {
            CreateMap<Exercise, GetExerciseByIdOutputDto>();
            CreateMap<FactObject, GetExerciseByIdFactObjectOutputDto>();
            CreateMap<Fact, GetExerciseByIdFactBaseDtoOutputDto>();
        }
    }
}
