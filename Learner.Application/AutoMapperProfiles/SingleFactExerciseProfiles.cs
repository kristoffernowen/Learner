using AutoMapper;
using Learner.Application.Features.HandleExercises.SingleFactExercise.Commands.Create.Dtos;
using Learner.Application.Features.HandleExercises.SingleFactExercise.Queries.GetById;
using Learner.Application.Tests.ExercisesTests.SingleFactExerciseTests;
using Learner.Domain.Models;

namespace Learner.Application.AutoMapperProfiles
{
    public class SingleFactExerciseProfiles : Profile
    {
        public SingleFactExerciseProfiles()
        {
            CreateMap<SingleFactExercise, CreateSingleFactExerciseOutputDto>();
            CreateMap<SingleFact, CreateSingleFactExerciseFactOutputDto>();
            CreateMap<SingleFactExercise, GetSingleFactExercisesOutputDto>();
            CreateMap<SingleFactExercise, GetSingleFactExerciseByIdOutputDto>();
            CreateMap<SingleFact, GetSingleFactByIdOutputDto>();
        }
    }
}
