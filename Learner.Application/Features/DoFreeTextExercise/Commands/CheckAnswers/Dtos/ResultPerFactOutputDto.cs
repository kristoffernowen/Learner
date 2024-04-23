namespace Learner.Application.Features.DoFreeTextExercise.Commands.CheckAnswers.Dtos;

public class ResultPerFactOutputDto
{
    public string Id { get; set; } = null!;
    public string FactObjectId { get; set; } = null!;
    public string GivenAnswer { get; set; } = null!;
    public string CorrectAnswer { get; set; } = null!;
    public bool IsCorrect { get; set; }
}