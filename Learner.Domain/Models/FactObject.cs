namespace Learner.Domain.Models;

public class FactObject : BaseEntity
{
    public string Name { get; set; } = null!;
    public List<Fact> Facts { get; set; } = [];
    public Exercise Exercise { get; set; } = null!;
    public string ExerciseId { get; set; } = null!;

}