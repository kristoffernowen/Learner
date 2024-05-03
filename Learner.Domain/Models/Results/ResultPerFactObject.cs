namespace Learner.Domain.Models.Results;

public class ResultPerFactObject
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public List<ResultPerFact> PerFacts { get; set; } = [];
}