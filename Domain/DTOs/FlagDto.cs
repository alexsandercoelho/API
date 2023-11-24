namespace Domain.DTOs;

public class FlagDto : BaseDto
{
    public required string PackageVersion { get; set; }
    public required string Key { get; set; }
    public required string Situation { get; set; }
}
