namespace Learner.Application.Features.DoFreeTextExercise.Commands.CheckAnswers.Dtos;

public class ResultPerFactObjectOutputDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public List<ResultPerFactOutputDto> PerFacts { get; set; } = [];
}