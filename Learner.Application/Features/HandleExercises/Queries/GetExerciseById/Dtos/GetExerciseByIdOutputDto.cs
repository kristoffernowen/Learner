namespace Learner.Application.Features.HandleExercises.Queries.GetExerciseById.Dtos;

public class GetExerciseByIdOutputDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public List<GetExerciseByIdFactObjectOutputDto> FactObjects { get; set; } = [];
}