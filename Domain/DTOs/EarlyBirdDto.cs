namespace Domain.DTOs;

public class EarlyBirdDto : BaseDto
{
    public int QtyPeople { get; set; }
    public required string ComparisionProperty { get; set; }
    public Guid IdFlag { get; set; }
    public FlagDto Flag { get; set; }
}
