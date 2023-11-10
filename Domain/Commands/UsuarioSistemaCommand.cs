using Domain.Core;

namespace Domain.Commands
{
    public abstract class UsuarioSistemaCommand : Command
    {
        public int Id { get; protected set; }
        public string Email { get; protected set; }
        public bool Administrador { get; protected set; }
        public bool SistemaAtual { get; protected set; }
        public int IdSistema { get; protected set; }
    }
}
