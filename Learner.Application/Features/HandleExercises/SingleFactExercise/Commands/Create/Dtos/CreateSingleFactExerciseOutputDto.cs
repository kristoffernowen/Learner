using Learner.Application.Tests.ExercisesTests.SingleFactExerciseTests;

namespace Learner.Application.Features.HandleExercises.SingleFactExercise.Commands.Create.Dtos;

public class CreateSingleFactExerciseOutputDto
{
    public string Name { get; set; } = null!;
    public List<CreateSingleFactExerciseFactOutputDto> Facts { get; set; } = [];

}