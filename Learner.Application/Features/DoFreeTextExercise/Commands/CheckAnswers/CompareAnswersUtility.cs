using Learner.Application.Features.DoFreeTextExercise.Commands.CheckAnswers.Dtos;
using Learner.Application.Tests.DoExercisesTests.CheckAnswersHelpers.Result;
using Learner.Domain.Models;

namespace Learner.Application.Features.DoFreeTextExercise.Commands.CheckAnswers;

public class CompareAnswersUtility
{
    public static List<ResultPerFact> FreeTextComparison(IEnumerable<CheckAnswersFactInputDto> givenAnswers,
        List<Fact> correctAnswers)
    {
        var resultPerFactList = new List<ResultPerFact>();
        foreach (var inputDto in givenAnswers)
        {
            var factResult = new ResultPerFact()
            {
                Id = inputDto.Id,
                FactObjectId = inputDto.FactObjectId,
                CorrectAnswer = (from rightAnswer in correctAnswers
                    where rightAnswer.Id == inputDto.Id
                    select rightAnswer.FactValue).First(),
                GivenAnswer = inputDto.GivenAnswer,
                IsCorrect = (from ra in correctAnswers
                    where ra.Id == inputDto.Id
                    let status = ra.FactValue == inputDto.GivenAnswer
                    select status).First()
            };
            resultPerFactList.Add(factResult);
        }

        return resultPerFactList;
    }
}