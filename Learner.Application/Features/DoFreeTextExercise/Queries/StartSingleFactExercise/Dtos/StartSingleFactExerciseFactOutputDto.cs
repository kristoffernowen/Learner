namespace Learner.Application.Features.DoFreeTextExercise.Queries.StartSingleFactExercise.Dtos;

public class StartSingleFactExerciseFactOutputDto
{
    public string Id { get; set; } = null!;
    public string FactName { get; set; } = null!;
    public string FactType { get; set; } = null!;
    public string FactValue { get; set; } = null!;
    public List<string> AdditionalTags { get; set; } = [];
}