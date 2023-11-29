using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class FlagRepository : Repository<Flag>, IFlagRepository
{
    public FlagRepository(DbSet<Flag> record) : base(record)
    {
    }
}
