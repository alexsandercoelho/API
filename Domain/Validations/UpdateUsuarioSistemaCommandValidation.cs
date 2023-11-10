using Domain.CommandHandlers;
using Domain.Core.Validations;

namespace Domain.Validations
{
    public class UpdateUsuarioSistemaCommandValidation : UsuarioSistemaValidation<UpdateUsuarioSistemaCommand>
    {
        public UpdateUsuarioSistemaCommandValidation()
        {
        }
    }

}
