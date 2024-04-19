namespace Learner.Application.Features.BaseDtos;

public abstract class GetExerciseByIdFactBaseDto
{
    public string Id { get; set; } = null!;
    public string FactObjectId { get; set; } = null!;
    public string FactName { get; set; } = null!;
    public string FactType { get; set; } = null!;
    public string FactValue { get; set; } = null!;
}