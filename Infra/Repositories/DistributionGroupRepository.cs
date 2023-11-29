using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class DistributionGroupRepository : Repository<DistributionGroup>, IDistributionGroupRepository
{
    public DistributionGroupRepository(DbSet<DistributionGroup> record) : base(record)
    {
    }

    public async Task<IList<DistributionGroup>> GetAllByIdRulesAsync(Guid idRules) => await _entities.Where(e => e.Id == idRules).ToListAsync();
}
