using Domain.Entities;
using Domain.Repositories;
using Infra.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security;

namespace Infra.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly DbSet<TEntity> _entities;

    public Repository(DbSet<TEntity> entities) => _entities = entities;

    public async Task AddAsync(TEntity entity) => await _entities.AddAsync(entity);
    public async Task UpdateAsync(TEntity entity) => await Task.Run(() => { _entities.Update(entity); });
    public async Task<TEntity> GetByIdAsync(Guid id, IEnumerable<string> entitiesToInclude) => await _entities.Include(entitiesToInclude).FirstOrDefaultAsync(e => e.Id == id);
    public async Task<IEnumerable<TEntity>> GetAllAsync(IEnumerable<Expression<Func<TEntity, bool>>> predicates,
                                                        IEnumerable<string> entitiesToInclude) => await _entities.Filter(predicates)
                                                                                                                 .Include(entitiesToInclude)
                                                                                                                 .ToListAsync();
    public async Task<IEnumerable<TEntity>> GetAllAsync(int skip, int limit, IEnumerable<Expression<Func<TEntity, bool>>> predicates,
                                                                             IEnumerable<string> entitiesToInclude) => await _entities.Filter(predicates)
                                                                                                                                      .Skip(skip)
                                                                                                                                      .Take(limit)
                                                                                                                                      .Include(entitiesToInclude)
                                                                                                                                      .ToListAsync();
    public void Delete(TEntity entity) => _entities.Remove(entity);
    public async Task DeleteAsync(TEntity entity) => await Task.Run(() => { Delete(entity); });
    public async virtual Task<int> Count(IEnumerable<Expression<Func<TEntity, bool>>> predicates = null) => await _entities.Filter(predicates).CountAsync();
    public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate) => await _entities.AnyAsync(predicate);
}

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(DbSet<Person> record) : base(record)
    {
    }

    public Task<IList<Person>> GetAllByIdProfileAsync(Guid idProfile)
    {
        throw new NotImplementedException();
    }
}

public class ChangesRepository : Repository<Changes>, IChangesRepository
{
    public ChangesRepository(DbSet<Changes> record) : base(record)
    {
    }

    public Task<IList<Changes>> GetAllByIdFlagAsync(Guid idFlag)
    {
        throw new NotImplementedException();
    }
}
public class EarlyBirdRepository : Repository<EarlyBird>, IEarlyBirdRepository
{
    public EarlyBirdRepository(DbSet<EarlyBird> record) : base(record)
    {
    }

    public Task<IList<EarlyBird>> GetAllByIdFlagAsync(Guid idFlag)
    {
        throw new NotImplementedException();
    }
}

public class FeatureRepository : Repository<Feature>, IFeatureRepository
{
    public FeatureRepository(DbSet<Feature> record) : base(record)
    {
    }

    public Task<IList<Feature>> GetAllByIdProfileAsync(Guid idProfile)
    {
        throw new NotImplementedException();
    }
}
public class FlagRepository : Repository<Flag>, IFlagRepository
{
    public FlagRepository(DbSet<Flag> record) : base(record)
    {
    }
}
public class ProfilesRepository : Repository<Profiles>, IProfilesRepository
{
    public ProfilesRepository(DbSet<Profiles> record) : base(record)
    {
    }
}