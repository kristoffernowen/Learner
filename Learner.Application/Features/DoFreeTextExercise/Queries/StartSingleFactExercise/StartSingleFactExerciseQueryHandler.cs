using Learner.Application.Contracts.Repos;
using Learner.Application.Features.DoFreeTextExercise.Queries.StartSingleFactExercise.Dtos;
using MediatR;

namespace Learner.Application.Features.DoFreeTextExercise.Queries.StartSingleFactExercise;

public class StartSingleFactExerciseQueryHandler(ISingleFactExerciseRepository singleFactExerciseRepository) : IRequestHandler<StartSingleFactExerciseQuery, StartSingleFactExerciseOutputDto>
{
    public async Task<StartSingleFactExerciseOutputDto> Handle(StartSingleFactExerciseQuery request, CancellationToken cancellationToken)
    {
        var exercise = await singleFactExerciseRepository.GetByIdAsync(request.Id);

        if (exercise is null) throw new NullReferenceException();

        var outputFactsWithoutAnswers = exercise.Facts.Select(x => new StartSingleFactExerciseFactOutputDto
        {
            Id = x.Id,
            FactName = x.FactName,
            FactType = x.FactType,
            FactValue = "",
            AdditionalTags = x.AdditionalTags
        }).ToList();

        return new StartSingleFactExerciseOutputDto
        {
            Id = exercise.Id,
            Name = exercise.Name,
            Facts = outputFactsWithoutAnswers
        };
    }
}