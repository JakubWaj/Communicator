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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}