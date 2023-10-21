using Domain.Interfaces;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servicos
{
    public class PessoaServico : IPessoa
    {
        public Task<IList<Pessoa>> AdicionarPessoa(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Pessoa>> AlterarPessoa(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Pessoa>> ExcluirPessoa(int id)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirPessoa(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Pessoa>> ListarPessoa(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Pessoa>> ObterPerfil(int id)
        {
            throw new NotImplementedException();
        }
    }
}
