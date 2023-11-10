using Domain.Commands;
using Domain.Validations;

namespace Domain.CommandHandlers
{
    public class NewUsuarioSistemaCommand : UsuarioSistemaCommand
    {
        public NewUsuarioSistemaCommand(string email, bool administrador, bool sistemaAtual, int idSistema)
        {
            Email = email;
            Administrador = administrador;
            SistemaAtual = sistemaAtual;
            IdSistema = idSistema;
        }

        public override bool IsValid()
        {
            ValidationResult = new NewUsuarioSistemaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}