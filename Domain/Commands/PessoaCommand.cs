using Domain.Core;

namespace Domain.Commands
{
    public abstract class PessoaCommand : Command
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public int PerfilId { get; set; }
    }
}
