namespace Learner.Domain.Models
{
    public class FactInObject : BaseFact
    {
        public FactObject FactObject { get; set; } = null!;
        public string FactObjectId { get; set; } = null!;
    }
}
