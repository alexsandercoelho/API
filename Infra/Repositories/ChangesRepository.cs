using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class ChangesRepository : Repository<Changes>, IChangesRepository
{
    public ChangesRepository(DbSet<Changes> record) : base(record)
    {
    }

    public async Task<IList<Changes>> GetAllByIdFlagAsync(Guid idFlag) => await _entities.Where(e => e.Id == idFlag).ToListAsync();
}
