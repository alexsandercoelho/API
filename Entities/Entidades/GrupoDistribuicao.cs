namespace Entities.Entidades
{
    public class GrupoDistribuicao : Base
    {
        public int QuantidadePessoas { get; set; }
        public string VersoesAssociadas { get; set; }
        public string PropriedadeComparacao { get; set; }
        public string ValoresAssociados { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public RegrasDistribuicao RegrasDistribuicao { get; set; }
    }
}
