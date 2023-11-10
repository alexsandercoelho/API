namespace Services.ViewModels
{
    public class GrupoDistribuicaoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QuantidadePessoas { get; set; }
        public string VersoesAssociadas { get; set; }
        public string PropriedadeComparacao { get; set; }
        public string ValoresAssociados { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
