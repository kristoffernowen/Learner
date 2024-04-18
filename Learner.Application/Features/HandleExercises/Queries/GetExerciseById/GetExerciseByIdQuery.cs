using Learner.Application.Features.HandleExercises.Queries.GetExerciseById.Dtos;
using MediatR;

namespace Learner.Application.Features.HandleExercises.Queries.GetExerciseById;

public record GetExerciseByIdQuery(string Id) : IRequest<GetExerciseByIdOutputDto>;