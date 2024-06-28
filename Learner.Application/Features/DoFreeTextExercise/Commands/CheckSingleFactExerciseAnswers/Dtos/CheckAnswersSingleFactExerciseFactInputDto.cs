namespace Learner.Application.Features.DoFreeTextExercise.Commands.CheckSingleFactExerciseAnswers.Dtos;

public record CheckAnswersSingleFactExerciseFactInputDto
{
    public string Id { get; set; } = null!;
    public string GivenAnswer { get; set; } = null!;
}