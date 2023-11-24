using Domain.Entities;

namespace Domain.Repositories;

public interface IPersonRepository : IRepository<Person>
{
    Task<IList<Person>> GetAllByIdProfileAsync(Guid idProfile);
}
