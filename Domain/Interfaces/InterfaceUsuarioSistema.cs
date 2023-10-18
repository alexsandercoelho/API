using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface InterfaceUsuarioSistema : InterfaceGeneric<UsuarioSistema>
    {
        Task<IList<UsuarioSistema>> ListarUsuariosSistema(int IdSistema);

        Task RemoveUsuarios(List<UsuarioSistema> usuarios);

        Task<UsuarioSistema> ObterUsuarioPorEmail(string emailUsuario);
    }
}
