using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class EarlyBirdRepository : Repository<EarlyBird>, IEarlyBirdRepository
{
    public EarlyBirdRepository(DbSet<EarlyBird> record) : base(record)
    {
    }

    public async Task<IList<EarlyBird>> GetAllByIdFlagAsync(Guid idFlag) => await _entities.Where(e => e.Id == idFlag).ToListAsync();
}
