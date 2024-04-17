namespace Learner.Domain.Models;

public class Exercise : BaseEntity
{
    public string Name { get; set; } = null!;
    public List<FactObject> FactObjects { get; set; } = [];
}