using eHubApi.Models;
using Microsoft.EntityFrameworkCore;

namespace eHubApi.Data;

public class LogContext : DbContext
{
    public LogContext(DbContextOptions<LogContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<LogEntry>  Logs { get; set; }
}
