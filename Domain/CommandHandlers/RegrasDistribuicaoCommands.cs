using Domain.Commands;
using Domain.Validations;

namespace Domain.CommandHandlers
{
    public class NewRegrasDistribuicaoCommand : RegrasDistribuicaoCommand
    {
        public NewRegrasDistribuicaoCommand(string nome, string versao)
        {
            Nome = nome;
            VersaoPacote = versao;
            DataInclusao = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }

        public override bool IsValid()
        {
            ValidationResult = new NewRegrasDistribuicaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdateRegrasDistribuicaoCommand : RegrasDistribuicaoCommand
    {
        public UpdateRegrasDistribuicaoCommand(int id, string nome, string versao)
        {
            Id = id;
            Nome = nome;
            VersaoPacote = versao;
            DataAtualizacao = DateTime.Now;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateRegrasDistribuicaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RemoveRegrasDistribuicaoCommand : RegrasDistribuicaoCommand
    {
        public RemoveRegrasDistribuicaoCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveRegrasDistribuicaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}