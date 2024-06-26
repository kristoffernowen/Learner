using MediatR;

namespace Learner.Application.Features.HandleExercises.SingleFactExercise.Queries.GetById;

public record GetSingleFactExerciseByIdQuery(string Id) : IRequest<GetSingleFactExerciseByIdOutputDto>;