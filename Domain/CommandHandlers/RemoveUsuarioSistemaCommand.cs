using Domain.Commands;
using Domain.Validations;

namespace Domain.CommandHandlers
{
    public class RemoveUsuarioSistemaCommand : UsuarioSistemaCommand
    {
        public RemoveUsuarioSistemaCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveUsuarioSistemaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
