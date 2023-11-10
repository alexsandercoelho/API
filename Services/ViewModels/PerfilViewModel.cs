using Entities.Entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.ViewModels
{
    public class PerfilViewModel
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public IList<FuncionalidadeViewModel> Funcionalidades { get; set; }
    }

    public class FuncionalidadeViewModel
    {
        public required int Id { get; set; }
        public required string Nome { get; set; }
    }
}
