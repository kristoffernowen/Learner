namespace Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Output;

public class CreateExerciseFactObjectOutputDto
{
    public string Name { get; set; } = null!;
    public List<CreateExerciseFactOutputDto> Facts { get; set; } = [];
}