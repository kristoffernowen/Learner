using MediatR;

namespace Learner.Application.Tests.ExercisesTests.DeleteExerciseTest;

public record DeleteExerciseRequest(string Id) : IRequest<Unit>;