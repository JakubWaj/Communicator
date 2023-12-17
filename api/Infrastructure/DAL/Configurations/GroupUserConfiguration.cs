using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations;

public class GroupUserConfiguration : IEntityTypeConfiguration<GroupUser>
{
    public void Configure(EntityTypeBuilder<GroupUser> builder)
    {
        builder.HasKey(x => new {x.GroupId, x.UserId});
        builder.HasOne(x => x.Group)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.GroupId);
        builder.HasOne(x => x.User)
            .WithMany(x => x.Groups)
            .HasForeignKey(x => x.UserId);
    }
}