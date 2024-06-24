using Learner.Application.Contracts.Dtos;
using Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Input;
using Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Output;
using MediatR;

namespace Learner.Application.Features.HandleExercises.Commands.Create
{
    public class CreateExerciseCommand : IRequest<CreateExerciseOutputDto>, ICreateExerciseDto
    {
        public string Name { get; set; } = null!;
        public List<CreateExerciseFactObjectInputDto> FactObjects { get; set; } = [];
    }
}
