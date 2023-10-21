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
    public interface IGrupo
    {
        Task<IList<Grupo>> AdicionarGrupo(Grupo grupo);

        Task<IList<Grupo>> AlterarGrupo(Grupo grupo);

        Task<IList<Grupo>> ExcluirGrupo(Grupo grupo);

        Task<IList<Grupo>> ObterGrupo(Grupo grupo);
    }
}
