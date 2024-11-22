using DotnetBackendWithSecurityIssues.Api.Models.Forum;
using Microsoft.EntityFrameworkCore;

namespace DotnetBackendWithSecurityIssues.Api.Database;

internal static class IssuesDatabaseConfigurationExtensions
{
    internal static void OnModelCreating(this ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<ForumIssuesDbModel>()
            .HasKey(e => e.Id);

        modelBuilder
            .Entity<ForumIssuesDbModel>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
    }
}
