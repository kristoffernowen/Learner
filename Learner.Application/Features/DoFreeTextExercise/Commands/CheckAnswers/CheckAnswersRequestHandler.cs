using AutoMapper;
using Learner.Application.Contracts.Repos;
using Learner.Application.Features.DoFreeTextExercise.Commands.CheckAnswers.Dtos;
using Learner.Domain.Models;
using Learner.Domain.Models.Results;
using MediatR;

namespace Learner.Application.Features.DoFreeTextExercise.Commands.CheckAnswers;

public class CheckAnswersRequestHandler(IExerciseRepository exorciseRepository, IMapper mapper) : IRequestHandler<CheckAnswersRequest, CheckAnswersRequestOutputDto>
{
    public async Task<CheckAnswersRequestOutputDto> Handle(CheckAnswersRequest request, CancellationToken cancellationToken)
    {
        var exerciseWithRightAnswers = await GetRightAnswers(request.Id);

        if (exerciseWithRightAnswers != null)
        {
            var result = CheckGivenAnswers(exerciseWithRightAnswers, request);

            return result;
        }
        else
        {
            throw new Exception($"Exercise with right answers not found but should exist in {nameof(CheckAnswersRequestHandler)}");
        }
    }

    private async Task<Exercise?> GetRightAnswers(string id)
    {
        var result = await exorciseRepository.GetByIdAsync(id);

        return result;
    }

    private CheckAnswersRequestOutputDto CheckGivenAnswers(Exercise exerciseWithRightAnswers, CheckAnswersRequest request)
    {
        var listWithCorrectAnswers =
            MakeListOfFactsWithTheCorrectAnswerForComparison(exerciseWithRightAnswers.FactObjects);

        var resultsPerFactList = CompareAnswersUtility.FreeTextComparison(request.AnswersPerFact, listWithCorrectAnswers);

        var resultsPerFactObject = GroupResultIntoFactObjects(resultsPerFactList, exerciseWithRightAnswers);

        var result = GroupIntoResultPerExercise(resultsPerFactObject);

        var resultDto = mapper.Map<CheckAnswersRequestOutputDto>(result);

        return resultDto;
    }

    private List<Fact> MakeListOfFactsWithTheCorrectAnswerForComparison(IEnumerable<FactObject> factObjects)
    {
        var result = (from rightAnswer in factObjects
            from fact in rightAnswer.Facts
            select fact).ToList();

        return result;
    }

    private List<ResultPerFactObject> GroupResultIntoFactObjects(List<ResultPerFact> resultsPerFacts, Exercise exerciseToExtractNames)
    {
        var perFactObjects = (from fact in resultsPerFacts
            group fact by fact.FactObjectId
            into factObject
            select new ResultPerFactObject()
            {
                Id = factObject.Key,
                Name = (exerciseToExtractNames.FactObjects.Single(x => x.Id == factObject.Key)).Name,
                PerFacts = factObject.Where(x => x.FactObjectId == factObject.Key).ToList()
            }).ToList();
        return perFactObjects;
    }

    private ResultPerExercise GroupIntoResultPerExercise(List<ResultPerFactObject> factObjects)
    {
        var result = new ResultPerExercise();
        foreach (var factObject in factObjects)
        {
            result.PerFactObjects.Add(factObject);
        }

        return result;
    }
}