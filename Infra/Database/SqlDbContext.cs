using Domain.Entities;
using Infra.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database;

public class SqlDbContext : DbContext
{
    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Profiles> Profiles { get; set; }
    public DbSet<Flag> Flags { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<EarlyBird> EarlyBirds { get; set; }
    public DbSet<Changes> Changes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new ProfilesConfiguration());
        modelBuilder.ApplyConfiguration(new FlagConfiguration());
        modelBuilder.ApplyConfiguration(new FeatureConfiguration());
        modelBuilder.ApplyConfiguration(new EarlyBirdConfiguration());
        modelBuilder.ApplyConfiguration(new ChangesConfiguration());

        modelBuilder.Seed();
    }
}

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
    }
}
