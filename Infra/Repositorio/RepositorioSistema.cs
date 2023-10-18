using Domain.Interfaces;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;
using Microsoft.EntityFrameworkCore;
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

        public RepositorioSistema()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Sistema>> ListaSistemasUsuario(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder))
            {
                return await
                   (from s in banco.Sistema
                    join us in banco.UsuarioSistema on s.Id equals us.IdSistema                   
                    where us.EmailUsuario.Equals(emailUsuario) 
                    select s).AsNoTracking().ToListAsync();
            }
        }
    }
}
