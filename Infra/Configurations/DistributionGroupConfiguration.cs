using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.Configurations;

public class DistributionGroupConfiguration : IEntityTypeConfiguration<DistributionGroup>
{
    public void Configure(EntityTypeBuilder<DistributionGroup> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.PersonQty).IsRequired();
        builder.Property(p => p.AssociatedVersions).IsRequired();
        builder.Property(p => p.PropertyComparison).IsRequired(); 
        builder.Property(p => p.AssociatedValues).IsRequired();
        builder.Property(p => p.CreateDate);
        builder.Property(p => p.LastUpdated).HasDefaultValue(DateTime.Now);
    }
}
