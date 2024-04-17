using Learner.Application.Features.HandleExercises.Commands.Create.Dtos.Input;

namespace Learner.Application.Contracts.Dtos;

public interface ICreateExerciseDto
{
    public string Name { get; set; }
    public List<CreateExerciseFactObjectInputDto> FactObjects { get; set; }
}