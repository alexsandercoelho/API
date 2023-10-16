using Domain.Interfaces.IPerfil;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class RepositorioPerfil : RepositoryGenerics<Perfil>, InterfacePerfil
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        private readonly IConfiguration _configuration;

        public RepositorioPerfil(IConfiguration configuration)
        {
            _configuration = configuration;
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Perfil>> ListarPerfilUsuario(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder, _configuration))
            {
                return await
                    (from s in banco.Sistema
                     join c in banco.Perfil on s.Id equals c.IdSistema
                     join us in banco.UsuarioSistema on s.Id equals us.IdSistema
                     where us.Email.Equals(emailUsuario) && us.SistemaAtual
                     select c).AsNoTracking().ToListAsync();
            }
        }
    }
}
