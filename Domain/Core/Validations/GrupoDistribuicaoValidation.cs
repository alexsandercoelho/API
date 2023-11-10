using Domain.Commands;
using FluentValidation;

namespace Domain.Core.Validations
{
    public abstract class GrupoDistribuicaoValidation<T> : AbstractValidator<T> where T : GrupoDistribuicaoCommand
    {
        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty();
        }
    }
}
