using MediatR;

namespace Learner.Application.Tests.ExercisesTests.SingleFactExerciseTests;

public class CreateSingleFactExerciseHandler : IRequestHandler<CreateSingleFactExerciseCommand, CreateSingleFactExerciseOutputDto>
{
    public Task<CreateSingleFactExerciseOutputDto> Handle(CreateSingleFactExerciseCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}