using AutoMapper;
using Learner.Application.Contracts.Repos;
using MediatR;

namespace Learner.Application.Features.HandleExercises.SingleFactExercise.Queries.GetById;

public class GetSingleFactExerciseByIdQueryHandler(ISingleFactExerciseRepository singleFactExerciseRepository,
    IMapper mapper) : IRequestHandler<GetSingleFactExerciseByIdQuery, GetSingleFactExerciseByIdOutputDto>
{
    public async Task<GetSingleFactExerciseByIdOutputDto> Handle(GetSingleFactExerciseByIdQuery request, CancellationToken cancellationToken)
    {
        var exercise = await singleFactExerciseRepository.GetByIdAsync(request.Id);
        var dto = mapper.Map<GetSingleFactExerciseByIdOutputDto>(exercise);

        return dto;
    }
}