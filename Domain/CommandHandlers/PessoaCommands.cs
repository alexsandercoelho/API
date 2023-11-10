using Domain.Commands;
using Domain.Validations;

namespace Domain.CommandHandlers
{
    public class NewPessoaCommand : PessoaCommand
    {
        public NewPessoaCommand(string nome, int perfilId)
        {
            Nome = nome;
            PerfilId = perfilId;
        }

        public override bool IsValid()
        {
            ValidationResult = new NewPessoaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdatePessoaCommand : PessoaCommand
    {
        public UpdatePessoaCommand(string nome, int perfilId)
        {
            Nome = nome;
            PerfilId = perfilId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePessoaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RemovePessoaCommand : PessoaCommand
    {
        public RemovePessoaCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemovePessoaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}