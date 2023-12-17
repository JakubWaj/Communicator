using Domain.Entity;
using Domain.ValueObjects.Group;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Groups>
{
    public void Configure(EntityTypeBuilder<Groups> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new GroupId(x));
        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, x => new Name(x))
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(x => x.CreatedAt).IsRequired();
    }
}