using MediatR;

namespace Learner.Application.Tests.ExercisesTests.SingleFactExerciseTests;

public class CreateSingleFactExerciseCommand : IRequest<CreateSingleFactExerciseOutputDto>
{
    public string Name { get; set; } = null!;
    public List<CreateSingleFactExerciseFactInputDto> Facts { get; set; } = [];
}