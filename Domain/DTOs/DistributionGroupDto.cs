namespace Domain.DTOs;

public class DistributionGroupDto : BaseDto
{
    public int PersonQty { get; set; }
    public required string AssociatedVersions { get; set; }
    public required string PropertyComparison { get; set; }
    public required string AssociatedValues { get; set; }
    public Guid IdDistributionRules { get; set; }
    public DistributionRulesDto DistributionRules { get; set; }
}
