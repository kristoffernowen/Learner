namespace Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Input;

public class CreateExerciseFactInputDto
{
    public string FactName { get; set; } = null!;
    public string FactType { get; set; } = null!;
    public string FactValue { get; set; } = null!;
}