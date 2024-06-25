namespace Learner.Domain.Models;

public class SingleFact : BaseFact
{
    public string SingleFactExerciseId { get; set; } = null!;
    public SingleFactExercise SingleFactExercise { get; set; } = null!;
}