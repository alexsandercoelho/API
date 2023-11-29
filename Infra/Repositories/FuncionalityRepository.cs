using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class FuncionalityRepository : Repository<Funcionality>, IFuncionalityRepository
{
    public FuncionalityRepository(DbSet<Funcionality> record) : base(record)
    {
    }
}
