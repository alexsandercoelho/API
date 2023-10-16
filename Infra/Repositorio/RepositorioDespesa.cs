using Domain.Interfaces.IDespesa;
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
    public class RepositorioDespesa : RepositoryGenerics<Despesa>, InterfaceDespesa
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        private readonly IConfiguration _configuration;

        public RepositorioDespesa(IConfiguration configuration)
        {
            _configuration = configuration;
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Despesa>> ListarDespesasUsuario(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder, _configuration))
            {
                return await
                   (from s in banco.Sistema
                    join c in banco.Perfil on s.Id equals c.IdSistema
                    join us in banco.UsuarioSistema on s.Id equals us.IdSistema
                    join d in banco.Despesa on c.Id equals d.IdPerfil
                    where us.Email.Equals(emailUsuario) && s.Mes == d.Mes && s.Ano == d.Ano
                    select d).AsNoTracking().ToListAsync();
            }
        }

        public async Task<IList<Despesa>> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario)
        {
            using (var banco = new ContextBase(_OptionsBuilder, _configuration))
            {
                return await
                   (from s in banco.Sistema
                    join c in banco.Perfil on s.Id equals c.IdSistema
                    join us in banco.UsuarioSistema on s.Id equals us.IdSistema
                    join d in banco.Despesa on c.Id equals d.IdPerfil
                    where us.Email.Equals(emailUsuario) && d.Mes < DateTime.Now.Month && !d.Pago
                    select d).AsNoTracking().ToListAsync();
            }
        }
    }
}
