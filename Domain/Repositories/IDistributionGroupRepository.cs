using Domain.Entities;

namespace Domain.Repositories;

public interface IDistributionGroupRepository : IRepository<DistributionGroup>
{
    Task<IList<DistributionGroup>> GetAllByIdRulesAsync(Guid idRules);
}
