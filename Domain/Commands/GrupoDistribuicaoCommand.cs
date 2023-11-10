using Domain.Core;

namespace Domain.Commands
{
    public abstract class GrupoDistribuicaoCommand : Command
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public int QuantidadePessoas { get; set; }
        public string VersoesAssociadas { get; set; }
        public string PropriedadeComparacao { get; set; }
        public string ValoresAssociados { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
