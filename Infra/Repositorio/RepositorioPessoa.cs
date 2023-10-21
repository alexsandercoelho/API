using Domain.Interfaces;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioPessoa : RepositoryGenerics<Pessoa>, IPessoa
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioPessoa()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Pessoa> (string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
             
            }
        }
    }
}
