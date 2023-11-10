using Domain.CommandHandlers;
using Domain.Core.Validations;

namespace Domain.Validations
{
    public class NewRegrasDistribuicaoCommandValidation : RegrasDistribuicaoValidation<NewRegrasDistribuicaoCommand>
    {
        public NewRegrasDistribuicaoCommandValidation()
        {
            ValidateNome();
        }
    }

    public class UpdateRegrasDistribuicaoCommandValidation : RegrasDistribuicaoValidation<UpdateRegrasDistribuicaoCommand>
    {
        public UpdateRegrasDistribuicaoCommandValidation()
        {
            ValidateNome();
        }
    }

    public class RemoveRegrasDistribuicaoCommandValidation : RegrasDistribuicaoValidation<RemoveRegrasDistribuicaoCommand>
    {
        public RemoveRegrasDistribuicaoCommandValidation()
        {
        }
    }
}
