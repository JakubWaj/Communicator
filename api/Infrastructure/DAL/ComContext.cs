using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Group = System.Text.RegularExpressions.Group;

namespace Infrastructure.DAL;

public class ComContext : DbContext
{
    public ComContext(DbContextOptions<ComContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Group> Groups { get; set; }    
    public DbSet<GroupMember> GroupMembers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ComContext).Assembly);
    }
}