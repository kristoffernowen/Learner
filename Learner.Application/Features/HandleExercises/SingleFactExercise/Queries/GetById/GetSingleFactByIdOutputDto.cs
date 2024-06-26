namespace Learner.Application.Features.HandleExercises.SingleFactExercise.Queries.GetById;

public class GetSingleFactByIdOutputDto
{
    public string Id { get; set; } = null!;
    public string SingleFactExerciseId { get; set; } = null!;
    public string FactName { get; set; } = null!;
    public string FactType { get; set; } = null!;
    public string FactValue { get; set; } = null!;
    public List<string> AdditionalTags { get; set; } = [];
}