using AutoMapper;
using Learner.Application.Contracts.Repos;
using Learner.Application.Tests.ExercisesTests.SingleFactExerciseTests;
using MediatR;

namespace Learner.Application.Features.HandleExercises.SingleFactExercise.Queries.GetAll;

public class GetSingleFactExercisesQueryHandler(
    ISingleFactExerciseRepository singleFactExerciseRepository,
    IMapper mapper)
    : IRequestHandler<GetSingleFactExercisesQuery, List<GetSingleFactExercisesOutputDto>>
{
    public async Task<List<GetSingleFactExercisesOutputDto>> Handle(GetSingleFactExercisesQuery request, CancellationToken cancellationToken)
    {
        var singleFactExercises = await singleFactExerciseRepository.GetAllAsync();

        return mapper.Map<List<GetSingleFactExercisesOutputDto>>(singleFactExercises);
    }
}