using Domain.Commands;
using Domain.Validations;

namespace Domain.CommandHandlers
{
    public class UpdateUsuarioSistemaCommand : UsuarioSistemaCommand
    {
        public UpdateUsuarioSistemaCommand(string email, bool administrador, bool sistemaAtual, int idSistema)
        {
            Email = email;
            Administrador = administrador;
            SistemaAtual = sistemaAtual;
            IdSistema = idSistema;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateUsuarioSistemaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
