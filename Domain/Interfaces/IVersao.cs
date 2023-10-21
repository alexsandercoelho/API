using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVersao 
    {
        Task<IList<Versao>> ListarVersao (Versao versao);

        Task<IList<Versao>> AlterarVersao(Versao versao);


    }
}


