namespace Domain.Entities;

public class DistributionRules : BaseEntity
{
    public required string PackageVersion { get; set; }

    public virtual required IList<DistributionGroup> DistributionGroups { get; set; }
}
