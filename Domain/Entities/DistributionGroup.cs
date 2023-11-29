using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class DistributionGroup : BaseEntity
{
    public int PersonQty { get; set; }
    public required string AssociatedVersions { get; set; }
    public required string PropertyComparison { get; set; }
    public required string AssociatedValues { get; set; }

    public Guid IdDistributionRules { get; private set; }

    [ForeignKey("IdDistributionRules")]
    public virtual required DistributionRules DistributionRules { get; set; }
}
