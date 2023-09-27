using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ISistema
{
    public interface InterfaceSistema : InterfaceGeneric<Sistema>
    {
        Task<IList<Sistema>> ListaSistemasUsuario(string emailUsuario);
    }
}
