using Domain.Commands;
using FluentValidation;

namespace Domain.Core.Validations
{
    public abstract class UsuarioSistemaValidation<T> : AbstractValidator<T> where T : UsuarioSistemaCommand
    {
        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty();
        }
    }
}
