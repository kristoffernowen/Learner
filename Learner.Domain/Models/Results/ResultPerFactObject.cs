namespace Learner.Application.Tests.DoExercisesTests.CheckAnswersHelpers.Result;

public class ResultPerFactObject
{
    public string Id { get; set; } = null!;
    public List<ResultPerFact> PerFacts { get; set; } = [];
}