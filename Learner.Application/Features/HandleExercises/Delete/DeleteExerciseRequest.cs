using MediatR;

namespace Learner.Application.Features.HandleExercises.Delete;

public record DeleteExerciseRequest(string Id) : IRequest<Unit>;