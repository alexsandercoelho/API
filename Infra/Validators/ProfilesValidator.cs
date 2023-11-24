using Domain.DTOs;
using FluentValidation;

namespace Infra.Validators;

public class ProfilesValidator : BaseValidator<ProfilesDto>
{
    public ProfilesValidator()
    {
    }
}
