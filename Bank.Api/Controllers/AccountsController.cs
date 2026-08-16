using Microsoft.AspNetCore.Mvc;
using Bank.Api.Data;
using Bank.Api.Services;

namespace Bank.Api.Controllers;

[ApiController]
[Route("accounts")]
public class AccountsController : ControllerBase
{

    private readonly AppDbContext _db;
    private readonly TransactionAuditService _audit1;
    // private readonly TransactionAuditService _audit2;

    public AccountsController(AppDbContext db, TransactionAuditService audit1, TransactionAuditService audit2){
        _db = db;
        _audit1 = audit1;
        // _audit2 = audit2;
        Console.WriteLine($"Controller: DbContext: {_db.GetHashCode()}");
    }

    [HttpGet]
    public IActionResult GetAccounts()
    {
        var accounts = _db.Accounts.ToList();

        return Ok(accounts);
    }

    // [HttpGet("audit")]
    // public IActionResult Audit()
    // {
    //     return Ok(new
    //     {
    //         AuditInstance1 = _audit1.InstanceId,
    //         // AuditInstance2 = _audit2.InstanceId
    //     });
    // }

    [HttpGet("audit")]
    public IActionResult Audit()
    {
        return Ok(new
        {
            AuditService = _audit1.InstanceId,
            ControllerDbContext = _db.GetHashCode(),
            AuditDbContext = _audit1.DbContextHash()
        });
    }

    [HttpGet]
    [Route("dummy")]
    public IActionResult GetDummyAccounts()
    {
        var accounts = new[]
        {
            new { Id = 1, AccountNumber = "100001", OwnerName = "Prenitha", Balance = 1250.75m },
            new { Id = 2, AccountNumber = "100002", OwnerName = "Rajesh", Balance = 300.00m }
        };

        return Ok(accounts);
    }

    [HttpGet]
    [Route("check")]
    public IActionResult CheckDB()
    {
        return Ok(new
        {
            Message = "Controller received a DbContext.",
            DbContextType = _db.GetType().Name
        });
    }
}