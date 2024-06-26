﻿namespace Learner.Domain.Models
{
    public class Fact : BaseEntity
    {
        public string FactName { get; set; } = null!;
        public string FactType { get; set; } = null!;
        public string FactValue { get; set; } = null!;
        public List<bool> AdditionalTags { get; set; } = [];
        public FactObject FactObject { get; set; } = null!;
        public string FactObjectId { get; set; } = null!;
    }
}
