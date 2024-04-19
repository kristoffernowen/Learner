namespace Learner.Application.Features.BaseDtos;

public abstract class GetExerciseByIdExerciseBaseDto<T> where T : class
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public List<T> FactObjects { get; set; } = [];
}