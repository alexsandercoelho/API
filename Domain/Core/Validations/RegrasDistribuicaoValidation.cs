using Domain.Commands;
using FluentValidation;

namespace Domain.Core.Validations
{
    public abstract class RegrasDistribuicaoValidation<T> : AbstractValidator<T> where T : RegrasDistribuicaoCommand
    {
        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty();
        }
    }
}
