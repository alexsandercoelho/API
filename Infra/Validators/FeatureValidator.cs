using Domain.DTOs;
using FluentValidation;

namespace Infra.Validators;

public class FeatureValidator : BaseValidator<FeatureDto>
{
    public FeatureValidator()
    {
        RuleFor(x => x.IdProfile).NotNull();
        RuleFor(x => x.Profiles).SetValidator(new ProfilesValidator());
    }
}
