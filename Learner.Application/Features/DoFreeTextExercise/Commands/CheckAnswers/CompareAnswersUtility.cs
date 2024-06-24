using Learner.Application.Features.DoFreeTextExercise.Commands.CheckAnswers.Dtos;
using Learner.Domain.Models;
using Learner.Domain.Models.Results;

namespace Learner.Application.Features.DoFreeTextExercise.Commands.CheckAnswers;

public class CompareAnswersUtility
{
    public static List<ResultPerFact> FreeTextComparison(IEnumerable<CheckAnswersFactInputDto> givenAnswers,
        List<FactInObject> correctAnswers)
    {
        var resultPerFactList = new List<ResultPerFact>();
        foreach (var inputDto in givenAnswers)
        {
            var factResult = new ResultPerFact()
            {
                Id = inputDto.Id,
                FactName = (from rightAnswer in correctAnswers
                    where rightAnswer.Id == inputDto.Id
                    select rightAnswer.FactName).First(),
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