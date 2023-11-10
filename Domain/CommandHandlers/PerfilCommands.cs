using Domain.Commands;
using Domain.Validations;

namespace Domain.CommandHandlers
{
    public class NewPerfilCommand : PerfilCommand
    {
        public NewPerfilCommand(string nome)
        {
            Nome = nome;
            DataInclusao = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }   

        public override bool IsValid()
        {
            ValidationResult = new NewPerfilCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdatePerfilCommand : PerfilCommand
    {
        public UpdatePerfilCommand(int id, string nome)
        {
            Id = id;
            Nome = nome;
            DataAtualizacao = DateTime.Now;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePerfilCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RemovePerfilCommand : PerfilCommand
    {
        public RemovePerfilCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemovePerfilCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}