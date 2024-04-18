namespace Learner.Application.Features.HandleExercises.Queries.GetExerciseById.Dtos;

public class GetExerciseByIdFactOutputDto
{
    public string Id { get; set; } = null!;
    public string FactObjectId { get; set; } = null!;
    public string FactName { get; set; } = null!;
    public string FactType { get; set; } = null!;
    public string FactValue { get; set; } = null!;

}