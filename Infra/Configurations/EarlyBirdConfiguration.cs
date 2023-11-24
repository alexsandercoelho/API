using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.Configurations;

public class EarlyBirdConfiguration : IEntityTypeConfiguration<EarlyBird>
{
    public void Configure(EntityTypeBuilder<EarlyBird> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.IdFlag).IsRequired();
        builder.Property(p => p.QtyPeople);
        builder.Property(p => p.ComparisionProperty);
        builder.Property(p => p.CreateDate);
        builder.Property(p => p.LastUpdated).HasDefaultValue(DateTime.Now);
    }
}
