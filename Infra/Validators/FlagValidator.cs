using Domain.DTOs;
using FluentValidation;

namespace Infra.Validators;

public class FlagValidator : BaseValidator<FlagDto>
{
    public FlagValidator()
    {
    }
}
