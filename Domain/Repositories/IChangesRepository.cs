using Domain.Entities;

namespace Domain.Repositories;

public interface IChangesRepository : IRepository<Changes>
{
    Task<IList<Changes>> GetAllByIdFlagAsync(Guid idFlag);
}