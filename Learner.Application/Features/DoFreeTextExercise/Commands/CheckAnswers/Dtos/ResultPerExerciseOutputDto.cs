using Learner.Application.Tests.DoExercisesTests.CheckAnswersHelpers.Result;

namespace Learner.Application.Features.DoFreeTextExercise.Commands.CheckAnswers.Dtos;

public class ResultPerExerciseOutputDto
{
    public List<ResultPerFactObject> PerFactObjects { get; set; } = [];
}