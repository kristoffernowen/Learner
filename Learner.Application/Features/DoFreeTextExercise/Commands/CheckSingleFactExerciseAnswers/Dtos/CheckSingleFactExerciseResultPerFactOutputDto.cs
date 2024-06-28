namespace Learner.Application.Features.DoFreeTextExercise.Commands.CheckSingleFactExerciseAnswers.Dtos;

public record CheckSingleFactExerciseResultPerFactOutputDto
{
    public string FactId { get; set; } = null!;
    public string FactName { get; set; } = null!;
    public string GivenAnswer { get; set; } = null!;
    public string CorrectAnswer { get; set; } = null!;
    public bool IsCorrect { get; set; }
}