using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGrupo : InterfaceGeneric<Pessoa>
    {
        Task<IList<Pessoa>> ListarPessoa(string pessoa);
        Task AdicionarPessoa(Pessoa pessoa);

        Task AtualizarPessoa(Pessoa pessoa);

        Task<IList<Pessoa>> ObterPessoa(int id);

        Task DeletePessoa(int id);

    }


}

