using AutoMapper;
using Learner.Application.Contracts.Repos;
using Learner.Application.Features.HandleExercises.Queries.GetExerciseById.Dtos;
using MediatR;

namespace Learner.Application.Features.HandleExercises.Queries.GetExerciseById;

public class GetExerciseByIdQueryHandler(IExerciseRepository exerciseRepository, IMapper mapper) : IRequestHandler<GetExerciseByIdQuery, GetExerciseByIdOutputDto>
{
    public async Task<GetExerciseByIdOutputDto> Handle(GetExerciseByIdQuery request, CancellationToken cancellationToken)
    {
        var exercise = await exerciseRepository.GetByIdAsync(request.Id);
        var exerciseDto = mapper.Map<GetExerciseByIdOutputDto>(exercise);

        return exerciseDto;
    }
}