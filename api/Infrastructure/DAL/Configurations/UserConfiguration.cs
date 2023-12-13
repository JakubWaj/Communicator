using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.FirstName).IsRequired()
            .HasMaxLength(50);
        builder.Property(u => u.LastName).IsRequired()
            .HasMaxLength(50);
        builder.Property(u => u.Password).IsRequired()
            .HasMaxLength(200);
        builder.Property(u => u.CreatedAt).IsRequired();
        builder.Property(u => u.UpdatedAt).IsRequired();
        builder.HasMany(u => u.Messages)
            .WithOne(m => m.Sender)
            .HasForeignKey(m => m.SenderId);
        builder.HasMany(u => u.Groups)
            .WithOne(gm => gm.User)
            .HasForeignKey(gm => gm.UserId);
    }
}