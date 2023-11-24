using Domain.DTOs;
using FluentValidation;

namespace Infra.Validators;

public class ChangesValidator : BaseValidator<ChangesDto>
{
    public ChangesValidator()
    {
        RuleFor(x => x.IdFlag).NotNull();
        RuleFor(x => x.Flag).SetValidator(new FlagValidator());
    }
}