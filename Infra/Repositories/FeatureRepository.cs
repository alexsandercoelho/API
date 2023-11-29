using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class FeatureRepository : Repository<Feature>, IFeatureRepository
{
    public FeatureRepository(DbSet<Feature> record) : base(record)
    {
    }

    public async Task<IList<Feature>> GetAllByIdProfileAsync(Guid idProfile) => await _entities.Where(e => e.Id == idProfile).ToListAsync();
}
