using Learner.Application.Tests.ExercisesTests.SingleFactExerciseTests;
using MediatR;

namespace Learner.Application.Features.HandleExercises.SingleFactExercise.Queries.GetAll;

public record GetSingleFactExercisesQuery : IRequest<List<GetSingleFactExercisesOutputDto>>;