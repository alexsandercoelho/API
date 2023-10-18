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
    public class RepositorioPerfil : RepositoryGenerics<Perfil>, IPerfil
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioPerfil()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Perfil>> ListarPerfilUsuario(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                    (from s in banco.Sistema
                     join c in banco.Perfil on s.Id equals c.IdSistema
                     join us in banco.UsuarioSistema on s.Id equals us.IdSistema
                     where us.EmailUsuario.Equals(emailUsuario) && us.SistemaAtual
                     select c).AsNoTracking().ToListAsync();
            }
        }
    }
}
