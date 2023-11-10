using Domain.Commands;
using Domain.Validations;

namespace Domain.CommandHandlers
{
    public class NewGrupoDistribuicaoCommand : GrupoDistribuicaoCommand
    {
        public NewGrupoDistribuicaoCommand(string nome, int qtdPessoas, string versoes, string propriedade, string valores)
        {
            Nome = nome;
            QuantidadePessoas = qtdPessoas;
            VersoesAssociadas = versoes;
            ValoresAssociados = valores;
            DataInclusao = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }

        public override bool IsValid()
        {
            ValidationResult = new NewGrupoDistribuicaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdateGrupoDistribuicaoCommand : GrupoDistribuicaoCommand
    {
        public UpdateGrupoDistribuicaoCommand(int id, string nome, int qtdPessoas, string versoes, string propriedade, string valores)
        {
            Id = id;
            Nome = nome;
            QuantidadePessoas = qtdPessoas;
            VersoesAssociadas = versoes;
            ValoresAssociados = valores;
            DataAtualizacao = DateTime.Now;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateGrupoDistribuicaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RemoveGrupoDistribuicaoCommand : GrupoDistribuicaoCommand
    {
        public RemoveGrupoDistribuicaoCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveGrupoDistribuicaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}