using Domain.Commands;
using Domain.Validations;

namespace Domain.CommandHandlers
{
    public class NewFuncionalidadeCommand : FuncionalidadeCommand
    {
        public NewFuncionalidadeCommand(string nome)
        {
            Nome = nome;
        }

        public override bool IsValid()
        {
            ValidationResult = new NewFuncionalidadeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdateFuncionalidadeCommand : FuncionalidadeCommand
    {
        public UpdateFuncionalidadeCommand(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateFuncionalidadeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RemoveFuncionalidadeCommand : FuncionalidadeCommand
    {
        public RemoveFuncionalidadeCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveFuncionalidadeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}