namespace Services.ViewModels
{
    public class UsuarioSistemaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Administrador { get; set; }
        public bool SistemaAtual { get; set; }
        public int IdSistema { get; set; }
    }
}
