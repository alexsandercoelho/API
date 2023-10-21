using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPessoa
    {
        Task<IList<Pessoa>> AdicionarPessoa(Pessoa pessoa);

        Task<IList<Pessoa>> AlterarPessoa(Pessoa pessoa);

        Task<IList<Pessoa>> ExcluirPessoa(int id);

        Task<IList<Pessoa>> ObterPerfil(int id);
    }


}

