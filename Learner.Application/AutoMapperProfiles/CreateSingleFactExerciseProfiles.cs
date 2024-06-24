using AutoMapper;
using Learner.Application.Features.HandleExercises.SingleFactExercise.Commands.Create.Dtos;
using Learner.Domain.Models;

namespace Learner.Application.Tests.ExercisesTests.SingleFactExerciseTests
{
    public class CreateSingleFactExerciseProfiles : Profile
    {
        public CreateSingleFactExerciseProfiles()
        {
            CreateMap<SingleFactExercise, CreateSingleFactExerciseOutputDto>();
            CreateMap<SingleFact, CreateSingleFactExerciseFactOutputDto>();
        }
    }
}
