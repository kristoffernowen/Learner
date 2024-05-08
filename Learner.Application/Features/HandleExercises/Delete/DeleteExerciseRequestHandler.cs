using Learner.Application.Contracts.Repos;
using MediatR;

namespace Learner.Application.Features.HandleExercises.Delete;

public class DeleteExerciseRequestHandler(IExerciseRepository exerciseRepository) : IRequestHandler<DeleteExerciseRequest, Unit>
{
    public async Task<Unit> Handle(DeleteExerciseRequest request, CancellationToken cancellationToken)
    {
        var exercise = await exerciseRepository.GetByIdAsync(request.Id);

        if (exercise != null)
        {
            await exerciseRepository.DeleteAsync(request.Id);
        }
            
        return Unit.Value;
    }
}