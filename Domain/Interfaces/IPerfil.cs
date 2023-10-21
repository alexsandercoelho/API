using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPerfil
    {
        Task<IList<Perfil>> AdicionarPerfil(Perfil perfil);

        Task<IList<Perfil>> AlterarPerfil(Perfil perfil);

        Task<IList<Perfil>> ExcluirPerfil(Perfil perfil);

    }
}
