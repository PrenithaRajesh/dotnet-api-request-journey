using Bank.Api.Data;

namespace Bank.Api.Services;

public class TransactionAuditService
{
    public Guid InstanceId { get; } = Guid.NewGuid();
    private readonly AppDbContext _dbContext;

    public TransactionAuditService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        Console.WriteLine( $"Audit Service: {InstanceId} | DbContext: {_dbContext.GetHashCode()}");
    
    }
    public int DbContextHash() => _dbContext.GetHashCode();
}