namespace Learner.Application.Features.HandleExercises.SingleFactExercise.Commands.Create.Dtos;

public class CreateSingleFactExerciseFactOutputDto
{
    public string FactName { get; set; } = null!;
    public string FactType { get; set; } = null!;
    public string FactValue { get; set; } = null!;
}