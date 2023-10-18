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
    public interface IVersao : InterfaceGeneric<Versao>
    {
        Task<IList<Versao>> ListarVersao(string emailUsuario);

        Task<IList<Versao>> AdicionarVersao(string emailUsuario);

        Task<IList<Versao>> DeleteVersao(int id);

        Task<IList<Versao>> ObterVersao(int id);

    }
}
