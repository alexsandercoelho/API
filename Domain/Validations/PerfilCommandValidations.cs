using Domain.CommandHandlers;
using Domain.Core.Validations;

namespace Domain.Validations
{
    public class NewPerfilCommandValidation : PerfilValidation<NewPerfilCommand>
    {
        public NewPerfilCommandValidation()
        {
            ValidateNome();
        }
    }

    public class UpdatePerfilCommandValidation : PerfilValidation<UpdatePerfilCommand>
    {
        public UpdatePerfilCommandValidation()
        {
            ValidateNome();
        }
    }

    public class RemovePerfilCommandValidation : PerfilValidation<RemovePerfilCommand>
    {
        public RemovePerfilCommandValidation()
        {
        }
    }
}
