using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

public class ProfilesRepository : Repository<Profiles>, IProfilesRepository
{
    public ProfilesRepository(DbSet<Profiles> record) : base(record)
    {
    }
}
