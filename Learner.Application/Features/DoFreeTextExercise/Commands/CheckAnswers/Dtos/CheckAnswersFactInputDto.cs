namespace Learner.Application.Features.DoFreeTextExercise.Commands.CheckAnswers.Dtos;

public class CheckAnswersFactInputDto
{
    public string Id { get; set; } = null!;
    public string FactObjectId { get; set; } = null!;
    public string GivenAnswer { get; set; } = null!;
}