using Entities.Entidades;
using Services.Base;
using Services.ViewModels;

namespace Services.Interfaces
{
    public interface IUsuarioSistemaService : IServiceBase<UsuarioSistemaViewModel>
    {
        Task<IList<UsuarioSistemaViewModel>> GetByIdSistemaAsync(int IdSistema);
        Task<UsuarioSistemaViewModel> GetByEmailAsync(string email);
    }
}
