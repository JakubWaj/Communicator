using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAL;

public class ComContext : DbContext
{
    public ComContext(DbContextOptions<ComContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Domain.Entity.Groups> Groups { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<GroupUser> GroupUsers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}