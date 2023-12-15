using Domain.Repository;

namespace Infrastructure.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ComContext _dbContext;

    public UnitOfWork(ComContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}