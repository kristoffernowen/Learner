using Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Input;

namespace Learner.Application.Tests.ExercisesTests.SingleFactExerciseTests;

public class CreateSingleFactExerciseFactInputDto : ICreateExerciseFactInputDto
{
    public string FactName { get; set; } = null!;
    public string FactType { get; set; } = null!;
    public string FactValue { get; set; } = null!;
}