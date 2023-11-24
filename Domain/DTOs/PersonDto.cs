namespace Domain.DTOs;

public class PersonDto : BaseDto
{
    public Guid IdProfile { get; set; }
    public ProfilesDto Profiles { get; set; }
}
