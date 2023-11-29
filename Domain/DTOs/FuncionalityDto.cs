namespace Domain.DTOs;

public class FuncionalityDto : BaseDto
{
    public Guid IdProfile { get; set; }
    public ProfilesDto Profiles { get; set; }
}
