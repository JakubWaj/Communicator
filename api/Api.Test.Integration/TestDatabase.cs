using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Api.Test.Integration;

public class TestDatabase : IDisposable
{
    public ComContext Context { get; }
    public TestDatabase(ComContext context)
    {
        Context = context;
        Context = new ComContext(new DbContextOptionsBuilder<ComContext>().UseNpgsql("TestDb").Options);
    }
    
    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}