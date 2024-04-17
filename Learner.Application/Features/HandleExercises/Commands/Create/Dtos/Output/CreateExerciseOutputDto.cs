namespace Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Output;

public class CreateExerciseOutputDto
{
    public string Name { get; set; } = null!;
    public List<CreateExerciseFactObjectOutputDto> FactObjects { get; set; } = [];
}