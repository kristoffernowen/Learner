using Learner.Application.Features.HandleExercises.SingleFactExercise.Commands.Create.Dtos;
using Learner.Application.Tests.ExercisesTests.SingleFactExerciseTests;
using MediatR;

namespace Learner.Application.Features.HandleExercises.SingleFactExercise.Commands.Create;

public class CreateSingleFactExerciseCommand : IRequest<CreateSingleFactExerciseOutputDto>, ICreateSingleFactExerciseInputDto
{
    public string Name { get; set; } = null!;
    public List<CreateSingleFactExerciseFactInputDto> Facts { get; set; } = [];
}