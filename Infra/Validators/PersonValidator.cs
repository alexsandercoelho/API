using Domain.DTOs;
using FluentValidation;

namespace Infra.Validators;

public class PersonValidator : BaseValidator<PersonDto>
{
    public PersonValidator()
    {
        RuleFor(x => x.IdProfile).NotNull();
        RuleFor(x => x.Profiles).SetValidator(new ProfilesValidator());
    }
}
