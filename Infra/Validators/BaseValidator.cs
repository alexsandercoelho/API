using Domain.DTOs;
using FluentValidation;

namespace Infra.Validators;

public class BaseValidator<T> : AbstractValidator<T> where T : BaseDto
{
    public BaseValidator()
    {
        RuleFor(x => x.Name).NotNull();
        RuleFor(x => x.CreateDate).NotNull();
        RuleFor(x => x.LastUpdated).NotNull();
    }
}
