using Learner.Domain.Models.Results;

namespace Learner.Application.Features.DoFreeTextExercise.Commands.CheckAnswers.Dtos;

public class ResultPerExerciseOutputDto
{
    public List<ResultPerFactObject> PerFactObjects { get; set; } = [];
}