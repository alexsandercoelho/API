using Domain.Interfaces.Generics;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;

namespace Infra.Repositorio
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(ContextBase context) : base(context) { }

    }
}
