using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.Configurations;

public class DistributionRulesConfiguration : IEntityTypeConfiguration<DistributionRules>
{
    public void Configure(EntityTypeBuilder<DistributionRules> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.PackageVersion).IsRequired();
        builder.Property(p => p.CreateDate);
        builder.Property(p => p.LastUpdated).HasDefaultValue(DateTime.Now);
    }
}