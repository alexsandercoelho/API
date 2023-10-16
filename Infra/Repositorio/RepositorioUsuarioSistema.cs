using Domain.Interfaces.IUsuarioSistema;
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
    public class RepositorioUsuarioSistema : RepositoryGenerics<UsuarioSistema>, InterfaceUsuarioSistema
    {
        private readonly IConfiguration _configuration;
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositorioUsuarioSistema(IConfiguration configuration)
        {
            _configuration = configuration;
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<UsuarioSistema>> ListarUsuariosSistema(int IdSistema)
        {
            using (var banco = new ContextBase(_OptionsBuilder, _configuration))
            {
                return await
                    banco.UsuarioSistema
                    .Where(s => s.IdSistema == IdSistema).AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task<UsuarioSistema> ObterUsuarioPorEmail(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder, _configuration))
            {
                return await
                    banco.UsuarioSistema.AsNoTracking().FirstOrDefaultAsync(x => x.Email.Equals(emailUsuario));
            }
        }

        public async Task RemoveUsuarios(List<UsuarioSistema> usuarios)
        {
            using (var banco = new ContextBase(_OptionsBuilder, _configuration))
            {
                banco.UsuarioSistema
               .RemoveRange(usuarios);

                await banco.SaveChangesAsync();
            }
        }
    }
}
