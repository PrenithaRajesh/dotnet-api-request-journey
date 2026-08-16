using Bank.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        // Console.WriteLine("AppDbContext constructor called!");
    }

    public DbSet<Account> Accounts => Set<Account>();
}