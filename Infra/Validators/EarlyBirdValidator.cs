using Domain.DTOs;
using FluentValidation;

namespace Infra.Validators;

public class EarlyBirdValidator : BaseValidator<EarlyBirdDto>
{
    public EarlyBirdValidator()
    {
        RuleFor(x => x.IdFlag).NotNull();
        RuleFor(x => x.Flag).SetValidator(new FlagValidator());
    }
}
