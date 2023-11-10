using Domain.CommandHandlers;
using Domain.Core.Validations;

namespace Domain.Validations
{
    public class NewFuncionalidadeCommandValidation : FuncionalidadeValidation<NewFuncionalidadeCommand>
    {
        public NewFuncionalidadeCommandValidation()
        {
            ValidateNome();
        }
    }

    public class UpdateFuncionalidadeCommandValidation : FuncionalidadeValidation<UpdateFuncionalidadeCommand>
    {
        public UpdateFuncionalidadeCommandValidation()
        {
            ValidateNome();
        }
    }

    public class RemoveFuncionalidadeCommandValidation : FuncionalidadeValidation<RemoveFuncionalidadeCommand>
    {
        public RemoveFuncionalidadeCommandValidation()
        {
        }
    }
}
