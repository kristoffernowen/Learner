namespace Learner.Domain.Models.Results;

public class ResultPerFact
{
    public string Id { get; set; } = null!;
    public string FactObjectId { get; set; } = null!;
    public string GivenAnswer { get; set; } = null!;
    public string CorrectAnswer { get; set; } = null!;
    public bool IsCorrect { get; set; }
    public string FactName { get; set; } = null!;
}