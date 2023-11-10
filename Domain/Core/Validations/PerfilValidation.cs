using Domain.Commands;
using FluentValidation;

namespace Domain.Core.Validations
{
    public abstract class PerfilValidation<T> : AbstractValidator<T> where T : PerfilCommand
    {
        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty();
        }
    }
}
