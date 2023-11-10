using Domain.Commands;
using FluentValidation;

namespace Domain.Core.Validations
{
    public abstract class PessoaValidation<T> : AbstractValidator<T> where T : PessoaCommand
    {
        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty();
        }
    }
}
