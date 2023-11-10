using Domain.Interfaces.Generics;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;

namespace Infra.Repositorio
{
    public class FuncionalidadeRepository : Repository<Funcionalidade>, IFuncionalidadeRepository
    {
        public FuncionalidadeRepository(ContextBase context) : base(context) { }

    }
}
