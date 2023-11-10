using Domain.CommandHandlers;
using Domain.Core.Validations;

namespace Domain.Validations
{
    public class NewGrupoDistribuicaoCommandValidation : GrupoDistribuicaoValidation<NewGrupoDistribuicaoCommand>
    {
        public NewGrupoDistribuicaoCommandValidation()
        {
            ValidateNome();
        }
    }

    public class UpdateGrupoDistribuicaoCommandValidation : GrupoDistribuicaoValidation<UpdateGrupoDistribuicaoCommand>
    {
        public UpdateGrupoDistribuicaoCommandValidation()
        {
            ValidateNome();
        }
    }

    public class RemoveGrupoDistribuicaoCommandValidation : GrupoDistribuicaoValidation<RemoveGrupoDistribuicaoCommand>
    {
        public RemoveGrupoDistribuicaoCommandValidation()
        {
        }
    }
}
