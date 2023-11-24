using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.Configurations;

public class FlagConfiguration : IEntityTypeConfiguration<Flag>
{
    public void Configure(EntityTypeBuilder<Flag> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.PackageVersion);
        builder.Property(p => p.Key);
        builder.Property(p => p.Situation);
        builder.Property(p => p.CreateDate);
        builder.Property(p => p.LastUpdated).HasDefaultValue(DateTime.Now);
    }
}