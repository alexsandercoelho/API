﻿using Domain;
using Domain.Repositories;
using Infra.Database;

namespace Infra;

public class UnitOfWork : IUnitOfWork
{
    public IPersonRepository PersonRepository { get; set; }
    public IProfilesRepository ProfilesRepository { get; set; }
    public IFlagRepository FlagRepository { get; set; }
    public IFeatureRepository FeatureRepository { get; set; }
    public IEarlyBirdRepository EarlyBirdRepository { get; set; }
    public IChangesRepository ChangesRepository { get; set; }

    private readonly SqlDbContext _context;

    public UnitOfWork(SqlDbContext context,
                      IPersonRepository personRepository, 
                      IProfilesRepository profilesRepository, 
                      IFlagRepository flagRepository, 
                      IFeatureRepository featureRepository, 
                      IEarlyBirdRepository earlyBirdRepository, 
                      IChangesRepository changesRepository)
    {
        PersonRepository = personRepository;
        ProfilesRepository = profilesRepository;
        FlagRepository = flagRepository;
        FeatureRepository = featureRepository;
        EarlyBirdRepository = earlyBirdRepository;
        ChangesRepository = changesRepository;
        _context = context;
    }

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    public void Dispose() => _context.Dispose();
}