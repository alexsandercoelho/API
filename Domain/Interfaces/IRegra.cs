using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRegra
    {
        Task<IList<Regra>> AdicionarRegra(Regra regra);

        Task<IList<Regra>> AlterarRegra(Regra regra);

        Task<IList<Regra>> ExcluirRegra(Regra regra);


    }
}
