namespace Domain.DTOs;

public class BaseDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; } 
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow.ToLocalTime();
}