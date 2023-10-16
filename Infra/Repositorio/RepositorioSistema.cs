using Domain.Interfaces.ISistema;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioSistema : RepositoryGenerics<Sistema>, InterfaceSistema
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        private readonly IConfiguration _configuration;

        public RepositorioSistema(IConfiguration configuration)
        {
            _configuration = configuration;
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Sistema>> ListaSistemas()
        {
            using (var context = new ContextBase(_OptionsBuilder, _configuration))
            {
                return await context.Sistema.ToListAsync();
            }
        }

        public async Task<IList<Sistema>> ListaSistemasPorUsuario(string emailUsuario)
        {
            using (var context = new ContextBase(_OptionsBuilder, _configuration))
            {
                return await context.Sistema.Include(s => s.Usuarios.Where(w => w.Email == emailUsuario)).ToListAsync();
            }
        }
    }
}
