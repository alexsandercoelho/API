using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class DistributionRulesRepository : Repository<DistributionRules>, IDistributionRulesRepository
{
    public DistributionRulesRepository(DbSet<DistributionRules> record) : base(record)
    {
    }
}