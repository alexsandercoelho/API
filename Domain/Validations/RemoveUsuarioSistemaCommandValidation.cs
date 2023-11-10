using Domain.CommandHandlers;
using Domain.Core.Validations;

namespace Domain.Validations
{
    public class RemoveUsuarioSistemaCommandValidation : UsuarioSistemaValidation<RemoveUsuarioSistemaCommand>
    {
        public RemoveUsuarioSistemaCommandValidation()
        {
        }
    }
}
