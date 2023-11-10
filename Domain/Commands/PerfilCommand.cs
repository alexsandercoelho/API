using Domain.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Commands
{
    public abstract class PerfilCommand : Command
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
