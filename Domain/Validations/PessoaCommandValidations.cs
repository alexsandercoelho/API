using Domain.CommandHandlers;
using Domain.Core.Validations;

namespace Domain.Validations
{
    public class NewPessoaCommandValidation : PessoaValidation<NewPessoaCommand>
    {
        public NewPessoaCommandValidation()
        {
            ValidateNome();
        }
    }

    public class UpdatePessoaCommandValidation : PessoaValidation<UpdatePessoaCommand>
    {
        public UpdatePessoaCommandValidation()
        {
            ValidateNome();
        }
    }

    public class RemovePessoaCommandValidation : PessoaValidation<RemovePessoaCommand>
    {
        public RemovePessoaCommandValidation()
        {
        }
    }
}
