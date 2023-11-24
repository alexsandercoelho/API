using Domain;
using Infra.Database;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Infra.Repositories;

public static class UnitOfWorkExtension
{
    public static IServiceCollection SetupUnitOfWork([NotNullAttribute] this IServiceCollection serviceCollection)
    {
        //TODO: Find a way to inject the repositories and share the same context without creating a instance.
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>(f =>
        {
            var scopeFactory = f.GetRequiredService<IServiceScopeFactory>();
            var context = f.GetService<SqlDbContext>();
            return new UnitOfWork(
                context,
                new PersonRepository(context.Persons),
                new ProfilesRepository(context.Profiles),
                new FlagRepository(context.Flags),
                new FeatureRepository(context.Features),
                new EarlyBirdRepository(context.EarlyBirds),
                new ChangesRepository(context.Changes)
            );
        });
        return serviceCollection;
    }
}
