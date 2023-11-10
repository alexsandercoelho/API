using Domain.Interfaces.Generics;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;

namespace Infra.Repositorio
{
    public class RegrasDistribuicaoRepository : Repository<RegrasDistribuicao>, IRegrasDistribuicaoRepository
    {
        public RegrasDistribuicaoRepository(ContextBase context) : base(context) { }

    }
}
