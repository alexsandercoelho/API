using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(DbSet<Person> record) : base(record)
    {
    }

    public async Task<IList<Person>> GetAllByIdProfileAsync(Guid idProfile) => await _entities.Where(e => e.Id == idProfile).ToListAsync();
}
