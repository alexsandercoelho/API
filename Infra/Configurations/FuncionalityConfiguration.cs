using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.Configurations;

public class FuncionalityConfiguration : IEntityTypeConfiguration<Funcionality>
{
    public void Configure(EntityTypeBuilder<Funcionality> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.CreateDate);
        builder.Property(p => p.LastUpdated).HasDefaultValue(DateTime.Now);
    }
}
