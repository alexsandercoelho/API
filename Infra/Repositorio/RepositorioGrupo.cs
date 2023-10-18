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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioGrupo : RepositoryGenerics<Grupo>, IGrupo
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioGrupo()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Grupo>> ListarGrupo(string emailUsuario)
        {
        }
    }
}
