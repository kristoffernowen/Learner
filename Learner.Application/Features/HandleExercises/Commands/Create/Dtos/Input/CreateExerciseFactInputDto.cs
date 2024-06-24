namespace Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Input;

public interface ICreateExerciseFactInputDto
{
    string FactName { get; set; }
    string FactType { get; set; }
    string FactValue { get; set; }
}

public class CreateExerciseFactInputDto : ICreateExerciseFactInputDto
{
    public string FactName { get; set; } = null!;
    public string FactType { get; set; } = null!;
    public string FactValue { get; set; } = null!;
}