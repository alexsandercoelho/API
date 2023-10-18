using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGrupo : InterfaceGeneric<Grupo>
    {
        Task<IList<Grupo>> ListarGrupos(string emailUsuario);

        Task<IList<Grupo>> AtualizarGrupo(string emailUsuario);

        Task<IList<Grupo>> ObterGrupo(string emailUsuario);

        Task<IList<Grupo>> DeleteGrupo(string emailUsuario);
    }
}
