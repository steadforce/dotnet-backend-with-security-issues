using DotnetBackendWithSecurityIssues.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBackendWithSecurityIssues.Api.Database;

public class IssuesDbContext : DbContext
{
    public IssuesDbContext(DbContextOptions<IssuesDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.OnModelCreating();
    }
    public DbSet<IssuesDbModelForum> IssuesDbModelForum { get; set; } = null!;
}


