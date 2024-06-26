namespace Learner.Application.Features.HandleExercises.SingleFactExercise.Queries.GetById;

public class GetSingleFactExerciseByIdOutputDto
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;
    public List<GetSingleFactByIdOutputDto> Facts { get; set; } = [];
}