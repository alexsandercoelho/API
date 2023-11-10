namespace Services.ViewModels
{
    public class RegrasDistribuicaoViewModel
    {
        public int Id { get; set; }
        public string NomePacote { get; set; }
        public string VersaoPacote { get; set; }
        public IList<GrupoDistribuicaoViewModel> GruposDistribuicao { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
