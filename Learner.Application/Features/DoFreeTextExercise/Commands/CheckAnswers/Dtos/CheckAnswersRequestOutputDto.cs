namespace Learner.Application.Features.DoFreeTextExercise.Commands.CheckAnswers.Dtos;

public class CheckAnswersRequestOutputDto
{
    public List<ResultPerFactObjectOutputDto> PerFactObjects { get; set; } = [];
}