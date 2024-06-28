namespace Learner.Application.Features.DoFreeTextExercise.Commands.CheckSingleFactExerciseAnswers.Dtos;

public record CheckAnswersSingleFactExerciseResultOutputDto
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public List<CheckSingleFactExerciseResultPerFactOutputDto> Results { get; set; } = [];
}