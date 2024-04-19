using AutoMapper;
using Learner.Application.Contracts.Repos;
using Learner.Application.Features.DoFreeTextExercise.Queries.StartExercise.Dtos;
using MediatR;

namespace Learner.Application.Features.DoFreeTextExercise.Queries.StartExercise;

public class StartExerciseQueryHandler(IExerciseRepository exerciseRepository, IMapper mapper) : IRequestHandler<StartExerciseQuery, GetExerciseWithoutAnswersOutputDto?>
{
    public async Task<GetExerciseWithoutAnswersOutputDto?> Handle(StartExerciseQuery request, CancellationToken cancellationToken)
    {
        var exercise = await exerciseRepository.GetByIdAsync(request.Id);

        if (exercise == null) return null;
        
        exercise = SetFactValuesToEmptyUtility.SetToEmpty(exercise);

        var exerciseDto = mapper.Map<GetExerciseWithoutAnswersOutputDto>(exercise);

        return exerciseDto;
    }
}