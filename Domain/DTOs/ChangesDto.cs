namespace Domain.DTOs;

public class ChangesDto : BaseDto
{
    public required string Key { get; set; }
    public required string AttributeChanged { get; set; }
    public required string CurrentSituation { get; set; }
    public required string LastSituation { get; set; }
    public Guid IdFlag { get; private set; }
    public FlagDto Flag { get; set; }
}