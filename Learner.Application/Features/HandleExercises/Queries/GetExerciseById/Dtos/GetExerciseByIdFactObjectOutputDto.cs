namespace Learner.Application.Features.HandleExercises.Queries.GetExerciseById.Dtos;

public class GetExerciseByIdFactObjectOutputDto
{
    public string Name { get; set; } = null!;
    public string Id { get; set; } = null!;
    public string ExerciseId { get; set; } = null!;
    public List<GetExerciseByIdFactOutputDto> Facts { get; set; } = [];
}