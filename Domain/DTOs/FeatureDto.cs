namespace Domain.DTOs;

public class FeatureDto : BaseDto
{
    public Guid IdProfile { get; set; }
    public ProfilesDto Profiles { get; set; }
}
