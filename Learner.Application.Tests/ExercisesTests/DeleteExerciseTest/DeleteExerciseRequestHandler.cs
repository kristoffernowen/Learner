using Learner.Application.Contracts.Repos;
using MediatR;

namespace Learner.Application.Tests.ExercisesTests.DeleteExerciseTest;

public class DeleteExerciseRequestHandler(IExerciseRepository exerciseRepository) : IRequestHandler<DeleteExerciseRequest, Unit>
{
    public async Task<Unit> Handle(DeleteExerciseRequest request, CancellationToken cancellationToken)
    {
        await exerciseRepository.DeleteAsync(request.Id);
            
        return Unit.Value;
    }
}