using MediatR;

namespace Learner.Application.Features.HandleExercises.Queries.GetExercises;

public record GetExercisesQuery : IRequest<List<GetExercisesOutputDto>>;