using Domain.Entities;

namespace Domain.Repositories;

public interface IFeatureRepository : IRepository<Feature>
{
    Task<IList<Feature>> GetAllByIdProfileAsync(Guid idProfile);
}
