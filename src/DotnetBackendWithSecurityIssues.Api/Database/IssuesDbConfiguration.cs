using DotnetBackendWithSecurityIssues.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBackendWithSecurityIssues.Api.Database;

internal static class IssuesDatabaseConfigurationExtensions
{
    internal static void OnModelCreating(this ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<IssuesDbModelForum>()
            .HasKey(e => e.Id);
    }
}
