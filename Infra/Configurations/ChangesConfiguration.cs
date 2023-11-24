using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.Configurations;

public class ChangesConfiguration : IEntityTypeConfiguration<Changes>
{
    public void Configure(EntityTypeBuilder<Changes> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.IdFlag).IsRequired();
        builder.Property(p => p.Key);
        builder.Property(p => p.AttributeChanged);
        builder.Property(p => p.CurrentSituation);
        builder.Property(p => p.LastSituation);
        builder.Property(p => p.CreateDate);
        builder.Property(p => p.LastUpdated).HasDefaultValue(DateTime.Now);
    }
}