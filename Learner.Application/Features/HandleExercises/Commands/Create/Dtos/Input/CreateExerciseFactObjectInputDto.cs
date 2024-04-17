namespace Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Input;

public class CreateExerciseFactObjectInputDto
{
    public string Name { get; set; } = null!;
    public List<CreateExerciseFactInputDto> Facts { get; set; } = [];
}