using Learner.Application.Contracts.Repos;
using Learner.Application.Features.DoFreeTextExercise.Commands.CheckSingleFactExerciseAnswers.Dtos;
using Learner.Application.Helpers;
using MediatR;

namespace Learner.Application.Features.DoFreeTextExercise.Commands.CheckSingleFactExerciseAnswers;

public class CheckAnswersSingleFactExerciseHandler(
    ISingleFactExerciseRepository singleFactExerciseRepository
)
    : IRequestHandler<CheckAnswersSingleFactExerciseQuery, CheckAnswersSingleFactExerciseResultOutputDto>
{

    public async Task<CheckAnswersSingleFactExerciseResultOutputDto> Handle(CheckAnswersSingleFactExerciseQuery request, CancellationToken cancellationToken)
    {
        var exerciseWithRightAnswers = await singleFactExerciseRepository.GetByIdAsync(request.Id);
        if (exerciseWithRightAnswers is null) throw new Exception("exercise must exist or some logic is faulty");

        var outputDto = new CheckAnswersSingleFactExerciseResultOutputDto()
        {
            Id = exerciseWithRightAnswers.Id,
            Name = exerciseWithRightAnswers.Name
        };
        foreach (var answer in request.AnswersPerFact)
        {
            var fact = exerciseWithRightAnswers?.Facts.First(x => x.Id == answer.Id);
            if (fact == null) throw new Exception("no fact with id for answer");
            var result = new CheckSingleFactExerciseResultPerFactOutputDto()
            {
                FactName = fact.FactName,
                CorrectAnswer = fact.FactValue,
                FactId = fact.Id,
                GivenAnswer = answer.GivenAnswer
            };
            result.IsCorrect = SingleFactCompareAnswersUtility.AnswersAreEqual(answer.GivenAnswer, fact);
            outputDto.Results.Add(result);
        }

        return outputDto;
    }
}