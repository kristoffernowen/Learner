namespace Learner.Domain.Models
{
    public class SingleFactExercise : BaseEntity
    {
        public string Name { get; set; } = null!;
        public List<SingleFact> Facts { get; set; } = [];
        
    }
}
