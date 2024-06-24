namespace Learner.Application.Tests.ExercisesTests.SingleFactExerciseTests;

public class CreateSingleFactExerciseOutputDto
{
    public string Name { get; set; } = null!;
    public List<CreateSingleFactExerciseFactOutputDto> Facts { get; set; } = [];

}