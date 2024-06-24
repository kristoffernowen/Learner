using AutoMapper;
using Learner.Application.Features.HandleExercises.Commands.Create;
using Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Input;
using Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Output;
using Learner.Domain.Models;

namespace Learner.Application.AutoMapperProfiles
{
    public class CreateExerciseProfile : Profile
    {
        public CreateExerciseProfile()
        {
            CreateMap<CreateExerciseCommand, Exercise>();
            CreateMap<CreateExerciseFactObjectInputDto, FactObject>();
            CreateMap<CreateExerciseFactInputDto, FactInObject>();

            CreateMap<Exercise, CreateExerciseOutputDto>();
            CreateMap<FactObject, CreateExerciseFactObjectOutputDto>();
            CreateMap<FactInObject, CreateExerciseFactOutputDto>();
        }
    }
}
