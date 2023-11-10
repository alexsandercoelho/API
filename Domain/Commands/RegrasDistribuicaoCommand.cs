using Domain.Core;

namespace Domain.Commands
{
    public abstract class RegrasDistribuicaoCommand : Command
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public string VersaoPacote { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
