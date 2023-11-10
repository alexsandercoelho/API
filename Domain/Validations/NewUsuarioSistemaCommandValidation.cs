using Domain.CommandHandlers;
using Domain.Core.Validations;

namespace Domain.Validations
{
    public class NewUsuarioSistemaCommandValidation : UsuarioSistemaValidation<NewUsuarioSistemaCommand>
    {
        public NewUsuarioSistemaCommandValidation()
        {
            ValidateEmail();
        }
    }

}
