using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ISistema
{
    public interface InterfaceSistema : IInterfaceGeneric<Sistema>
    {
        Task<IList<Sistema>> ListaSistemas();
        Task<IList<Sistema>> ListaSistemasPorUsuario(string emailUsuario);
    }
}
