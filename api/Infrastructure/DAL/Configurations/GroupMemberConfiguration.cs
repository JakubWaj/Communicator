using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class GroupMemberConfiguration : IEntityTypeConfiguration<GroupMember>
{
    public void Configure(EntityTypeBuilder<GroupMember> builder)
    {
        builder.HasKey(gm => new {gm.GroupId, gm.UserId});
        builder.HasOne(gm => gm.Group)
            .WithMany(g => g.Users)
            .HasForeignKey(gm => gm.GroupId);
        builder.HasOne(gm => gm.User)
            .WithMany(u => u.Groups)
            .HasForeignKey(gm => gm.UserId);
    }
}