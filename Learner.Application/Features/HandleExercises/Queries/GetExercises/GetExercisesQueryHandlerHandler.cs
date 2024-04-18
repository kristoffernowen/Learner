using AutoMapper;
using Learner.Application.Contracts.Repos;
using MediatR;

namespace Learner.Application.Features.HandleExercises.Queries.GetExercises;

public class GetExercisesQueryHandler(IExerciseRepository exerciseRepo, IMapper mapper) : IRequestHandler<GetExercisesQuery, List<GetExercisesOutputDto>>
{
    public async Task<List<GetExercisesOutputDto>> Handle(GetExercisesQuery request, CancellationToken cancellationToken)
    {
        var listOfExercises = await exerciseRepo.GetAllAsync();

        var result = mapper.Map<List<GetExercisesOutputDto>>(listOfExercises);

        return result;
    }
}