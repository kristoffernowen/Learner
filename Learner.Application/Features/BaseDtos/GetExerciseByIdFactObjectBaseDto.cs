namespace Learner.Application.Features.BaseDtos;

public abstract class GetExerciseByIdFactObjectBaseDto<T> where T : class
{
    public string Name { get; set; } = null!;
    public string Id { get; set; } = null!;
    public string ExerciseId { get; set; } = null!;
    public List<T> Facts { get; set; } = [];
}