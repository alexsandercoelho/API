using Domain.Repositories;

namespace Domain;

public interface IUnitOfWork : IDisposable
{
    IPersonRepository PersonRepository { get; set; }
    IProfilesRepository ProfilesRepository { get; set; }
    IFlagRepository FlagRepository { get; set; }
    IFeatureRepository FeatureRepository { get; set; }
    IEarlyBirdRepository EarlyBirdRepository { get; set; }
    IChangesRepository ChangesRepository { get; set; }
    Task<int> SaveAsync();
}