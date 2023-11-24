using Domain.Entities;

namespace Domain.Repositories;

public interface IEarlyBirdRepository : IRepository<EarlyBird>
{
    Task<IList<EarlyBird>> GetAllByIdFlagAsync(Guid idFlag);
}
