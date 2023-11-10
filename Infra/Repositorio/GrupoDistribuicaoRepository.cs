using Domain.Interfaces.Generics;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;

namespace Infra.Repositorio
{
    public class GrupoDistribuicaoRepository : Repository<GrupoDistribuicao>, IGrupoDistribuicaoRepository
    {
        public GrupoDistribuicaoRepository(ContextBase context) : base(context) { }

    }
}
