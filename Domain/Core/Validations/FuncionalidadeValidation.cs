using Domain.Commands;
using FluentValidation;

namespace Domain.Core.Validations
{
    public abstract class FuncionalidadeValidation<T> : AbstractValidator<T> where T : FuncionalidadeCommand
    {
        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty();
        }
    }
}
