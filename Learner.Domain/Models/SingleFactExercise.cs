namespace Learner.Domain.Models
{
    public class SingleFactExercise : BaseEntity
    {
        public string Name { get; set; } = null!;
        public List<SingleFact> Facts { get; set; } = [];
        
    }

    public class SingleFact : BaseFact
    {
        public string SingleFactExerciseId { get; set; } = null!;
        public SingleFactExercise SingleFactExercise { get; set; } = null!;
    }
}
