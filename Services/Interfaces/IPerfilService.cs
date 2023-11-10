using Entities.Entidades;
using Services.Base;
using Services.ViewModels;

namespace Services.Interfaces
{
    public interface IPerfilService : IServiceBase<PerfilViewModel>
    {
        Task<FuncionalidadeViewModel> GetFuncionalidadesAsync();
    }
}
