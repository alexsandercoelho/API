using Domain.Core;

namespace Domain.Commands
{
    public abstract class FuncionalidadeCommand : Command
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
    }
}
