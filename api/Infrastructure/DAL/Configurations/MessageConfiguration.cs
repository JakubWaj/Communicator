using Domain.Entity;
using Domain.ValueObjects.Message;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasKey(x => x.MessageId);
        builder.Property(x => x.MessageId)
            .HasConversion(x => x.Value, x => new MessageId(x));
        builder.Property(x => x.Content)
            .HasConversion(x => x.Value, x => new Content(x))
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.HasOne(x => x.Group)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.GroupId);
        builder.HasOne(x => x.User)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.UserId);
    }
}