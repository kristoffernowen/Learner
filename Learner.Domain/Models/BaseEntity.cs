using System.ComponentModel.DataAnnotations;

namespace Learner.Domain.Models
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; } = null!;
    }
}
