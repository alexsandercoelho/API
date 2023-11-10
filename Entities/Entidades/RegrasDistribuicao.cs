namespace Entities.Entidades
{
    public class RegrasDistribuicao : Base
    {
        public string VersaoPacote { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public virtual IList<GrupoDistribuicao> GruposDistribuicao { get; set; }
    }
}
