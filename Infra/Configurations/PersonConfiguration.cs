using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.IdProfile).IsRequired();
        builder.Property(p => p.CreateDate);
        builder.Property(p => p.LastUpdated).HasDefaultValue(DateTime.Now);
    }
}
